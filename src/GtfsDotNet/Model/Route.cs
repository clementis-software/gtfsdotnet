using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a transit route. A route is a group of trips that are displayed 
    /// to riders as a single service.
    /// Corresponds to the routes.txt file.
    /// </summary>
    [GtfsFile("routes.txt")]
    public class Route : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a route. This ID is used across the dataset to 
        /// associate trips and fares with this specific route.
        /// (Required)
        /// </summary>
        [GtfsProperty("route_id", 0)]
        [GtfsId]
        public string RouteId { get; set; }

        /// <summary>
        /// Identifies the agency that operates the route. 
        /// References <see cref="Agency.AgencyId"/>.
        /// (Optional/Required if multiple agencies exist)
        /// </summary>
        [GtfsProperty("agency_id", 1)]
        [GtfsReference<Agency>]
        public string AgencyId { get; set; }

        [GtfsReferenceProperty(nameof(AgencyId))]
        public Agency Agency { get; set; }

        /// <summary>
        /// Short name of the route (e.g., "M41", "U2"). 
        /// Usually a number or a short code.
        /// (Required - either ShortName or LongName must be provided)
        /// </summary>
        [GtfsProperty("route_short_name", 2)]
        public string ShortName { get; set; }

        /// <summary>
        /// Long name of the route (e.g., "Airport Express", "Ringbahn").
        /// (Required - either ShortName or LongName must be provided)
        /// </summary>
        [GtfsProperty("route_long_name", 3)]
        public string LongName { get; set; }

        /// <summary>
        /// Full description of the route that provides useful, additional information.
        /// (Optional)
        /// </summary>
        [GtfsProperty("route_desc", 4)]
        public string Description { get; set; }

        /// <summary>
        /// Indicates the type of vehicle used on this route (e.g., Bus, Rail, Subway).
        /// References the <see cref="RouteType"/> enum.
        /// (Required)
        /// </summary>
        [GtfsProperty("route_type", 5)]
        public RouteType RouteType { get; set; }

        /// <summary>
        /// URL of a web page about that particular route.
        /// (Optional)
        /// </summary>
        [GtfsProperty("route_url", 6)]
        public string RouteUrl { get; set; }

        /// <summary>
        /// Route color as a 6-character hexadecimal number (e.g., FF0000 for Red).
        /// (Optional)
        /// </summary>
        [GtfsProperty("route_color", 7)]
        public string Color { get; set; }

        /// <summary>
        /// Route text color as a 6-character hexadecimal number. 
        /// Should provide high contrast with the route_color.
        /// (Optional)
        /// </summary>
        [GtfsProperty("route_text_color", 8)]
        public string TextColor { get; set; }
    }
}