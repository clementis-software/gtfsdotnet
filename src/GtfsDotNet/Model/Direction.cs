using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates the direction of travel for a trip. 
    /// Used to distinguish between parts of the same route (e.g., outbound vs. inbound).
    /// </summary>
    [GtfsEnum]
    public enum Direction
    {
        /// <summary>
        /// Outbound travel (e.g., travel to the city or from a central point).
        /// Usually used for one direction of service.
        /// </summary>
        Outbound = 0,

        /// <summary>
        /// Inbound travel (e.g., travel from the city or towards a central point).
        /// Usually used for the opposite direction of service.
        /// </summary>
        Inbound = 1
    }
}