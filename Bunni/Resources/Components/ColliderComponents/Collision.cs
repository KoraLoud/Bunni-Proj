using Bunni.Resources.Modules;
using Bunni.Resources.Properties;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components.ColliderComponents
{
    /// <summary>
    /// The object that is the parent of all colliders
    /// </summary>
    public class Collision : Component
    {
        public CollisionLayers CollisionLayer { get; set; }
        protected PositionVector _Position { get; set; }
        protected Vector2 PositionOffset { get; set; } = Vector2.Zero;

    }
}
