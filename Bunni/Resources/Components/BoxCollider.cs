using Bunni.Resources.Components.ColliderComponents;
using Bunni.Resources.Modules;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components
{
    public class BoxCollider : Collider
    {

        public int Width { get; set; }
        public int Height { get; set; }

        public override int Bottom
        {
            get
            {
                return Y + Height;
            }
        }

        public override int Left
        {
            get
            {
                return X;
            }
        }

        public override int Top
        {
            get
            {
                return Y;
            }
        }

        public override int Right
        {
            get
            {
                return X + Width;
            }
        }

        public override void ComponentAdded()
        {
            base.ComponentAdded();
            Render rend = Parent.GetComponent<Render>();
            if (rend != null)
            {
                Width = rend.Texture.Width;
                Height = rend.Texture.Height;
            }
        }

        public override void PreUpdate(GameTime gameTime, Scene scene)
        {
            Render rend = Parent.GetComponent<Render>();
            if (rend != null)
            {
                Width = rend.Texture.Width;
                Height = rend.Texture.Height;
            }
        }

        public override bool Intersects(Collider c2)
        {
            return !(c2.Left > Right
                    || c2.Right < Left
                    || c2.Top > Bottom
                    || c2.Bottom < Top
                    );
        }

        public override bool IntersectsOnLayer(Collider c2)
        {
            if(CollisionLayer == c2.CollisionLayer)
            {
                return Intersects(c2);
            }else
            {
                return false;
            }
        }

    }
}
