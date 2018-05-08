using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TestGame1.Backgrounds;
using TestGame1.HUD;
using TestGame1.Logic;
using TestGame1.Obstacles;
using TestGame1.Obstacles.Moving;

namespace TestGame1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Floor floor;
        Player player;
        ObstacleList blocks;
        Background background;
        Collisions collisions;
        Score scoreboard;
        EnemyList goblinList;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Goblin Slayer";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1900;

            // TODO: Add your initialization logic here
            floor = new Floor();
            player = new Player();
            collisions = new Collisions();
            blocks = new ObstacleList();
            scoreboard = new Score();
            floor.Initialize(Content);
            background = new Background();
            goblinList = new EnemyList();
            background.Initialize();
            graphics.ApplyChanges();
            IsMouseVisible = true;

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
            floor.Load();
            player.Load(Content);
            blocks.Load(Content);
            background.Load(Content);
            scoreboard.Load(Content);
            goblinList.Load(Content);
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
            // TODO: Add your update logic here

            if (Player.isActive)
            {
                player.Update(gameTime);
                floor.Update(gameTime);
                blocks.Update(gameTime);
                collisions.TestCollisions(blocks);
                background.Update(gameTime);
                
                goblinList.Update(gameTime);
            }
            scoreboard.Update(gameTime);
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            background.Draw(spriteBatch);
            floor.Draw(spriteBatch);
            if (Player.isActive)
            {
                player.Draw(spriteBatch);
                
            }
            blocks.Draw(spriteBatch);
            goblinList.Draw(spriteBatch);
            
            scoreboard.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

}
