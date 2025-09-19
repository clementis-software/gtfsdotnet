using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("route_networks.txt")]
    public class RouteNetwork : GtfsDataItem
    {
        [GtfsProperty("route_id", 0)]
        public string RouteId { get; set; }

        [GtfsProperty("network_id", 1)]
        public string NetworkId { get; set; }
    }

}
