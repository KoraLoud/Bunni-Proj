using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bunni.Resources.Modules
{
    public class Entity
    {
        private List<Component> Components = new List<Component>();
        private List<Property> Properties = new List<Property>();
        public bool OnScreen { get; set; }
        public bool Active { get; set; } = true;
        
        /// <summary>
        /// Used to attach a component to an entity
        /// </summary>
        /// <param name="component">The component to attach</param>
        public void AttachComponent(Component component)
        {
            Components.Add(component);
        }

        /// <summary>
        /// Used to detach a component from the entity. This will delete the component.
        /// </summary>
        /// <param name="componentType">The type of component to detatch</param>
        public void DetatchComponent(Component component)
        {
            //Components.Remove(Components.Find(c => c.componentType.Equals(componentType)));
            Components.Remove(component);
        }

        /// <summary>
        /// Returns a component, if it exists, that is attached to the entity.
        /// </summary>
        /// <param name="componentType">The type of component to retrieve</param>
        /// <returns>The component that was requested. Make sure to cast to desired class</returns>
        public T GetComponent<T>() where T :  Component
        {
            foreach(var c in Components)
            {
                if(c is T)
                {
                    return c as T;
                }
            }
            return null;
        }

        public void AddProperty(Property p)
        {
            Properties.Add(p);
        }

        public void RemoveProperty(Property p)
        {
            Properties.Remove(p);
        }

        public T GetProperty<T>() where T : Property
        {
            foreach(var p in Properties)
            {
                if(p is T)
                {
                    return p as T;
                }
            }
            return null;
            
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Component component in Components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
    }
}
