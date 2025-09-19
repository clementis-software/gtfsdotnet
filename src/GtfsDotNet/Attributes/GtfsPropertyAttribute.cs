using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GtfsPropertyAttribute(string propertyName, int indexAccordingToSpecification) : Attribute
    {
        public string PropertyName => propertyName;
        public int IndexAccordingToSpecification => indexAccordingToSpecification;
    }
}
