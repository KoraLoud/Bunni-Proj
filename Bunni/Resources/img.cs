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
            this.AddProperty(new PositionVector(this));
            this.AttachComponent(new Render(this, tex));
            Life nLife = new Life(this);
            this.AddProperty(nLife);
            Input nInput = new Input(this);
            nInput.SetDefaultKeyboardKeys().BindKey(Keys.LeftShift, (pressed, held) => 
            {
                if(pressed || held)
                {
                    speed = 1;
                    nLife.Damage(1);
                    //Console.WriteLine(nLife.Health);
                    if (!nLife.IsAlive)
                    {
                        GetComponent<Render>().Color = Color.Red;
                    }else
                    {
                        GetComponent<Render>().Color = Color.Orange;
                    }
                }else
                {
                    if (nLife.IsAlive)
                    {
                        GetComponent<Render>().Color = Color.White;
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
                        GetComponent<Render>().Color = Color.Green;
                    }else
                    {
                        GetComponent<Render>().Color = Color.Turquoise;
                    }
                    
                }else
                {
                    if (nLife.IsAlive && !nInput.KeyIsHeld(Keys.LeftShift))
                    {
                        GetComponent<Render>().Color = Color.White;
                    }
                }
            });
            AttachComponent(nInput);
        }

        public override void Update(GameTime gameTime)
        {

            Input entIn = GetComponent<Input>();
            PositionVector entPos = GetProperty<PositionVector>();
            Vector2 pos = entPos.Position;
            pos.X += entIn.InputVector.X*speed;
            pos.Y += entIn.InputVector.Y*speed;

            entPos.Position = pos;
            //Console.WriteLine(pos);
            base.Update(gameTime);
        }
    }

}
