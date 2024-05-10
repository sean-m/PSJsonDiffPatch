#Requires -Module PSGet
if (-not (Get-PSRepository | where Name -like "Nuget")) {
	Register-PackageSource -Name Nuget -Location "http://www.nuget.org/api/v2" –ProviderName Nuget -Trusted
	Install-PackageProvider Nuget
	Install-Package Newtonsoft.Json -Source "http://www.nuget.org/api/v2" -Force -ProviderName Nuget -SkipDependencies
}