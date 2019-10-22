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

        public bool OffsetAndCheckCollision(Vector2 v1, Collider c2)
        {
            DummyCollider nCollider = new DummyCollider
            {
                Position = _Position.Position,
                Width = this.Width,
                Height = this.Height
            };
            nCollider.Position = Vector2.Add(nCollider.Position, v1);
            return nCollider.Intersects(c2);
        }

        public override bool Intersects(Collider c2)
        {
            return !(c2.Left > Right
                    || c2.Right < Left
                    || c2.Top > Bottom
                    || c2.Bottom < Top
                    );
        }

        private class DummyCollider
        {
            public Vector2 Position { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }



            public bool Intersects(Collider c2)
            {
                return !(c2.Left > Position.X+Width
                        || c2.Right < Position.X
                        || c2.Top > Position.Y+Height
                        || c2.Bottom < Position.Y
                        );
            }
        }
    }
}
