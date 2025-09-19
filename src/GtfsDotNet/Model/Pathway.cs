using GtfsDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Model
{

    [GtfsFile("pathways.txt")]
    public class Pathway : GtfsDataItem
    {
        [GtfsProperty("pathway_id", 0)]
        public string PathwayId { get; set; }

        [GtfsProperty("from_stop_id", 1)]
        public string FromStopId { get; set; }

        [GtfsProperty("to_stop_id", 2)]
        public string ToStopId { get; set; }

        [GtfsProperty("pathway_mode", 3)]
        public PathwayMode PathwayMode { get; set; }

        [GtfsProperty("is_bidirectional", 4)]
        public int IsBidirectional { get; set; }

        [GtfsProperty("length", 5)]
        public double? Length { get; set; }

        [GtfsProperty("traversal_time", 6)]
        public int? TraversalTime { get; set; }

        [GtfsProperty("stair_count", 7)]
        public int? StairCount { get; set; }

        [GtfsProperty("max_slope", 8)]
        public double? MaxSlope { get; set; }

        [GtfsProperty("min_width", 9)]
        public double? MinWidth { get; set; }

        [GtfsProperty("signposted_as", 10)]
        public string SignpostedAs { get; set; }

        [GtfsProperty("reversed_signposted_as", 11)]
        public string ReversedSignpostedAs { get; set; }
    }

}
