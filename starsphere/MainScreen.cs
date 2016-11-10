using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace starsphere
{
    class MainScreen : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen currentScreen;

        OpeningWindow openWindow;
        SphereControl gameWindow;

        const string WINDOW_NAME = "Star Sphere 0.0.1";

        public MainScreen()
        {
            //Get Screen Size
            GameOptions.screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            GameOptions.screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = GameOptions.screenHeight;
            graphics.PreferredBackBufferWidth = GameOptions.screenWidth;
            Content.RootDirectory = "Content";


            //Pause Window Handlers
            this.Activated += (sender, args) => { this.Window.Title = WINDOW_NAME; };
            this.Deactivated += (sender, args) => { this.Window.Title = "PAUSED"; };

            //Run at a fixed speed
            this.IsFixedTimeStep = true;
            this.graphics.SynchronizeWithVerticalRetrace = true;


            openWindow = new OpeningWindow(this);
            gameWindow = new SphereControl(this);

            currentScreen = openWindow;
            GameOptions.currentScreenVal = GameOptions.screens.openingWindow;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
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

            openWindow.LoadContent(Content);
            gameWindow.LoadContent(Content);
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
            currentScreen.Update(gameTime);

            //check for switch of current screen
            switch (GameOptions.currentScreenVal)
            {
                case GameOptions.screens.openingWindow:
                    currentScreen = openWindow;
                    break;
                case GameOptions.screens.sphereControl:
                    currentScreen = gameWindow;
                    break;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            currentScreen.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
