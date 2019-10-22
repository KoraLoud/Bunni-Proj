using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunni.Resources.Modules;
using Bunni.Resources.Properties;

namespace Bunni.Resources.Components

{
    public class Render : Component
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        private PositionVector _position { get; set; }

        public Render(Entity _parent, Texture2D _texture) : base(_parent)
        {
            Texture = _texture;
            Color = Color.White;

            PositionVector pos = Parent.GetProperty<PositionVector>();
            _position = pos;
        }

        public override void Update(GameTime gameTime, Scene scene)
        {
            _position = Parent.GetProperty<PositionVector>();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Parent.Visible)
            {
                spriteBatch.Draw(Texture, _position.Position, Color);
            }
            
        }

    }
}
