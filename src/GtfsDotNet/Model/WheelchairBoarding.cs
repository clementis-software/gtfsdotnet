using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates whether wheelchair boardings are possible from the location.
    /// Used in stops.txt.
    /// </summary>
    [GtfsEnum]
    public enum WheelchairBoarding
    {
        /// <summary>
        /// For a stop: No accessibility information is available.
        /// For a station: The station's accessibility is inherited from its parent or follows a default.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// For a stop: At least some vehicles at this stop can be boarded by a rider in a wheelchair.
        /// For a station: There exists a step-free path from the street to the platforms.
        /// </summary>
        SomeAccessible = 1,

        /// <summary>
        /// Wheelchair boarding is not possible at this location, or there is no step-free path.
        /// </summary>
        NotAccessible = 2
    }
}