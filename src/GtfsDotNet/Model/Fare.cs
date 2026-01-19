using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines fare information for a transit organization's routes.
    /// Corresponds to the fare_attributes.txt file.
    /// </summary>
    [GtfsFile("fare_attributes.txt")]
    public class Fare : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a fare class.
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_id", 0)]
        [GtfsId]
        public string FareId { get; set; }

        /// <summary>
        /// Fare price, in the unit specified by <see cref="CurrencyType"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("price", 1)]
        public double Price { get; set; }

        /// <summary>
        /// ISO 4217 alphabetical currency code (e.g., USD, EUR, JPY).
        /// (Required)
        /// </summary>
        [GtfsProperty("currency_type", 2)]
        public string CurrencyType { get; set; }

        /// <summary>
        /// Indicates when the fare must be paid.
        /// (Required)
        /// </summary>
        [GtfsProperty("payment_method", 3)]
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Indicates the number of transfers permitted on this fare.
        /// 0 - No transfers permitted.
        /// 1 - Passenger may transfer once.
        /// 2 - Passenger may transfer twice.
        /// Empty - Unlimited transfers are permitted.
        /// (Required)
        /// </summary>
        [GtfsProperty("transfers", 4)]
        public int Transfers { get; set; }

        /// <summary>
        /// Identifies the relevant agency for this fare. 
        /// Note: Required if the data contains more than one agency.
        /// </summary>
        [GtfsProperty("agency_id", 5)]
        [GtfsReference<Agency>]
        public string AgencyId { get; set; }

        [GtfsReferenceProperty(nameof(AgencyId))]
        public Agency Agency { get; set; }

        /// <summary>
        /// Identifies a jurisdiction for the fare. Part of the Fares V2 extension.
        /// (Optional)
        /// </summary>
        [GtfsProperty("jurisdiction_id", 6)]
        public string JurisdictionId { get; set; }
    }
}