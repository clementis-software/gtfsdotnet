using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_products.txt")]
    public class FareProduct : GtfsDataItem
    {
        [GtfsProperty("fare_product_id", 0)]
        public string FareProductId { get; set; }

        [GtfsProperty("fare_product_name", 1)]
        public string FareProductName { get; set; }

        [GtfsProperty("fare_product_desc", 2)]
        public string FareProductDesc { get; set; }

        [GtfsProperty("fare_product_type", 3)]
        public FareProductType FareProductType { get; set; }

        [GtfsProperty("fare_product_price", 4)]
        public double FareProductPrice { get; set; }

        [GtfsProperty("fare_product_currency", 5)]
        public string FareProductCurrency { get; set; }
    }

}
