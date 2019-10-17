using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Bunni
{
    public class img : Entity
    {
        public int speed = 5;
        public img(Texture2D tex)
        {
            this.addProperty(new PositionVector(this));
            this.attachComponent(new Render(this, tex));
            Input nInput = new Input(this);
            nInput.SetDefaultKeyboardKeys().BindKey(Keys.LeftShift, (pressed, held) => 
            {
                if(pressed || held)
                {
                    speed = 1;
                }else
                {
                    speed = 5;
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
