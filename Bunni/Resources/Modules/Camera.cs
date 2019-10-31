using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class Camera
    {
        private Vector2 _Position;
        public Vector2 Position
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
        private float _Zoom = 0.5f;
        public float Zoom
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
        private float _Rotation = 0;
        public float Rotation
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

        public Vector2 Origin;
        public Rectangle View { get; set; }

        public Matrix Transform = Matrix.Identity;

        private bool Updated = true;

        public Camera(Vector2 position, GraphicsDeviceManager graphics)
        {
            Position = position;
            View = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Origin = new Vector2(View.Width / 2, View.Height / 2);
        }

        public void UpdateWindow(GraphicsDeviceManager graphics)
        {
            View = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Origin = new Vector2(View.Width / 2, View.Height / 2);
        }

        public Matrix TransformMatrix()
        {
            if(Updated)
            {
                Transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0));

                Updated = false;
            }

            return Transform;
        }

    }
}
