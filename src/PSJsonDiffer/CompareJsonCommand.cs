using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using JsonDiffer;
using Newtonsoft.Json.Linq;

namespace PSJsonDiffPatch
{

    [Cmdlet(VerbsData.Compare, "Json")]
    [OutputType(typeof(object))]
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

        [Parameter(
            Position = 2,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter DetailedOutput { get; set; }


        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = false)]
        public SwitchParameter ShowOriginalValues { get; set; }


        protected override void BeginProcessing() {

        }


        protected override void ProcessRecord() {
            var mode = DetailedOutput.ToBool() ? OutputMode.Detailed : OutputMode.Symbol;

            var first = JToken.Parse(FirstRecord);
            var second = JToken.Parse(SecondRecord);
            var difference = JsonHelper.Difference(first, second, outputMode: mode, showOriginalValues: ShowOriginalValues.ToBool()).ToString();

            WriteObject(difference);
        }
    }
}
