using Bunni.Resources.Modules;
using Bunni.Resources.Properties;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components
{
    public class Hitbox : Component
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private PositionVector _position;

        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, Width, Height);
            }
        }


        public Hitbox(Entity _parent) : base(_parent)
        {

        }

        public override void ComponentAdded()
        {
            PositionVector pos = Parent.GetProperty<PositionVector>();
            if (pos == null)
            {
                pos = new PositionVector(Parent);
                Parent.AddProperty(pos);
            }

            _position = pos;

            Render rend = Parent.GetComponent<Render>();
            if (rend != null)
            {
                Width = rend.Texture.Width;
                Height = rend.Texture.Height;
            }
        }

        public override void PreUpdate(GameTime gameTime)
        {
            Render rend = Parent.GetComponent<Render>();
            if (rend != null)
            {
                Width = rend.Texture.Width;
                Height = rend.Texture.Height;
            }
        }
    }
}
