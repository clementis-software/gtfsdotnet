using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a transit network, which is a group of routes. 
    /// Primarily used in Fares V2 to apply fare rules to an entire network of services.
    /// </summary>
    [GtfsFile("networks.txt")]
    public class Network : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a network. This ID is referenced in routes.txt 
        /// or fare_leg_rules.txt to associate them with this network.
        /// (Required)
        /// </summary>
        [GtfsProperty("network_id", 0)]
        [GtfsId]
        public string NetworkId { get; set; }

        /// <summary>
        /// Full name of the network as displayed to riders (e.g., "MVV", "Transport for London").
        /// (Optional)
        /// </summary>
        [GtfsProperty("network_name", 1)]
        public string NetworkName { get; set; }

        /// <summary>
        /// Description of the network to help distinguish it from others.
        /// (Optional)
        /// </summary>
        [GtfsProperty("network_desc", 2)]
        public string NetworkDescription { get; set; }
    }
}