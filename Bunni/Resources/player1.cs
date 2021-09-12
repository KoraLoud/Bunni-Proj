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
using Bunni.Resources.Components.Physics;

namespace Bunni
{
    public class player1 : Actor //this is just a class for testing framework functionality
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

            Tag = BniTypes.Tag.Player;
        }

        public override void Update(GameTime gameTime, Scene scene)
        {
            base.Update(gameTime, scene);
        }
    }

}
