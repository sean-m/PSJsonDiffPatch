#Requires -Modules Pester, PSJsonDiffer

begin {

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
		    $result | Should -Not -BeNullOrEmpty
	    }

        It 'Given docTwo and docThree, the Baz element should not differ.' {
		    $result = Compare-Json $docTwo $docThree
		    $result | Should -BeNullOrEmpty
	    }
    }
}
end {

}