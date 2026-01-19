using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsDotNet.Attributes
{
    [AttributeUsage( AttributeTargets.Property)]
    public class GtfsReferencePropertyAttribute : Attribute
    {
        public GtfsReferencePropertyAttribute(string idPropertyName)
        {
            IdPropertyName = idPropertyName;
        }

        internal string IdPropertyName { get; }
    }
}
