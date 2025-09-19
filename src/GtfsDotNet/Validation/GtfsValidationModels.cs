using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Validation
{
    using System.Collections.Generic;

    namespace GtfsDotNet
    {
        public class GtfsValidationResult
        {
            public bool IsValid => MissingRequiredFiles.Count == 0 && FileErrors.Count == 0;

            /// <summary>Files that are missing from the dataset.</summary>
            public List<GtfsFileType> MissingRequiredFiles { get; } = new();

            /// <summary>Validation issues per file (missing columns, bad formats, etc.)</summary>
            public List<GtfsFileValidationResult> FileErrors { get; } = new();
        }

        public class GtfsFileValidationResult
        {
            public GtfsFileType FileType { get; set; }
            public List<string> MissingColumns { get; } = new();
            public List<string> RowErrors { get; } = new();
            public bool IsValid => MissingColumns.Count == 0 && RowErrors.Count == 0;
        }
    }

}
