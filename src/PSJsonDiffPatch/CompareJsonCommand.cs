using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using JsonDiffPatchDotNet;
using Newtonsoft.Json.Linq;

namespace PSJsonDiffPatch
{
    
    [Cmdlet(VerbsData.Compare, "Json")]
    [OutputType(typeof(JToken))]
    public class CompareJsonCommand : PSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName=true)]
        public string FirstRecord { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = true)]
        public string SecondRecord { get; set; }

        private JsonDiffPatch jdp;

        protected override void BeginProcessing() {
            jdp = new JsonDiffPatch();
        }


        protected override void ProcessRecord() {
            WriteObject(jdp?.Diff(FirstRecord, SecondRecord));
        }

        protected override void EndProcessing ()
        {

        }
    }
}
