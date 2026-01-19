using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Provides metadata about the GTFS feed itself, including publisher information and validity dates.
    /// Corresponds to the feed_info.txt file.
    /// </summary>
    [GtfsFile("feed_info.txt")]
    public class FeedInfo : GtfsDataItem
    {
        /// <summary>
        /// Full name of the organization that publishes the feed.
        /// (Required)
        /// </summary>
        [GtfsProperty("feed_publisher_name", 0)]
        public string FeedPublisherName { get; set; }

        /// <summary>
        /// URL of the feed publishing organization's website.
        /// (Required)
        /// </summary>
        [GtfsProperty("feed_publisher_url", 1)]
        public string FeedPublisherUrl { get; set; }

        /// <summary>
        /// Default language used for text in this feed. 
        /// Represented as an IETF BCP 47 language tag (e.g., "en", "de").
        /// (Required)
        /// </summary>
        [GtfsProperty("feed_lang", 2)]
        public string FeedLanguage { get; set; }

        /// <summary>
        /// The date the feed becomes active in YYYYMMDD format.
        /// (Optional)
        /// </summary>
        [GtfsProperty("feed_start_date", 3)]
        public string FeedStartDate { get; set; }

        /// <summary>
        /// The date the feed expires in YYYYMMDD format.
        /// (Optional)
        /// </summary>
        [GtfsProperty("feed_end_date", 4)]
        public string FeedEndDate { get; set; }

        /// <summary>
        /// Version identifier for the feed provided by the publisher.
        /// (Optional)
        /// </summary>
        [GtfsProperty("feed_version", 5)]
        public string FeedVersion { get; set; }
    }
}