using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GtfsChildCollectionAttribute : Attribute
    {
        public GtfsChildCollectionAttribute(string idPropertyName)
        {
            IdPropertyName = idPropertyName;
        }

        internal string IdPropertyName { get; }
    }
}
