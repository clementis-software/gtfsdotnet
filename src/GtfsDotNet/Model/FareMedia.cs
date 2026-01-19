using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents the physical or digital media on which a fare product can be stored.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsFile("fare_media.txt")]
    public class FareMedia : GtfsDataItem
    {
        /// <summary>
        /// Identifies a fare media. The ID must be unique within the dataset.
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_media_id", 0)]
        [GtfsId]
        public string FareMediaId { get; set; }

        /// <summary>
        /// Name of the fare media as displayed to riders (e.g., "Clipper card", "Mobile App", "Paper Ticket").
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_media_name", 1)]
        public string FareMediaName { get; set; }

        /// <summary>
        /// Description of the fare media to help distinguish it from others.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_media_desc", 2)]
        public string FareMediaDescription { get; set; }
    }
}