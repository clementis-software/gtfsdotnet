using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("routes.txt")]
    public class Route : GtfsDataItem
    {
        [GtfsProperty("route_id", 0)]
        public string RouteId { get; set; }

        [GtfsProperty("agency_id", 1)]
        public string AgencyId { get; set; }

        [GtfsProperty("route_short_name", 2)]
        public string ShortName { get; set; }

        [GtfsProperty("route_long_name", 3)]
        public string LongName { get; set; }

        [GtfsProperty("route_desc", 4)]
        public string Description { get; set; }

        [GtfsProperty("route_type", 5)]
        public RouteType RouteType { get; set; }

        [GtfsProperty("route_url", 6)]
        public string RouteUrl { get; set; }

        [GtfsProperty("route_color", 7)]
        public string Color { get; set; }

        [GtfsProperty("route_text_color", 8)]
        public string TextColor { get; set; }
    }

}
