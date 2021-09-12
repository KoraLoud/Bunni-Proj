using Bunni.Resources.Modules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bunni.Resources.Components.Physics
{
    public class Solid : Entity
    {
        public Boolean CanCollide { get; set; } = true;

        public Boolean Intersects(Rectangle hitbox)
        {
            if(Render.RenderRectangle.Intersects(hitbox) && CanCollide)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Solid() : base()
        {

        }

        public Solid(Texture2D tex) : base(tex)
        {

        }
    }
}
