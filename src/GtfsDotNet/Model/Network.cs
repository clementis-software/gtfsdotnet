using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("networks.txt")]
    public class Network : GtfsDataItem
    {
        [GtfsProperty("network_id", 0)]
        public string NetworkId { get; set; }

        [GtfsProperty("network_name", 1)]
        public string NetworkName { get; set; }

        [GtfsProperty("network_desc", 2)]
        public string NetworkDesc { get; set; }
    }
}
