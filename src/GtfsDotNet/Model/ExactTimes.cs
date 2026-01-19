using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates whether the service operates on a fixed schedule or at regular intervals (headways).
    /// Typically used in frequencies.txt.
    /// </summary>
    [GtfsEnum]
    public enum ExactTimes
    {
        /// <summary>
        /// Frequency-based service. The headway values are only an indication, 
        /// and passengers are not provided with a fixed schedule for each stop.
        /// </summary>
        FrequencyBased = 0,

        /// <summary>
        /// Schedule-based service. The frequency definition is used as a shortcut 
        /// to define a fixed schedule where departures occur at regular intervals.
        /// </summary>
        ScheduleBased = 1
    }
}