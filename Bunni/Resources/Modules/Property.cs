using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class Property
    {
        public Entity Parent { get; set; }
        

        public Property(Entity _parent)
        {
            Parent = _parent;
        }
    }
}
