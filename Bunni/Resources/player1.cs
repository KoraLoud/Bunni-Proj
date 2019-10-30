using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Bunni.Resources.Modules;
using Bunni.Resources.Components;
using Bunni.Resources.Components.ColliderComponents;

namespace Bunni
{
    public class player1 : Entity //this is just a class for testing framework functionality
    {
        public int speed = 5;
        public player1(Texture2D tex)
        {
            AddComponent(new PositionVector());
            AddComponent(new Render(tex));
            Life nLife = new Life();
            AddComponent(nLife);
            KeyboardIn nInput = new KeyboardIn();
            nInput.SetDefaultKeyboardKeys();
            AddComponent(nInput);
            BoxCollider nHitbox = new BoxCollider();
            nHitbox.CollisionLayer = CollisionLayers.Foreground;
            AddComponent(nHitbox);
            
        }

        public override void Update(GameTime gameTime, Scene scene)
        {

            KeyboardIn entIn = GetComponent<KeyboardIn>();
            PositionVector entPos = GetComponent<PositionVector>();
            Vector2 pos = new Vector2(entIn.InputVector.X * speed, entIn.InputVector.Y * speed);
            

            scene.SceneEntities.ForEach((e) =>
            {
                if (e != this)
                {
                    if (e.GetComponent<BoxCollider>() != null)
                    {
                        GetComponent<BoxCollider>().Offset = new Vector2(pos.X, 0);
                        if (GetComponent<BoxCollider>().IntersectsOnLayer(e.GetComponent<BoxCollider>()))
                        {
                                pos = new Vector2(0, pos.Y);
                        
                        }
                        GetComponent<BoxCollider>().Offset = new Vector2(0, pos.Y);
                        if (GetComponent<BoxCollider>().IntersectsOnLayer(e.GetComponent<BoxCollider>()))
                        {
                            pos = new Vector2(pos.X, 0);

                        }
                    }
                        else
                        {
                            Console.WriteLine("No collider!");
                        }
                }

            });
            GetComponent<BoxCollider>().Offset = Vector2.Zero;
            //Console.WriteLine(entPos.Position);
            //Console.WriteLine(pos.X);
            entPos.Position = new Vector2(entPos.Position.X + pos.X, entPos.Position.Y + pos.Y);
            
            

            base.Update(gameTime, scene);
        }
    }

}
