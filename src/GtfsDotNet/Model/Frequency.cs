using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("frequencies.txt")]
    public class Frequency : GtfsDataItem
    {
        [GtfsProperty("trip_id", 0)]
        public string TripId { get; set; }

        [GtfsProperty("start_time", 1)]
        public string StartTime { get; set; }

        [GtfsProperty("end_time", 2)]
        public string EndTime { get; set; }

        [GtfsProperty("headway_secs", 3)]
        public int HeadwaySecs { get; set; }

        [GtfsProperty("exact_times", 4)]
        public ExactTimes? ExactTimes { get; set; }
    }
}
