using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunni.Resources.Modules;

namespace Bunni.Resources.Components

{
    public class Render : Component
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        private PositionVector _position { get; set; }

        public Render(Texture2D _texture)
        {
            Texture = _texture;
            Color = Color.White;
        }

        public override void ComponentAdded()
        {
            PositionVector pos = Parent.GetComponent<PositionVector>();
            _position = pos;
        }

        public override void Update(GameTime gameTime, Scene scene)
        {
            _position = Parent.GetComponent<PositionVector>();
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
