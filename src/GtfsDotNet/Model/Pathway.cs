using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a pathway within a station, such as a walkway, stairs, or elevator.
    /// Used for station navigation and accessibility information.
    /// </summary>
    [GtfsFile("pathways.txt")]
    public class Pathway : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies the pathway.
        /// (Required)
        /// </summary>
        [GtfsProperty("pathway_id", 0)]
        [GtfsId]
        public string PathwayId { get; set; }

        /// <summary>
        /// The <see cref="Stop.StopId"/> where the pathway begins.
        /// (Required)
        /// </summary>
        [GtfsProperty("from_stop_id", 1)]
        [GtfsReference<Stop>]
        public string FromStopId { get; set; }

        /// <summary>
        /// The <see cref="Stop.StopId"/> where the pathway ends.
        /// (Required)
        /// </summary>
        [GtfsProperty("to_stop_id", 2)]
        [GtfsReference<Stop>]
        public string ToStopId { get; set; }

        /// <summary>
        /// The type of pathway (e.g., walkway, elevator, escalator).
        /// (Required)
        /// </summary>
        [GtfsProperty("pathway_mode", 3)]
        public PathwayMode PathwayMode { get; set; }

        /// <summary>
        /// Indicates if the pathway can be used in both directions.
        /// 0: Unidirectional (from_stop_id to to_stop_id).
        /// 1: Bidirectional.
        /// (Required)
        /// </summary>
        [GtfsProperty("is_bidirectional", 4)]
        public int IsBidirectional { get; set; }

        /// <summary>
        /// Horizontal length of the pathway in meters.
        /// (Optional)
        /// </summary>
        [GtfsProperty("length", 5)]
        public double? Length { get; set; }

        /// <summary>
        /// Average time in seconds to traverse the pathway.
        /// (Optional)
        /// </summary>
        [GtfsProperty("traversal_time", 6)]
        public int? TraversalTime { get; set; }

        /// <summary>
        /// Number of stairs on the pathway. Positive for up, negative for down.
        /// (Optional)
        /// </summary>
        [GtfsProperty("stair_count", 7)]
        public int? StairCount { get; set; }

        /// <summary>
        /// Maximum slope (gradient) of the pathway.
        /// (Optional)
        /// </summary>
        [GtfsProperty("max_slope", 8)]
        public double? MaxSlope { get; set; }

        /// <summary>
        /// Minimum width of the pathway in meters.
        /// (Optional)
        /// </summary>
        [GtfsProperty("min_width", 9)]
        public double? MinWidth { get; set; }

        /// <summary>
        /// Text on signs that point in the direction from from_stop_id to to_stop_id.
        /// (Optional)
        /// </summary>
        [GtfsProperty("signposted_as", 10)]
        public string SignpostedAs { get; set; }

        /// <summary>
        /// Text on signs that point in the direction from to_stop_id to from_stop_id.
        /// (Optional)
        /// </summary>
        [GtfsProperty("reversed_signposted_as", 11)]
        public string ReversedSignpostedAs { get; set; }
    }
}