using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class Component
    {
        public virtual string Name { get; }
        public Entity parent { get; set; }
        public ComponentType componentType { get; set; }

        public Component(Entity _parent, ComponentType ct)
        {
            parent = _parent;
            componentType = ct;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

    }
}
