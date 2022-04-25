#Requires -Modules Pester, PSJsonDiffPatch





Describe 'Compare-Json' {
    BeforeAll {
	    $docOne = "{'Foo':'Bar', 'Baz':[1,2,3]}"

	    $docTwo = "{'Foo':'Bar', 'Baz':[1,2,3,4]}"

	    $docThree = "{'Foo':'Bar', 'Baz':[1,2,3,4]}"
    }

	It 'Given docOne and docTwo, the Baz element should differ.' {
		$result = Compare-Json $docOne $docTwo
		$result | Should -Not -Be $null
	}
}