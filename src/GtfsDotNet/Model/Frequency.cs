using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents headway-based service (intervals) rather than a fixed individual trip schedule.
    /// Corresponds to the frequencies.txt file.
    /// </summary>
    [GtfsFile("frequencies.txt")]
    public class Frequency : GtfsDataItem
    {
        /// <summary>
        /// Identifies the trip to which the frequency interval applies.
        /// (Required)
        /// </summary>
        [GtfsProperty("trip_id", 0)]
        [GtfsReference<Trip>]
        public string TripId { get; set; }

        /// <summary>
        /// Time at which the first vehicle departs in the specified frequency, in HH:MM:SS format.
        /// (Required)
        /// </summary>
        [GtfsProperty("start_time", 1)]
        public string StartTime { get; set; }

        /// <summary>
        /// Time at which the service changes to a different frequency or ends, in HH:MM:SS format.
        /// (Required)
        /// </summary>
        [GtfsProperty("end_time", 2)]
        public string EndTime { get; set; }

        /// <summary>
        /// Time between departures from the same stop (in seconds).
        /// (Required)
        /// </summary>
        [GtfsProperty("headway_secs", 3)]
        public int HeadwaySecs { get; set; }

        /// <summary>
        /// Indicates if the frequency is a exact schedule or just a headway-based estimate.
        /// References the <see cref="ExactTimes"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("exact_times", 4)]
        public ExactTimes? ExactTimes { get; set; }
    }
}