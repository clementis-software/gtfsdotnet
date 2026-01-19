using GtfsDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents the transit agency that provides the data in this feed.
    /// Corresponds to the agency.txt file.
    /// </summary>
    [GtfsFile("agency.txt")]
    public class Agency : GtfsDataItem
    {
        /// <summary>
        /// Identifies a transit brand which is often synonymous with a transit agency. 
        /// Note: This is Required if the data contains more than one agency.
        /// </summary>
        [GtfsProperty("agency_id", 0)]
        [GtfsId]
        public string AgencyId { get; set; }

        /// <summary>
        /// Full name of the transit agency.
        /// (Required)
        /// </summary>
        [GtfsProperty("agency_name", 1)]
        public string AgencyName { get; set; }

        /// <summary>
        /// URL of the transit agency.
        /// (Required)
        /// </summary>
        [GtfsProperty("agency_url", 2)]
        public string AgencyUrl { get; set; }

        /// <summary>
        /// Timezone where the transit agency is located. If multiple agencies are specified in the same feed, 
        /// each must have the same agency_timezone.
        /// (Required)
        /// </summary>
        [GtfsProperty("agency_timezone", 3)]
        public string AgencyTimezone { get; set; }

        /// <summary>
        /// Primary language used by this transit agency.
        /// (Optional)
        /// </summary>
        [GtfsProperty("agency_lang", 4)]
        public string AgencyLanguage { get; set; }

        /// <summary>
        /// A single voice telephone number for the specified agency.
        /// (Optional)
        /// </summary>
        [GtfsProperty("agency_phone", 5)]
        public string AgencyPhone { get; set; }

        /// <summary>
        /// URL of a web page that allows a rider to purchase tickets or other fare instruments from that agency online.
        /// (Optional)
        /// </summary>
        [GtfsProperty("agency_fare_url", 6)]
        public string AgencyFareUrl { get; set; }

        /// <summary>
        /// A single valid email address actively monitored by the agency.
        /// (Optional)
        /// </summary>
        [GtfsProperty("agency_email", 7)]
        public string AgencyEmail { get; set; }
    }
}