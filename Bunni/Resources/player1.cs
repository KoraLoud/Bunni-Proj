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
using Bunni.Resources.Components.ColliderComponents;

namespace Bunni
{
    public class player1 : Entity //this is just a class for testing framework functionality
    {
        public int speed = 5;
        public player1(Texture2D tex)
        {
            AddProperty(new PositionVector(this));
            AddComponent(new Render(this, tex));
            Life nLife = new Life(this);
            AddProperty(nLife);
            KeyboardIn nInput = new KeyboardIn(this);
            nInput.SetDefaultKeyboardKeys();
            AddComponent(nInput);
            BoxCollider nHitbox = new BoxCollider(this);
            AddComponent(nHitbox);
        }

        public override void Update(GameTime gameTime, Scene scene)
        {

            KeyboardIn entIn = GetComponent<KeyboardIn>();
            PositionVector entPos = GetProperty<PositionVector>();
            Vector2 pos = new Vector2(entIn.InputVector.X * speed, entIn.InputVector.Y * speed);

            scene.SceneEntities.ForEach((e) =>
            {
                if (e != this)
                {
                    if (e.GetComponent<BoxCollider>() != null)
                    {
                            //Console.WriteLine("collider gotteenn");

                    BoxCollider futureBox = GetComponent<BoxCollider>().Add(pos);

                    if (futureBox.Intersects(e.GetComponent<BoxCollider>()))
                    {
                       // pos = new Vector2(0, 0);
                        
                    }
                    }
                    else
                    {
                        Console.WriteLine("No collider!");
                    }
                }

            });
            Console.WriteLine(entPos.Position);
            //Console.WriteLine(pos.X);
            //entPos.Position = new Vector2(entPos.Position.X + pos.X, entPos.Position.Y + pos.Y);
            
            

            base.Update(gameTime, scene);
        }
    }

}
