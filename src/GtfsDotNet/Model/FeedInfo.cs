using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("feed_info.txt")]
    public class FeedInfo : GtfsDataItem
    {
        [GtfsProperty("feed_publisher_name", 0)]
        public string FeedPublisherName { get; set; }

        [GtfsProperty("feed_publisher_url", 1)]
        public string FeedPublisherUrl { get; set; }

        [GtfsProperty("feed_lang", 2)]
        public string FeedLanguage { get; set; }

        [GtfsProperty("feed_start_date", 3)]
        public string FeedStartDate { get; set; }

        [GtfsProperty("feed_end_date", 4)]
        public string FeedEndDate { get; set; }

        [GtfsProperty("feed_version", 5)]
        public string FeedVersion { get; set; }
    }
}
