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
    public class player1 : Entity //this is just ac lass for testing framework functionality
    {
        public int speed = 5;
        public player1(Texture2D tex)
        {
            this.AddProperty(new PositionVector(this));
            this.AddComponent(new Render(this, tex));
            Life nLife = new Life(this);
            this.AddProperty(nLife);
            KeyboardIn nInput = new KeyboardIn(this);
            nInput.SetDefaultKeyboardKeys();
            AddComponent(nInput);
            Hitbox nHitbox = new Hitbox(this);
            AddComponent(nHitbox);
        }

        public override void Update(GameTime gameTime)
        {

            KeyboardIn entIn = GetComponent<KeyboardIn>();
            PositionVector entPos = GetProperty<PositionVector>();
            Vector2 pos = entPos.Position;
            pos.X += entIn.InputVector.X*speed;
            pos.Y += entIn.InputVector.Y*speed;

            entPos.Position = pos;
            
            

            base.Update(gameTime);
        }
    }

}
