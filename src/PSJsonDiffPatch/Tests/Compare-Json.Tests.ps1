#Requires -Modules Pester

begin {
    Push-Location (Split-Path -Parent $MyInvocation.MyCommand.Definition)
    Push-Location ..\bin\Debug\netstandard2.0

    $moduleItem = gci -Recurse ../../*PSJsonDiffPatch.psd1
    Import-Module "$($moduleItem.FullName)"
}
process {
    Describe 'Compare-Json' {
        BeforeAll {
	        $docOne = "{'Foo':'Bar', 'Baz':[1,2,3]}"

	        $docTwo = "{'Foo':'Bar', 'Baz':[1,2,3,4]}"

	        $docThree = "{'Foo':'Bar', 'Baz':[4,1,2,3]}"
        }

	    It 'Given docOne and docTwo, the Baz element should differ.' {
		    $result = Compare-Json $docOne $docTwo
		    $result | Should Not Be $null
	    }

        It 'Given docTwo and docThree, the Baz element should not differ.' {
		    $result = Compare-Json $docTwo $docThree
		    $result | Should Be $null
	    }
    }
}
end {
    Remove-Module PSJsonDiffPatch
    Pop-Location
    Pop-Location
}