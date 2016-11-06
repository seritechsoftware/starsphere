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

        AnimatedSprite[] animatedStar;
        Vector2[] starVector;

        int screenHeight, screenWidth;

        const string WINDOW_NAME = "Star Sphere 0.0.1";
        const int numStars = 100;

        public OpeningWindow()
        {
            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
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
            Texture2D texture = Content.Load<Texture2D>("starflashtile");
            System.Random rng = new System.Random();

            animatedStar = new AnimatedSprite[numStars];
            starVector = new Vector2[numStars];

            for (int i = 0; i < numStars; i++)
            {
                int whichStar = rng.Next(0, 2);
                if (whichStar == 0)
                {
                    animatedStar[i] = new AnimatedSprite(texture, 100, 6, 6, 0, 7, true);
                    int startFrame = rng.Next(0, 8);
                    animatedStar[i].ForceFrame(startFrame);
                }
                else
                {
                    animatedStar[i] = new AnimatedSprite(texture, 100, 6, 6, 8, 15, true);
                    int startFrame = rng.Next(8, 16);
                    animatedStar[i].ForceFrame(startFrame);
                }
                    

                starVector[i] = new Vector2(rng.Next(0, screenWidth), rng.Next(0, screenHeight));
            }

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

                for (int i = 0; i < numStars; i++)
                {
                    animatedStar[i].Update(gameTime);
                }
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            for (int i = 0; i < numStars; i++)
            {
                animatedStar[i].Draw(spriteBatch, starVector[i]);
            }

            base.Draw(gameTime);
        }
    }
}
