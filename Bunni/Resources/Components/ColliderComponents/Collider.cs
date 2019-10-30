using Bunni.Resources.Modules;
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
        public Vector2 Offset { get; set; } = Vector2.Zero;

        public int X
        {
            get
            {
                return (int)(_Position.X + Offset.X);
            }
            set
            {
                _Position.Position = new Vector2(value, _Position.Y);
            }
        }

        public int Y
        {
            get
            {
                return (int)(_Position.Y + Offset.Y);
            }
            set
            {
                _Position.Position = new Vector2(_Position.X, value);
            }
        }

        public override void ComponentAdded()
        {
            PositionVector pos = Parent.GetComponent<PositionVector>();
            if (pos == null)
            {
                pos = new PositionVector();
                Parent.AddComponent(pos);
            }
                
            _Position = pos;
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

        public virtual bool IntersectsOnLayer(Collider c2)
        {
            return false;
        }
    }
}
