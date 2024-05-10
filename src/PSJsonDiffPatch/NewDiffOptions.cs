using JsonDiffPatchDotNet;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace PSJsonDiffPatch
{
    [Cmdlet(VerbsCommon.New, "DiffOptions")]
    [OutputType(typeof(JsonDiffPatchDotNet.Options))]
    public class NewDiffOptions : Cmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = true)]
        public ArrayDiffMode ArrayDiffMode { get; set; } = ArrayDiffMode.Efficient;

        [Parameter(
            Position = 1,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = true)]
        public TextDiffMode TextDiffMode { get; set; } = TextDiffMode.Efficient;

        [Parameter(
            Position = 2,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = true)]
        public long TextDiffModeMinLength { get; set; } = 50;

        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = true)]
        public IEnumerable<string> ExcludePaths { get; set; }

        protected override void EndProcessing()
        {
            WriteObject(new Options
            {
                ArrayDiff = ArrayDiffMode,
                TextDiff = TextDiffMode,
                MinEfficientTextDiffLength = TextDiffModeMinLength,
                ExcludePaths = new List<string>(ExcludePaths),
            });
        }
    }
}
