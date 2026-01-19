using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet
{
    public abstract class GtfsDataItem
    {
        internal GtfsFeedArchive Dataset { get; set; }

        internal string? Id { get; set; }
    }
}
