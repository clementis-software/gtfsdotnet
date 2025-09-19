using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("transfers.txt")]
    public class Transfer : GtfsDataItem
    {
        [GtfsProperty("from_stop_id", 0)]
        public string FromStopId { get; set; }

        [GtfsProperty("to_stop_id", 1)]
        public string ToStopId { get; set; }

        [GtfsProperty("transfer_type", 2)]
        public TransferType TransferType { get; set; }

        [GtfsProperty("min_transfer_time", 3)]
        public int? MinTransferTime { get; set; }
    }

}
