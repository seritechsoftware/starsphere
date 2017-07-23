using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;


namespace starsphere
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OpeningScreen : Screen
    {
        AnimatedSprite[] animatedStar;
        Vector2[] starVector;
        int[] starSize;

        SpriteFont titleFont;
        const string TITLE_NAME = "STAR SPHERE";
        const string TITLE_NAME_2 = "Version 0.0.1";
        const int numStars = 100;

        int updateStage = 0;
        int timeStamp = 0;
        const int waitTime = 2000; //general timer wait for inputs

        int animateTextStage = 0;
        int animateTextTimer = 0;
        int animateTextStageMax = 3;
        const int animateTextWaitTime = 200;

        Game thisGame;

        public OpeningScreen(Game game)
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
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
                thisGame.Exit();

            //Rotate through loading screens
            switch (updateStage)
            {
                case 0:
                    for (int i = 0; i < numStars; i++)
                    {
                        animatedStar[i].Update(gameTime);
                    }

                    if (keyState.IsKeyDown(Keys.Enter))
                        updateStage = 1;
                    break;
                case 1:
                    //Very intro Loading Screen
                    //delay a button press.
                    timeStamp += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeStamp > waitTime)
                    {
                        updateStage = 2;
                        timeStamp = 0;
                    }
                    break;
                case 2:
                    //Very Intro Loading Screen
                    //move on from loading screen when enter is pressed
                    if (keyState.IsKeyDown(Keys.Enter))
                        GameOptions.currentScreenVal = GameOptions.screens.loadSphereControl;
                    break;
                case 3:
                    break;
            }

            //do simple animation to the text so it looks like something is happening. 
            animateTextTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animateTextTimer > animateTextWaitTime)
            {
                animateTextStage++;
                if (animateTextStage > animateTextStageMax)
                    animateTextStage = 0;

                animateTextTimer = 0;
            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (updateStage)
            {
                case 0:
                    for (int i = 0; i < numStars; i++)
                    {
                        animatedStar[i].Draw(spriteBatch, starVector[i], starSize[i], starSize[i]);
                    }

                    spriteBatch.Begin();
                    spriteBatch.DrawString(titleFont, TITLE_NAME, new Vector2(100, 100), Color.White);
                    spriteBatch.DrawString(titleFont, TITLE_NAME_2, new Vector2(100, 200), Color.White);
                    spriteBatch.End();
                    break;
                case 1:
                    spriteBatch.Begin();
                    String initText = "> Initializing Star Sphere Control";
                    if (animateTextStage == 1)
                        initText += " . ";
                    else if (animateTextStage == 2)
                        initText += " . . ";
                    else if (animateTextStage == 3)
                        initText += " . . .";

                    spriteBatch.DrawString(titleFont, initText, new Vector2(100, 100), Color.White);
                    spriteBatch.End();
                    break;
                case 2:
                    spriteBatch.Begin();
                    spriteBatch.DrawString(titleFont, "> Initializing Star Sphere Control . . .", new Vector2(100, 100), Color.White);
                    spriteBatch.DrawString(titleFont, "> Star Sphere Control Initialized", new Vector2(100, 100 + titleFont.LineSpacing), Color.White);

                    string enterText = "> Press Enter to Access Star Sphere Control";
                    if (animateTextStage == 1)
                        enterText += " . ";
                    else if (animateTextStage == 2)
                        enterText += " . . ";
                    else if (animateTextStage == 3)
                        enterText += " . . .";
                    spriteBatch.DrawString(titleFont, enterText, new Vector2(100, 100 + titleFont.LineSpacing * 2), Color.White);

                    spriteBatch.End();
                    break;
                case 3:

                    break;
            }
        }
    }
}
