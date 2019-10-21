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

        public Render(Entity _parent, Texture2D _texture) : base(_parent, ComponentType.Render)
        {
            Texture = _texture;
            Color = Color.White;
        }

        public PositionVector getPosition()
        {
            return parent.GetProperty(PropertyType.PositionVector) as PositionVector;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, getPosition().Position, Color);
        }

    }
}
