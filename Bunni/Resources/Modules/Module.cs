using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class Module
    {
        public Entity Parent { get; set; }

        public Module(Entity _parent)
        {
            Parent = _parent;
        }
    }
}
