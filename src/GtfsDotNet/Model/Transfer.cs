using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines the rules and connection times for transferring between stops.
    /// Used by routing engines to calculate viable itineraries involving vehicle changes.
    /// </summary>
    [GtfsFile("transfers.txt")]
    public class Transfer : GtfsDataItem
    {
        /// <summary>
        /// Identifies the stop or station where the transfer begins.
        /// References <see cref="Stop.StopId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("from_stop_id", 0)]
        [GtfsReference<Stop>]
        public string FromStopId { get; set; }

        /// <summary>
        /// Identifies the stop or station where the transfer ends.
        /// References <see cref="Stop.StopId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("to_stop_id", 1)]
        [GtfsReference<Stop>]
        public string ToStopId { get; set; }

        /// <summary>
        /// Indicates the type of transfer and the level of connection guarantee.
        /// References the <see cref="TransferType"/> enum.
        /// (Required)
        /// </summary>
        [GtfsProperty("transfer_type", 2)]
        public TransferType TransferType { get; set; }

        /// <summary>
        /// The minimum time in seconds required to complete the transfer.
        /// This accounts for walking time or platform changes.
        /// (Optional; used mainly when TransferType is 2)
        /// </summary>
        [GtfsProperty("min_transfer_time", 3)]
        public int? MinTransferTime { get; set; }
    }
}