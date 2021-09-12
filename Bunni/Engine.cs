using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bunni.Resources.Modules;
using Bunni.Resources.Components;
using System;
using Bunni.Resources.Components.Physics;
using UntitledDungeonGame.Bunni.Components;


//TODO:
//more hitbox types
//physics
//particles

namespace Bunni
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Engine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public player1 player;
        public Scene scene1;
        public Solid bunni;


        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Camera.Init(new Vector2(400, 240), graphics, 800, 480);
            Camera.Zoom = 1f;
            Camera.UpdateWindow(800, 480);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            // TODO: Add your initialization logic here
            Texture2D tex = Content.Load<Texture2D>("img");
            Texture2D rainbowAnimationTex = Content.Load<Texture2D>("rainbowbox");
            bunni = new Solid(tex);
            player = new player1(rainbowAnimationTex);
            //Animation rainbowAnimation = new Animation(rainbowAnimationTex, 8);
            Animation rainbowAnimation = new Animation();
            player.AddComponent(rainbowAnimation);

            rainbowAnimation.AddAtlas("Rainbow", rainbowAnimationTex, 8);
            rainbowAnimation.SetDefaultAtlus("Rainbow");
            rainbowAnimation.AddAnimation("rainboW", 0, 7, 0);
            rainbowAnimation.GetAnimation("rainboW").Loop = true;

            scene1 = new Scene();
            player.Transform.Position = new Vector2(400, 200);

            scene1.AddEntity(bunni);
            scene1.Solids.Add(bunni);
            scene1.AddEntity(player);
            rainbowAnimation.PlayAnimation("rainboW");

            SceneManager.CurrentScene = scene1;
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            scene1.PreUpdate(gameTime);

            Vector2 mouseState = Camera.GetMouseWorldPosition();

            //Console.WriteLine("World Position of mouse: "+mouseState);
            //Console.WriteLine("Screen Position of mouse: " + new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            //Console.WriteLine(mouseState.Y);
            //Console.WriteLine("World Position of camera:" + Camera.Position);
            //Console.WriteLine("");
            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Mouse Clicked");
                player.Render.Transform.Lerp(new Vector2(mouse.Position.X, mouse.Position.Y), 1000);
            }

            Input pInput = player.GetComponent<Input>();
            player.MoveX(pInput.InputVector.X*5, null);
            player.MoveY(pInput.InputVector.Y*5, null);
            


            scene1.Update(gameTime);
            scene1.PostUpdate(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Camera.TransformMatrix(gameTime));
            scene1.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}