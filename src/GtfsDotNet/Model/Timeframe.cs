using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("timeframes.txt")]
    public class Timeframe : GtfsDataItem
    {
        [GtfsProperty("timeframe_id", 0)]
        public string TimeframeId { get; set; }

        [GtfsProperty("start_time", 1)]
        public string StartTime { get; set; }

        [GtfsProperty("end_time", 2)]
        public string EndTime { get; set; }
    }

}
