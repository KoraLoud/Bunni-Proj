using Bunni.Resources.Modules;
using Bunni.Resources.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components.ColliderComponents
{
    /// <summary>
    /// The object that is the parent of all hitboxes
    /// </summary>
    public class Collision : Component
    {
        public CollisionLayers CollisionLayer { get; set; }
        protected PositionVector _position;


        public Collision(Entity _parent) : base(_parent)
        {

        }
    }
}
