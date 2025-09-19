using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("calendar.txt")]
    public class Calendar : GtfsDataItem
    {
        [GtfsProperty("service_id", 0)]
        public string ServiceId { get; set; }

        [GtfsProperty("monday", 1)]
        public int Monday { get; set; }

        [GtfsProperty("tuesday", 2)]
        public int Tuesday { get; set; }

        [GtfsProperty("wednesday", 3)]
        public int Wednesday { get; set; }

        [GtfsProperty("thursday", 4)]
        public int Thursday { get; set; }

        [GtfsProperty("friday", 5)]
        public int Friday { get; set; }

        [GtfsProperty("saturday", 6)]
        public int Saturday { get; set; }

        [GtfsProperty("sunday", 7)]
        public int Sunday { get; set; }

        [GtfsProperty("start_date", 8)]
        public string StartDate { get; set; }

        [GtfsProperty("end_date", 9)]
        public string EndDate { get; set; }
    }

}
