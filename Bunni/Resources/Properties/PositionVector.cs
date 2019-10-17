using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni
{
    public class PositionVector : Property
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public PositionVector(Entity _parent) : base(_parent, PropertyType.PositionVector)
        {
            Position = Vector2.Zero;
        }



    }
}
