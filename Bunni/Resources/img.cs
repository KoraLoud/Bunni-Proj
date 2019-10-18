using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Bunni.Resources.Modules;
using Bunni.Resources.Properties;
using Bunni.Resources.Components;

namespace Bunni
{
    public class img : Entity
    {
        public int speed = 5;
        public img(Texture2D tex)
        {
            this.addProperty(new PositionVector(this));
            this.attachComponent(new Render(this, tex));
            Life nLife = new Life(this);
            this.addProperty(nLife);
            Input nInput = new Input(this);
            nInput.SetDefaultKeyboardKeys().BindKey(Keys.LeftShift, (pressed, held) => 
            {
                if(pressed || held)
                {
                    speed = 1;
                    nLife.Damage(1);
                    if (!nLife.IsAlive)
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.Red;
                    }else
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.Orange;
                    }
                }else
                {
                    if (nLife.IsAlive)
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.White;
                    }
                    speed = 5;
                }
            });
            nInput.BindKey(Keys.Space, (pressed, held) =>
            {
                if(pressed || held)
                {
                    nLife.Heal(1);
                    if(!nLife.HasMaxHealth())
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.Green;
                    }else
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.Turquoise;
                    }
                    
                }else
                {
                    if (nLife.IsAlive && !nInput.KeyIsHeld(Keys.LeftShift))
                    {
                        (this.getComponent(ComponentType.Render) as Render).color = Color.White;
                    }
                }
            });
            attachComponent(nInput);
        }

        public override void Update(GameTime gameTime)
        {
            
            Input entIn = getComponent(ComponentType.Input) as Input;
            PositionVector entPos = getProperty(PropertyType.PositionVector) as PositionVector;
            Vector2 pos = entPos.Position;
            pos.X += entIn.InputVector.X*speed;
            pos.Y += entIn.InputVector.Y*speed;

            entPos.Position = pos;
            //Console.WriteLine(pos);
            base.Update(gameTime);
        }
    }

}
