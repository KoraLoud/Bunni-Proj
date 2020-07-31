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
        public int speed = 1;
        Input PlayerInput;
        public player1(Texture2D tex)
        {
            Render.ChangeTexture(tex);
            PlayerInput = new Input();
            PlayerInput.SetDefaultKeyboardKeys();

            PlayerInput.BindKey(Keys.Q, (pressed, held) =>
            {
                if(pressed)
                {
                    Camera.UpdateWindow(Camera.ActualWidth + 50, Camera.ActualHeight + 50);
                }
            });

            PlayerInput.BindKey(Keys.E, (pressed, held) =>
            {
                if(pressed)
                {
                    Camera.UpdateWindow(Camera.ActualWidth - 50, Camera.ActualHeight - 50);
                }
            });

            PlayerInput.BindKey(Keys.Up, (pressed, held) =>
            {
                if(pressed || held)
                {
                    Camera.Position += new Vector2(0,-5);
                }
            });

            PlayerInput.BindKey(Keys.Down, (pressed, held) =>
            {
                if (pressed || held)
                {
                    Camera.Position += new Vector2(0,5);
                }
            });

            PlayerInput.BindKey(Keys.Left, (pressed, held) =>
            {
                if (pressed || held)
                {
                    Camera.Position += new Vector2(-5, 0);
                }
            });

            PlayerInput.BindKey(Keys.Right, (pressed, held) =>
            {
                if (pressed || held)
                {
                    Camera.Position += new Vector2(5, 0);
                }
            });

            PlayerInput.BindKey(Keys.R, (pressed, held) =>
            {
                if (pressed || held)
                {
                    Camera.Zoom -= 0.01f;
                }
            });

            PlayerInput.BindKey(Keys.F, (pressed, held) =>
            {
                if (pressed || held)
                {
                    Camera.Zoom += 0.01f;
                }
            });

            AddComponent(PlayerInput);
            Collider nHitbox = new Collider();
            nHitbox.CreateHitbox<BoxCollider>();
            nHitbox.CollisionLayer = BniTypes.CollisionLayer.Foreground;
            AddComponent(nHitbox);

            Tag = BniTypes.Tag.Player;
        }

        public override void Update(GameTime gameTime, Scene scene)
        {

            Render.TransformC entPos = Render.Transform;
            Vector2 pos = new Vector2(PlayerInput.InputVector.X * speed, PlayerInput.InputVector.Y * speed);
            

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
