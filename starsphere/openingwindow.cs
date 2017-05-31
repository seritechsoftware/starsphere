using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace starsphere
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OpeningWindow : Screen
    {
        AnimatedSprite[] animatedStar;
        Vector2[] starVector;
        int[] starSize;

        SpriteFont titleFont;
        const string TITLE_NAME = "STAR SPHERE";
        const string TITLE_NAME_2 = "Version 0.0.1";
        const int numStars = 100;

        Game thisGame;

        public OpeningWindow(Game game)
        {
            thisGame = game;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // TODO: use this.Content to load your game content here
            Texture2D texture = Content.Load<Texture2D>("starflashtile");
            titleFont = Content.Load<SpriteFont>("titlefont");
            System.Random rng = new System.Random();

            animatedStar = new AnimatedSprite[numStars];
            starVector = new Vector2[numStars];
            starSize = new int[numStars];

            for (int i = 0; i < numStars; i++)
            {
                int whichStar = rng.Next(0, 2);
                if (whichStar == 0)
                {
                    animatedStar[i] = new AnimatedSprite(texture, 150, 6, 6, 0, 7, true);
                    int startFrame = rng.Next(0, 8);
                    animatedStar[i].ForceFrame(startFrame);
                }
                else
                {
                    animatedStar[i] = new AnimatedSprite(texture, 150, 6, 6, 8, 15, true);
                    int startFrame = rng.Next(8, 16);
                    animatedStar[i].ForceFrame(startFrame);
                }
                starSize[i] = rng.Next(5, 20);

                starVector[i] = new Vector2(rng.Next(0, GameOptions.screenWidth), rng.Next(0, GameOptions.screenHeight));
            }

        }

        public void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                thisGame.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Mouse.GetState().LeftButton == ButtonState.Pressed)
                GameOptions.currentScreenVal = GameOptions.screens.loadSphereControl;


            for (int i = 0; i < numStars; i++)
            {
                animatedStar[i].Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numStars; i++)
            {
                animatedStar[i].Draw(spriteBatch, starVector[i], starSize[i], starSize[i]);
            }

            spriteBatch.Begin();
            spriteBatch.DrawString(titleFont, TITLE_NAME, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(titleFont, TITLE_NAME_2, new Vector2(100, 200), Color.White);
            spriteBatch.End();
        }
    }
}
