using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace starsphere
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OpeningWindow : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 iconPosition;
        Texture2D iconTexture;

        const string WINDOW_NAME = "Star Sphere 0.0.1";

        public OpeningWindow()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 400;
            Content.RootDirectory = "Content";

            iconPosition = new Vector2(0, 0);

            //Pause Window Handlers
            this.Activated += (sender, args) => { this.Window.Title = WINDOW_NAME; };
            this.Deactivated += (sender, args) => { this.Window.Title = "PAUSED"; };

            //Run at a fixed speed
            this.IsFixedTimeStep = true;
            this.graphics.SynchronizeWithVerticalRetrace = true;
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

            // TODO: use this.Content to load your game content here

            iconTexture = this.Content.Load<Texture2D>("defaulttex");
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
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                iconPosition.X += 1;
                if (iconPosition.X > this.GraphicsDevice.Viewport.Width)
                    iconPosition.X = 0;

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(iconTexture, iconPosition);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
