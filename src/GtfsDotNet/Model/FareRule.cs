using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_rules.txt")]
    public class FareRule : GtfsDataItem
    {
        [GtfsProperty("fare_id", 0)]
        public string FareId { get; set; }

        [GtfsProperty("route_id", 1)]
        public string RouteId { get; set; }

        [GtfsProperty("origin_id", 2)]
        public string OriginId { get; set; }

        [GtfsProperty("destination_id", 3)]
        public string DestinationId { get; set; }

        [GtfsProperty("contains_id", 4)]
        public string ContainsId { get; set; }
    }

}
