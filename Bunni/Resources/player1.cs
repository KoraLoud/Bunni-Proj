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
using Bunni.Resources.Components.Collision;

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
            Input nInput = new Input();
            nInput.SetDefaultKeyboardKeys();
            AddComponent(nInput);
            Collider nHitbox = new Collider();
            nHitbox.CreateHitbox<BoxCollider>();
            nHitbox.CollisionLayer = BniTypes.CollisionLayer.Foreground;
            AddComponent(nHitbox);

            Tag = BniTypes.Tag.Player;
        }

        public override void Update(GameTime gameTime, Scene scene)
        {

            Input entIn = GetComponent<Input>();
            PositionVector entPos = GetComponent<PositionVector>();
            Vector2 pos = new Vector2(entIn.InputVector.X * speed, entIn.InputVector.Y * speed);
            

            scene.SceneEntities.ForEach((e) =>
            {
                if (e != this)
                {
                    if (e.GetComponent<Collider>() != null)
                    {
                        GetComponent<Collider>().Offset = new Vector2(pos.X, 0);
                        if (GetComponent<Collider>().IntersectsOnLayer(e.GetComponent<Collider>()))
                        {
                                pos = new Vector2(0, pos.Y);
                        
                        }
                        GetComponent<Collider>().Offset = new Vector2(0, pos.Y);
                        if (GetComponent<Collider>().IntersectsOnLayer(e.GetComponent<Collider>()))
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
            GetComponent<Collider>().Offset = Vector2.Zero;
            //Console.WriteLine(entPos.Position);
            //Console.WriteLine(pos.X);
            entPos.Position = new Vector2(entPos.Position.X + pos.X, entPos.Position.Y + pos.Y);
            
            

            base.Update(gameTime, scene);
        }
    }

}
