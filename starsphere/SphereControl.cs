﻿using System;
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

        DisplayWindow viewScreen, scheduleList, detailList, mainControls;

        int updateStage = 0;
        int timeStamp = 0;
        const int waitTime = 2000; //general timer wait for inputs

        int animateTextTimer = 0;

        public SphereControl(Game game)
        {
            thisGame = game;
        }

        private void initializeWindows()
        {
            int fullWidth = GameOptions.screenWidth;
            int fullHeight = GameOptions.screenHeight;
            int outerHorzBorder = (int)fullWidth * 2 / 100;
            int innerHorzBorder = (int)fullWidth * 1 / 100;
            int outerVertBorder = (int)fullHeight * 2 / 100;
            int innerVertBorder = (int)fullHeight * 2 / 100;

            int borderWidth = horzBorderTex.Height;

            //Setup the size and position of the windows correctly
            viewScreen = new DisplayWindow(outerHorzBorder, outerVertBorder, (int)fullWidth * 55 / 100, (int)fullHeight * 60 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            detailList = new DisplayWindow(outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 60 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            scheduleList = new DisplayWindow(outerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 55 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            mainControls = new DisplayWindow(outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);

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

            initializeWindows();
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
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                thisGame.Exit();

            switch (updateStage)
            {
                case 0:
                    timeStamp += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeStamp > waitTime)
                    {
                        updateStage = 1;
                        timeStamp = 0;
                    }

                    break;
                case 1:
                    if (state.IsKeyDown(Keys.Enter))
                        updateStage = 2;

                    break;
                case 2:
                    break;
            }

            previousState = state;
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
                    String initText = "Initializing Star Sphere Control";
                    if (animateTextTimer == 1)
                    {
                        initText += " . ";
                        animateTextTimer++;
                    }
                    else if (animateTextTimer == 2)
                    {
                        initText += " . . ";
                        animateTextTimer++;
                    }
                    else if (animateTextTimer == 3)
                    {
                        initText += " . . .";
                        animateTextTimer = 0;
                    }
                    else
                    {
                        animateTextTimer++;
                    }
                    spriteBatch.DrawString(titleFont, initText, new Vector2(100, 100), Color.White);
                    spriteBatch.End();
                    break;
                case 1:
                    spriteBatch.Begin();
                    spriteBatch.DrawString(titleFont, "Star Sphere Control Initialized", new Vector2(100, 100), Color.White);
                    spriteBatch.DrawString(titleFont, "Press Enter to Access Star Sphere Control . . .", new Vector2(100, 200), Color.White);
                    spriteBatch.End();
                    break;
                case 2:
                    DrawControlPanels(spriteBatch);
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
