using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Associates routes with networks. This allows for more complex fare structures where 
    /// pricing is based on the network the route belongs to.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsFile("route_networks.txt")]
    public class RouteNetwork : GtfsDataItem
    {
        /// <summary>
        /// Identifies a route that belongs to the network. 
        /// References <see cref="Route.RouteId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("route_id", 0)]
        [GtfsReference<Route>]
        public string RouteId { get; set; }

        /// <summary>
        /// Identifies the network associated with the route. 
        /// References <see cref="Network.NetworkId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("network_id", 1)]
        [GtfsReference<Network>]
        public string NetworkId { get; set; }
    }
}