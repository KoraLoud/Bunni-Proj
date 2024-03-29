﻿using Bunni.Resources.Components;
using Bunni.Resources.Components.Physics;
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
        public List<Solid> Solids = new List<Solid>();
        public List<Actor> Actors = new List<Actor>();

        public Boolean CollideAt(Rectangle hitbox)
        {
            foreach(Solid solid in Solids)
            {
                if(solid.Intersects(hitbox))
                {
                    return true;
                }
            }
            return false;
        }

        private Action onLoad;

        public void SetOnLoad(Action callback)
        {
            onLoad = callback;
        }

        public void Load()
        {
            onLoad?.Invoke();
        }

        /// <summary>
        /// Adds an entity to the scene
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        public void AddEntity(Entity entity)
        {
            SceneEntities.Add(entity);
            SortEntities();
        }

        /// <summary>
        /// Removes an entity from the scene
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        public void RemoveEntity(Entity entity)
        {
            SceneEntities.Remove(entity);
        }


        public virtual void PreUpdate(GameTime gameTime)
        {
            foreach (Entity e in SceneEntities.ToList())
            {
                e.PreUpdate(gameTime, this);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Entity e in SceneEntities.ToList())
            {
                e.Update(gameTime, this);
            }
        }

        public virtual void PostUpdate(GameTime gameTime)
        {
            foreach (Entity e in SceneEntities.ToList())
            {
                e.PostUpdate(gameTime, this);
            }
        }

        private static int SortByZ(Entity x, Entity y)
        {
            Render xComponent = x.Render;
            Render yComponent = y.Render;
            if (xComponent.ZLayer > yComponent.ZLayer)
            {
                return -1;
            }
            else if (xComponent.ZLayer < yComponent.ZLayer)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void SortEntities()
        {
            SceneEntities.Sort(SortByZ);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var e in SceneEntities)
            {
                e.Draw(gameTime, spriteBatch);
            }
        }
    }
}
