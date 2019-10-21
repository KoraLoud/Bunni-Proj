using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class Scene
    {
        public List<Entity> SceneEntities = new List<Entity>();

        public void AddEntity(Entity _entity)
        {
            SceneEntities.Add(_entity);
        }

        public void RemoveEntity(Entity _entity)
        {
            SceneEntities.Remove(_entity);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(var e in SceneEntities)
            {
                e.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var e in SceneEntities)
            {
                e.Draw(gameTime, spriteBatch);
            }
        }
    }
}
