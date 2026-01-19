using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Associates stops with areas. Used in Fares V2 to define geographical zones 
    /// that are used to determine fare prices based on where a leg starts or ends.
    /// </summary>
    [GtfsFile("stop_areas.txt")]
    public class StopArea : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies the association. (Optional)
        /// </summary>
        [GtfsProperty("stop_area_id", 0)]
        [GtfsId]
        public string StopAreaId { get; set; }

        /// <summary>
        /// Identifies a stop or station. References <see cref="Stop.StopId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("stop_id", 1)]
        [GtfsReference<Stop>]
        public string StopId { get; set; }

        /// <summary>
        /// Identifies an area defined in areas.txt. 
        /// This area is used for calculating fare leg rules.
        /// (Required)
        /// </summary>
        [GtfsProperty("area_id", 2)]
        [GtfsReference<Area>]
        public string AreaId { get; set; }
    }
}