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
        private Rectangle _hitBox;

        public Rectangle Box
        {
            get
            {
                return _hitBox;
            }
            set
            {
                _hitBox = new Rectangle((int)_position.X, (int)_position.Y, Width, Height);
            }
        }

        public Hitbox(Entity _parent) : base(_parent)
        {
            PositionVector pos = Parent.GetProperty<PositionVector>();
            if(pos == null)
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
    }
}
