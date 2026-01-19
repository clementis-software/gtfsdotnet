using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates the type of the location specified in stops.txt.
    /// This defines the hierarchy and functional role of a transit point.
    /// </summary>
    [GtfsEnum]
    public enum LocationType
    {
        /// <summary>
        /// A stop or platform. A location where passengers board or alight from a vehicle.
        /// Must have a parent_station if it is part of a larger station.
        /// </summary>
        StopOrPlatform = 0,

        /// <summary>
        /// A station. A physical structure or area that contains one or more platforms.
        /// </summary>
        Station = 1,

        /// <summary>
        /// A designated entrance or exit from a station.
        /// </summary>
        EntranceExit = 2,

        /// <summary>
        /// A generic node. Used for internal station navigation (e.g., a junction in a pathway).
        /// </summary>
        GenericNode = 3,

        /// <summary>
        /// A specific boarding area on a platform (e.g., a specific door location or car position).
        /// </summary>
        BoardingArea = 4
    }
}