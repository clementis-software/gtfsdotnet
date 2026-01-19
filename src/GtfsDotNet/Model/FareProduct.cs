using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a specific fare product (ticket, pass, etc.) that can be purchased by a rider.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsFile("fare_products.txt")]
    public class FareProduct : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a fare product.
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_product_id", 0)]
        [GtfsId]
        public string FareProductId { get; set; }

        /// <summary>
        /// Name of the fare product as displayed to riders (e.g., "Monthly Pass", "One-way Ticket").
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_product_name", 1)]
        public string FareProductName { get; set; }

        /// <summary>
        /// Description of the fare product to help distinguish it from others.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_product_desc", 2)]
        public string FareProductDescription { get; set; }

        /// <summary>
        /// Indicates the type of the fare product.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_product_type", 3)]
        public FareProductType FareProductType { get; set; }

        /// <summary>
        /// Price of the fare product.
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_product_price", 4)]
        public double FareProductPrice { get; set; }

        /// <summary>
        /// ISO 4217 alphabetical currency code for the price (e.g., USD, EUR).
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_product_currency", 5)]
        public string FareProductCurrency { get; set; }
    }
}