using Bunni.Resources.Modules;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bunni.Resources.Components.Collision
{
    /// <summary>
    /// The collider parent object that handles detecting collisions
    /// </summary>
    public class Collider : Component
    {

        public Vector2 Offset { get; set; } = Vector2.Zero;
        public ICollider Hitbox { get; set; }
        public BniTypes.CollisionLayer CollisionLayer { get; set; }
        public PositionVector PositionC { get; set; }
        protected Vector2 PositionOffset { get; set; } = Vector2.Zero;

        public int X
        {
            get
            {
                return (int)(PositionC.X + Offset.X);
            }
            set
            {
                PositionC.Position = new Vector2(value, PositionC.Y);
            }
        }

        public int Y
        {
            get
            {
                return (int)(PositionC.Y + Offset.Y);
            }
            set
            {
                PositionC.Position = new Vector2(PositionC.X, value);
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

            PositionC = pos;
            if(Hitbox != null)
            {
                Hitbox.ComponentAdded();
            }
            
        }

        public void CreateHitbox<T>() where T : ICollider, new()
        {
            Hitbox = new T
            {
                Parent = this
            };
            if(Parent != null)
            {
                Hitbox.ComponentAdded();
            }
        }

        public bool Intersects(ICollider c2)
        {
            return Hitbox.Intersects(c2);
        }

        public bool IntersectsOnLayer(ICollider c2)
        {
            return Hitbox.IntersectsOnLayer(c2);
        }

        public bool IntersectsWithTag(ICollider c2)
        {
            return Hitbox.IntersectsWithTag(c2);
        }



        public bool Intersects(Collider c2)
        {
            return Hitbox.Intersects(c2.Hitbox);
        }

        public bool IntersectsOnLayer(Collider c2)
        {
            return Hitbox.IntersectsOnLayer(c2.Hitbox);
        }

        public bool IntersectsWithTag(Collider c2)
        {
            return Hitbox.IntersectsWithTag(c2.Hitbox);
        }

    }
}
