using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni
{
    public class Property
    {
        public Entity parent { get; set; }
        public PropertyType propertyType { get; set; }

        public Property(Entity _parent, PropertyType pt)
        {
            parent = _parent;
            propertyType = pt;
        }
    }
}
