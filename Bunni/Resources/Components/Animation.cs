using Bunni.Resources.Components.Collision;
using Bunni.Resources.Modules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Components
{
    public class Animation : Component
    {
        public Texture2D Atlas { get; set; }
        public int Frames { get; set; }
        public int AnimationDelay { get; set; } = 15;
        public bool IsPlaying { get; private set; } = false;
        public bool Loop { get; set; } = false;
        public int CurrentFrame { get; set; } = 0;

        private Rectangle[] Rectangles;
        /// <summary>
        /// This variable holds the amount of frames that have passed
        /// The animation will only move to the next frame when this equals AnimationSpeed
        /// </summary>
        private int AnimationHeartbeat;


        public Animation(Texture2D atlas, int frames)
        {
            Atlas = atlas;
            Frames = frames;

            Rectangles = new Rectangle[frames];
            int width = atlas.Width / frames;
            for(int i=0;i< frames; i++)
            {
                Rectangles[i] = new Rectangle((i*width), 0, width, atlas.Height);
            }
        }

        public override void ComponentAdded()
        {
            Render EntityRenderComp = Parent.GetComponent<Render>();
            EntityRenderComp.Texture = Atlas;
            EntityRenderComp.RenderRectangle = Rectangles[0];
            
        }

        public override void Update(GameTime gameTime, Scene scene)
        {
            if(IsPlaying)
            {
                AnimationHeartbeat++;
                if(AnimationHeartbeat>= AnimationDelay)
                {
                    AnimationHeartbeat = 0;
                    CurrentFrame++;
                }
                if(CurrentFrame>=Frames)
                {
                    if(Loop)
                    {
                        CurrentFrame = 0;
                    }
                    else
                    {
                        Stop();
                    }
                }
                Render EntityRenderComp = Parent.GetComponent<Render>();
                EntityRenderComp.RenderRectangle = Rectangles[CurrentFrame];
                Collider EntityCollider = Parent.GetComponent<Collider>();
                if(EntityCollider != null)
                {
                    EntityCollider.Hitbox.Width = Atlas.Width / Frames;
                }
            }
        }

        public void Stop()
        {
            CurrentFrame = 0;
            IsPlaying = false;
        }

        public void Play()
        {
            CurrentFrame = 0;
            IsPlaying = true;
            Render EntityRenderComp = Parent.GetComponent<Render>();
            EntityRenderComp.Texture = Atlas;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void Resume()
        {
            IsPlaying = true;
            Render EntityRenderComp = Parent.GetComponent<Render>();
            EntityRenderComp.Texture = Atlas;
        }
    }
}
