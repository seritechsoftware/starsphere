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
        Texture2D borderTexture;
        Texture2D blankTex;

        Rectangle viewScreen, scheduleList, detailList, mainControls;

        public SphereControl(Game game)
        {
            thisGame = game;

            initializeWindows();
        }

        private void initializeWindows()
        {
            int fullWidth = GameOptions.screenWidth;
            int fullHeight = GameOptions.screenHeight;
            int outerHorzBorder = (int)fullWidth * 2 / 100;
            int innerHorzBorder = (int)fullWidth * 1 / 100;
            int outerVertBorder = (int)fullHeight * 2 / 100;
            int innerVertBorder = (int)fullHeight * 2 / 100;


            //Size the windows correctly
            viewScreen.Width = (int)fullWidth * 55 / 100;
            viewScreen.Height = (int)fullHeight * 60 / 100;

            detailList.Width = (int)fullWidth * 40 / 100;
            detailList.Height = (int)fullHeight * 60 / 100;

            scheduleList.Width = (int)fullWidth * 55 / 100;
            scheduleList.Height = (int)fullHeight * 35 / 100;

            mainControls.Width = (int)fullWidth * 40 / 100;
            mainControls.Height = (int)fullHeight * 35 / 100;

            //Position the windows correctly
            viewScreen.X = outerHorzBorder;
            viewScreen.Y = outerVertBorder;

            detailList.X = outerHorzBorder + viewScreen.Width + innerHorzBorder;
            detailList.Y = outerVertBorder;

            scheduleList.X = outerHorzBorder;
            scheduleList.Y = outerVertBorder + viewScreen.Height + innerVertBorder;

            mainControls.X = outerHorzBorder + viewScreen.Width + innerHorzBorder;
            mainControls.Y = outerVertBorder + viewScreen.Height + innerVertBorder;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            titleFont = Content.Load<SpriteFont>("titlefont");

            borderTexture = Content.Load<Texture2D>("borderstraight");
            blankTex = Content.Load<Texture2D>("blanktex");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                thisGame.Exit();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(titleFont, "Initializing Star Sphere Control . . .", new Vector2(100, 100), Color.White);
            spriteBatch.End();
            DrawControlPanels(spriteBatch);
        }


        ///<summary>
        ///Draws the outlines of the control panels for the main game screen. 
        ///</summary>
        private void DrawControlPanels(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(blankTex, viewScreen, Color.Gray);
            spriteBatch.Draw(blankTex, scheduleList, Color.Gray);
            spriteBatch.Draw(blankTex, detailList, Color.Gray);
            spriteBatch.Draw(blankTex, mainControls, Color.Gray);

            spriteBatch.End();
        }
    }
}
