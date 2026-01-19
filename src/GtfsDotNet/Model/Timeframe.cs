using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines time intervals used in Fares V2 to apply different fare rules 
    /// based on the time of day (e.g., Peak vs. Off-Peak pricing).
    /// </summary>
    [GtfsFile("timeframes.txt")]
    public class Timeframe : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a timeframe. This ID is referenced in fare_leg_rules.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("timeframe_id", 0)]
        [GtfsId]
        public string TimeframeId { get; set; }

        /// <summary>
        /// The start of the time interval in HH:MM:SS format.
        /// (Optional; if empty, the interval begins at the start of the service day)
        /// </summary>
        [GtfsProperty("start_time", 1)]
        public string StartTime { get; set; }

        /// <summary>
        /// The end of the time interval in HH:MM:SS format.
        /// (Optional; if empty, the interval ends at the end of the service day)
        /// </summary>
        [GtfsProperty("end_time", 2)]
        public string EndTime { get; set; }
    }
}