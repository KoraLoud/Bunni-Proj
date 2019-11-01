using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public static class Camera
    {
        public static int VirtualWidth = 1280;
        public static int VirtualHeight = 720;
        public static int ActualHeight;
        public static int ActualWidth;

        private static GraphicsDeviceManager Graphics;
        private static Vector2 _Position;
        public static Vector2 Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
                Updated = true;
            }
        }
        private static float _Zoom = 0.5f;
        public static float Zoom
        {
            get
            {
                return _Zoom;
            }
            set
            {
                _Zoom = value;
                Updated = true;
            }
        }
        private static float _Rotation = 0;
        public static float Rotation
        {
            get
            {
                return _Rotation;
            }
            set
            {
                _Rotation = value;
                Updated = true;
            }
        }

        public static Vector2 Origin;
        public static Rectangle View { get; set; }

        public static Matrix Transform = Matrix.Identity;

        private static bool Updated = true;

        public static void Init(Vector2 position, GraphicsDeviceManager graphics, int virtualWidth, int virtualHeight)
        {
            Position = position;
            Graphics = graphics;
            ActualWidth = graphics.PreferredBackBufferWidth;
            ActualHeight = graphics.PreferredBackBufferHeight;
            VirtualWidth = virtualHeight;
            VirtualHeight = virtualHeight;
            Updated = true;
            View = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Origin = new Vector2(View.Width / 2, View.Height / 2);
        }

        public static void UpdateWindow(int width, int height)
        {
            ActualWidth = width;
            ActualHeight = height;
            Graphics.PreferredBackBufferWidth = width;
            Graphics.PreferredBackBufferHeight = height;
            Graphics.ApplyChanges();
            View = new Rectangle(0, 0, ActualWidth, ActualHeight);
            Origin = new Vector2(View.Width / 2, View.Height / 2);
            Updated = true;
        }

        public static Matrix TransformMatrix()
        {
            if(Updated)
            {
                Transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(new Vector3(Zoom*((float)ActualWidth/VirtualWidth), Zoom*((float)ActualHeight/VirtualHeight), 1)) *
                    //Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0));
                Updated = false;
            }

            return Transform;
        }

    }
}
