using Bunni.Resources.Modules;
using Bunni.Resources.Properties;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bunni.Resources.Components.ColliderComponents
{
    /// <summary>
    /// The collider parent object that handles detecting collisions
    /// </summary>
    public class Collider : Collision
    {

        public virtual int Bottom { get; }
        public virtual int Left { get;}
        public virtual int Top { get;}
        public virtual int Right { get;}

        public int X
        {
            get
            {
                return (int)_position.X;
            }
            set
            {
                _position.Position = new Vector2(value, _position.Y);
            }
        }

        public int Y
        {
            get
            {
                return (int)_position.Y;
            }
            set
            {
                _position.Position = new Vector2(_position.X, value);
            }
        }



        public Collider(Entity _parent) : base(_parent)
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
        }

        /// <summary>
        /// override this method!!!
        /// </summary>
        /// <param name="c2"></param>
        /// <returns></returns>
        public virtual bool Intersects(Collider c2)
        {
            
            return false;
        }
    }
}
