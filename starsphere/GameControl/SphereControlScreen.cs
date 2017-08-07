using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Starsphere.GameLogic;


namespace Starsphere.GameControl
{
    class SphereControlScreen : Screen
    {
        //Visual Classes
        Game thisGame;
        SpriteFont titleFont;
        Texture2D horzBorderTex;
        Texture2D vertBorderTex;
        Texture2D blankTex;

        KeyboardState previousState;

        WindowController winCon;

        ViewScreenWindow viewScreen;
        DetailListWindow detailList;
        ScheduleListWindow scheduleList;
        MainControlWindow mainControls;
        List<DisplayWindow> displayWindows;

        DateTime currentInGameTime;
        int timeSlowFactor = 100; //MAGIC NUMBER

        //Game Logic Classes
        Galaxy galaxy;
        int galaxyWidth = 5000; //MAGIC NUMBER
        int galaxyHeight = 5000; //MAGIC NUMBER
        int numberOfSystems = 100; //MAGIC NUMBER

        //Control Variables
        bool leftClickTrigger = false;

        public SphereControlScreen(Game game)
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

            winCon = new WindowController();

            //Setup the size and position of the windows correctly
            viewScreen = new ViewScreenWindow(winCon, outerHorzBorder, outerVertBorder, (int)fullWidth * 54 / 100, (int)fullHeight * 59 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            detailList = new DetailListWindow(winCon, outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 59 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            scheduleList = new ScheduleListWindow(winCon, outerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 54 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);
            mainControls = new MainControlWindow(winCon, outerHorzBorder + viewScreen.Width + innerHorzBorder, outerVertBorder + viewScreen.Height + innerVertBorder, (int)fullWidth * 40 / 100, (int)fullHeight * 35 / 100, borderWidth, blankTex, horzBorderTex, vertBorderTex);

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
            //Load Game Logic
            galaxy = new Galaxy(galaxyWidth, galaxyHeight, numberOfSystems);


            //---------------------------------------------------------------------

            //Load Visual Assets
            titleFont = Content.Load<SpriteFont>("titlefont");

            horzBorderTex = Content.Load<Texture2D>("borderstraight");
            vertBorderTex = Content.Load<Texture2D>("vertborderstraight");
            blankTex = Content.Load<Texture2D>("blanktex");

            //Set up dimensions of all windows
            initializeWindows();

            //Load Control Window Textures
            Texture2D buttonGridTex = Content.Load<Texture2D>("controlbuttontile");
            mainControls.LoadTexture(buttonGridTex, titleFont);

            //Load ScheduleList Textures
            Texture2D buttonSchedGridTex = Content.Load<Texture2D>("schedulebuttontile");
            Texture2D assestSchedGridTex = Content.Load<Texture2D>("scheduleassettile");
            scheduleList.LoadTexture(buttonSchedGridTex, assestSchedGridTex, titleFont);

            currentInGameTime = new DateTime(2123, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified);
            scheduleList.DisplayedTime = currentInGameTime;

            //Load Detail List Window Textures
            SpriteFont detailFont = Content.Load<SpriteFont>("detaillist");
            detailList.LoadTexture(detailFont);

            //Load View Screen Window Textures
            Texture2D galaxyViewScreenTex = Content.Load<Texture2D>("galaxyviewtiles");
            viewScreen.LoadContent(galaxyViewScreenTex, detailFont, galaxy);

            //Connect Window Controller
            winCon.Initialize(viewScreen, scheduleList, detailList, mainControls);
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

            //Main Control Window
            //MAIN UPDATE LOOP HERE:

            //Check for mouse click -------------------------------------------
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                leftClickTrigger = true;
            }

            //Check for mouse movement and control------------------------------
            //Find which control window has the mouse cursor
            foreach (DisplayWindow d in displayWindows)
            {
                if (d.Window.Contains(mouseState.X, mouseState.Y))
                {
                    d.MouseOver(mouseState);

                    //Left Mouse Click Control
                    if (mouseState.LeftButton == ButtonState.Released && leftClickTrigger == true)
                    {
                        d.MouseClick(mouseState);

                        leftClickTrigger = false;
                    }
                    else if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        d.MouseDown(mouseState);
                    }
                    else if (mouseState.LeftButton == ButtonState.Released)
                    {

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

            previousState = keyState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">current sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            //Main Game Window ---------------------------------------
            DrawControlPanels(spriteBatch);
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
