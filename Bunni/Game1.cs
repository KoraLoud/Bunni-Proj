using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bunni.Resources.Modules;
using Bunni.Resources.Components;
using System;
using Bunni.Resources.Components.Collision;


//TODO:
    //rework basic classes into interfaces
    //check to see if entity already has component
    //hitboxes
        //box hitbox (done)
        //layers (done)
        //tags (done)
        //more hitbox types
    //Animator
        //animation atlas
        //animation track ?
    //physics
    //camera
    //particles
    //render
        //render layer

namespace Bunni
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public player1 player;
        public Scene scene1;
        public Entity hitBox = new Entity();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            hitBox.Tag = BniTypes.Tag.Player;
            Texture2D tex = Content.Load<Texture2D>("img");
            player = new player1(tex);
            scene1 = new Scene();
            PositionVector nPsV = new PositionVector();
            Render nRen = new Render(tex);
            nPsV.Position = new Vector2(400, 200);
            Collider nHitbox = new Collider();
            nHitbox.CreateHitbox<BoxCollider>();
            nHitbox.CollisionLayer = BniTypes.CollisionLayer.Foreground;
            hitBox.AddComponent(nPsV);
            hitBox.AddComponent(nRen);
            hitBox.AddComponent(nHitbox);

            scene1.AddEntity(hitBox);
            scene1.AddEntity(player);
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

            scene1.PreUpdate(gameTime, scene1);

            if (player.GetComponent<Collider>().IntersectsWithTag(hitBox.GetComponent<Collider>()))
            {
                player.GetComponent<Render>().Color = Color.Red;
            }else
            {
                player.GetComponent<Render>().Color = Color.White;
            }

            BoxCollider pHitBox = player.GetComponent<Collider>().Hitbox as BoxCollider;
            BoxCollider oHitBox = hitBox.GetComponent<Collider>().Hitbox as BoxCollider;
            Console.WriteLine(oHitBox.Top);
            Console.WriteLine(oHitBox.Height);



            scene1.Update(gameTime, scene1);
            scene1.PostUpdate(gameTime, scene1);

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
            spriteBatch.Begin();
            scene1.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}