using Bunni.Resources.Modules;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components.Physics
{
    public class Actor : Entity
    {

        private float xRemainder;
        private float yRemainder;

        private int Sign(int num)
        {
            return (num >= 0) ? 1 : -1;
        }

        public void MoveX(float distance, Action onCollide)
        {
            xRemainder = distance;
            int move = (int)Math.Round(xRemainder);

            if (move != 0)
            {
                xRemainder -= move;
                int sign = Sign(move);
                while (move != 0)
                {
                    if (!SceneManager.CurrentScene.CollideAt(new Rectangle((int)Transform.X+sign, (int)Transform.Y, Render.RenderRectangle.Width, Render.RenderRectangle.Height)))
                    {
                        Transform.X += sign;
                        move -= sign;
                    }
                    else
                    {
                        onCollide?.Invoke();
                        break;
                    }
                }
            }
        }

        public void MoveY(float distance, Action onCollide)
        {
            yRemainder = distance;
            int move = (int)Math.Round(yRemainder);

            if (move != 0)
            {
                yRemainder -= move;
                int sign = Sign(move);
                while (move != 0)
                {
                    if (!SceneManager.CurrentScene.CollideAt(new Rectangle((int)Transform.X,(int)Transform.Y+sign, Render.RenderRectangle.Width, Render.RenderRectangle.Height)))
                    {
                        Transform.Y += sign;
                        move -= sign;
                    }
                    else
                    {
                        onCollide?.Invoke();
                        break;
                    }
                }
            }
        }
    }
}
