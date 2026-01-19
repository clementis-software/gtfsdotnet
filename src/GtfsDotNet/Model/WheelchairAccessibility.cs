using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates whether the vehicle used for a specific trip can accommodate at least one rider in a wheelchair.
    /// Used in trips.txt.
    /// </summary>
    [GtfsEnum]
    public enum WheelchairAccessibility
    {
        /// <summary>
        /// No accessibility information is available for this trip.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The vehicle for this trip can accommodate at least one rider in a wheelchair.
        /// </summary>
        Accessible = 1,

        /// <summary>
        /// No riders in wheelchairs can be accommodated on this trip.
        /// </summary>
        NotAccessible = 2
    }
}