using GtfsDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet
{
    internal class GtfsDataMapper
    {
        public GtfsDataMapper(Type gtfsDataItemType)
        {
            var properties = gtfsDataItemType.GetProperties();

            Mappings = properties 
                .Where (x => x.GetMethod != null && x.SetMethod != null)
                .Select(x => new
                    {
                        PropertyInfo = x,
                        GtfsPropertyAttribute = x.GetCustomAttribute<GtfsPropertyAttribute>()
                    })
                .Where(x => x.GtfsPropertyAttribute?.PropertyName != null)
                .ToDictionary(x => x.GtfsPropertyAttribute.PropertyName, x => x.PropertyInfo);

            IdProperty = properties.FirstOrDefault(x => x.GetCustomAttribute<GtfsIdAttribute>() != null)    ;
        }

        public Dictionary<string, PropertyInfo> Mappings { get; }

        public PropertyInfo? IdProperty { get; }
    }
}
