using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace starsphere
{
    class SphereControl : Screen
    {
        Game thisGame;
        SpriteFont titleFont;
        Texture2D horzBorderTex;
        Texture2D vertBorderTex;
        Texture2D blankTex;

        KeyboardState previousState;

        DisplayWindow viewScreen, detailList;
        ScheduleListWindow scheduleList;
        MainControlWindow mainControls;
        List<DisplayWindow> displayWindows;

        DateTime currentInGameTime;
        int timeSlowFactor = 100;

        int updateStage = 0;
        int timeStamp = 0;
        const int waitTime = 2000; //general timer wait for inputs

        int animateTextStage = 0;
        int animateTextTimer = 0;
        int animateTextStageMax = 3;
        const int animateTextWaitTime = 200;

        public SphereControl(Game game)
        {
            thisGame = game;
        }

        private void initializeWindows()
        {
            int fullWidth = GameOptions.screenWidth;
            int fullHeight = GameOptions.screenHeight;
            int outerHorzBorder = (int)fullWidth * 2 / 100;
            int innerHorzBorder = (int)fullWidth * 2 / 100;
            int outerVertBorder = (int)fullHeight * 2 / 100;
            int innerVertBorder = (int)fullHeight * 3 / 100;

            int borderWidth = horzBorderTex.Height;

            //Setup the size and position of the windows correctly
            viewScreen = new DisplayWindow(outerHorzBorder, outerVertBorder, (int)fullWidth * 54 / 100, (int)fullHeight * 59 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            detailList = new DisplayWindow(outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 59 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            scheduleList = new ScheduleListWindow(outerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 54 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            mainControls = new MainControlWindow(outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);

            //Set up list to cycle through for input commands
            displayWindows = new List<DisplayWindow>();
            displayWindows.Add(viewScreen);
            displayWindows.Add(detailList);
            displayWindows.Add(scheduleList);
            displayWindows.Add(mainControls);

            previousState = Keyboard.GetState();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            titleFont = Content.Load<SpriteFont>("titlefont");

            horzBorderTex = Content.Load<Texture2D>("borderstraight");
            vertBorderTex = Content.Load<Texture2D>("vertborderstraight");
            blankTex = Content.Load<Texture2D>("blanktex");

            //Set up dimensions of all windows
            initializeWindows();
            //load textures into individual window classes
            Texture2D buttonGridTex = Content.Load<Texture2D>("controlbuttontile");
            mainControls.LoadTexture(buttonGridTex, titleFont);
            scheduleList.LoadTexture(titleFont);


            currentInGameTime = new DateTime(2123, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified);
            scheduleList.DisplayedTime = currentInGameTime;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            //Default exit kill switch-------------
            //TODO: Remove before production

            if (keyState.IsKeyDown(Keys.Escape))
                thisGame.Exit();

            //-------------------------------------

            switch (updateStage)
            {
                case 0:
                    //Very intro Loading Screen
                    //delay a button press.
                    timeStamp += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeStamp > waitTime)
                    {
                        updateStage = 1;
                        timeStamp = 0;
                    }
                    break;
                case 1:
                    //Very Intro Loading Screen
                    //move on from loading screen when enter is pressed
                    if (keyState.IsKeyDown(Keys.Enter))
                        updateStage = 2;
                    break;
                case 2:
                    //Main Control Window
                    //MAIN UPDATE LOOP HERE:

                    //Check for mouse movement and control------------------------------
                    //Find which control window has the mouse cursor
                    foreach (DisplayWindow d in displayWindows)
                    {
                        if (d.Window.Contains(mouseState.X, mouseState.Y))
                        {
                            d.MouseOver(mouseState);

                            if (mouseState.LeftButton == ButtonState.Pressed)
                            {
                                d.MouseDown(mouseState);
                            }
                            else
                            {
                                d.MouseUp(mouseState);
                            }
                        }
                        else
                        {
                            d.MouseOff(mouseState);
                        }
                    }

                    //Update Current In Game Time from Elapsed Game Time
                    currentInGameTime = currentInGameTime.AddMilliseconds(gameTime.ElapsedGameTime.Milliseconds * timeSlowFactor);
                    scheduleList.DisplayedTime = currentInGameTime;
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

            previousState = keyState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">current sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            switch(updateStage)
            {
                case 0:
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
                case 1:
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
                    spriteBatch.DrawString(titleFont, enterText, new Vector2(100, 100 + titleFont.LineSpacing*2), Color.White);

                    spriteBatch.End();
                    break;
                case 2:
                    //Main Game Window ---------------------------------------
                    DrawControlPanels(spriteBatch);
                    //Main Game Window ---------------------------------------
                    break;
            }
        }

        ///<summary>
        ///Draws the outlines of the control panels for the main game screen. 
        ///</summary>
        private void DrawControlPanels(SpriteBatch spriteBatch)
        {
            viewScreen.Draw(spriteBatch);
            detailList.Draw(spriteBatch);
            scheduleList.Draw(spriteBatch);
            mainControls.Draw(spriteBatch);
        }
    }
}
