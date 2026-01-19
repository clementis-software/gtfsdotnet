using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates the type of connection between two stops.
    /// Used by routing engines to determine if and how a transfer can be made.
    /// </summary>
    [GtfsEnum]
    public enum TransferType
    {
        /// <summary>
        /// Recommended transfer point between routes. 
        /// The router will calculate walking time based on distance.
        /// </summary>
        Recommended = 0,

        /// <summary>
        /// Timed transfer point. The departing vehicle will wait for the arriving 
        /// vehicle to allow for a guaranteed connection.
        /// </summary>
        Timed = 1,

        /// <summary>
        /// Transfer requires a minimum amount of time. 
        /// The time is specified in the <see cref="Transfer.MinTransferTime"/> field.
        /// </summary>
        MinimumTimeRequired = 2,

        /// <summary>
        /// Transfers between these stops are not possible. 
        /// Used to prevent the router from suggesting a transfer at this location.
        /// </summary>
        NotPossible = 3
    }
}