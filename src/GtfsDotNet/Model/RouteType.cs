using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Describes the type of transportation used on a route.
    /// These values correspond to the primary GTFS vehicle types.
    /// </summary>
    [GtfsEnum]
    public enum RouteType
    {
        /// <summary>
        /// Tram, Streetcar, Light rail. Any light rail or street level system within a metropolitan area.
        /// </summary>
        Tram = 0,

        /// <summary>
        /// Subway, Metro. Any underground rail system within a metropolitan area.
        /// </summary>
        Subway = 1,

        /// <summary>
        /// Rail. Used for intercity or long-distance travel.
        /// </summary>
        Rail = 2,

        /// <summary>
        /// Bus. Used for short- and long-distance bus routes.
        /// </summary>
        Bus = 3,

        /// <summary>
        /// Ferry. Used for short- and long-distance boat service.
        /// </summary>
        Ferry = 4,

        /// <summary>
        /// Cable tram. Used for street-level rail cars where the propelling cable runs beneath the street.
        /// </summary>
        CableTram = 5,

        /// <summary>
        /// Aerial lift, suspended cable car (e.g., gondola or chairlift).
        /// </summary>
        AerialLift = 6,

        /// <summary>
        /// Funicular. Any steep incline system that uses a cable for traction.
        /// </summary>
        Funicular = 7,

        /// <summary>
        /// Trolleybus. Electric buses that draw power from overhead wires using trolley poles.
        /// </summary>
        Trolleybus = 11,

        /// <summary>
        /// Monorail. Railway in which the track consists of a single rail or a beam.
        /// </summary>
        Monorail = 12
    }
}