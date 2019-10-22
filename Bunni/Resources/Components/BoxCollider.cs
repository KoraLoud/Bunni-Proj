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

        public BoxCollider(Entity _parent) : base(_parent)
        {

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

        public BoxCollider Add(Vector2 v1)
        {
            //fix this
            BoxCollider nCollider = new BoxCollider(Parent);
            nCollider._position.Position = new Vector2(_position.X, _position.Y);
            nCollider._position.Position = Vector2.Add(nCollider._position.Position, v1);
            return nCollider;
        }

        public override bool Intersects(Collider c2)
        {
            return !(c2.Left > Right
                    || c2.Right < Left
                    || c2.Top > Bottom
                    || c2.Bottom < Top
                    );
        }
    }
}
