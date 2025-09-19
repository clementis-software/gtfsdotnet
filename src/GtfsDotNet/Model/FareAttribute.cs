using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_attributes.txt")]
    public class FareAttribute : GtfsDataItem
    {
        [GtfsProperty("fare_id", 0)]
        public string FareId { get; set; }

        [GtfsProperty("price", 1)]
        public double Price { get; set; }

        [GtfsProperty("currency_type", 2)]
        public string CurrencyType { get; set; }

        [GtfsProperty("payment_method", 3)]
        public PaymentMethod PaymentMethod { get; set; }

        [GtfsProperty("transfers", 4)]
        public int Transfers { get; set; }

        [GtfsProperty("agency_id", 5)]
        public string AgencyId { get; set; }

        [GtfsProperty("jurisdiction_id", 6)]
        public string JurisdictionId { get; set; }
    }

}
