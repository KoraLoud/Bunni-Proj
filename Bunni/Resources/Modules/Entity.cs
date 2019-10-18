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
        
        /// <summary>
        /// Used to attach a component to an entity
        /// </summary>
        /// <param name="component">The component to attach</param>
        public void attachComponent(Component component)
        {
            Components.Add(component);
        }

        /// <summary>
        /// Used to detach a component from the entity. This will delete the component.
        /// </summary>
        /// <param name="componentType">The type of component to detatch</param>
        public void detatchComponent(ComponentType componentType)
        {
            Components.Remove(Components.Find(c => c.componentType.Equals(componentType)));
        }

        /// <summary>
        /// Returns a component, if it exists, that is attached to the entity.
        /// </summary>
        /// <param name="componentType">The type of component to retrieve</param>
        /// <returns>The component that was requested. Make sure to cast to desired class</returns>
        public Component getComponent(ComponentType componentType)
        {
            Component foundComponent = Components.Find(c => c.componentType.Equals(componentType));
            if (foundComponent != null)
            {
                return foundComponent;
            }
            else
            {
                throw new ArgumentException("This component is not attached to the Entity.");
            }
        }

        public void addProperty(Property p)
        {
            Properties.Add(p);
        }

        public void removeProperty(PropertyType pt)
        {
            Properties.Remove(Properties.Find(p => p.propertyType.Equals(pt)));
        }

        public Property getProperty(PropertyType pt)
        {
            Property foundProperty = Properties.Find(p => p.propertyType.Equals(pt));
            if(foundProperty != null)
            {
                return foundProperty;
            }else
            {
                throw new ArgumentException("The property was not found in the entity");
            }
            
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
