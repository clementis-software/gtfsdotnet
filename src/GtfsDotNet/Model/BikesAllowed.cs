using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates whether bikes are allowed on the trip.
    /// Based on the GTFS Schedule Reference for the 'bikes_allowed' field.
    /// </summary>
    [GtfsEnum]
    public enum BikesAllowed
    {
        /// <summary>
        /// No bike information is available for this trip.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The vehicle being used on this particular trip can accommodate at least one bicycle.
        /// </summary>
        Allowed = 1,

        /// <summary>
        /// No bicycles are allowed on this trip.
        /// </summary>
        NotAllowed = 2
    }
}