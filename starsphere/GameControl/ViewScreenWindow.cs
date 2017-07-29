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
    class ViewScreenWindow : DisplayWindow
    {
        private GameOptions.DisplayMode currentDisplay;
        private SpriteFont detailFont;
        private IconHandler galaxyIcons;
        private Rectangle galaxyViewWindow; //window that only shows a portion of the galaxy

        //Game Logic Variables
        private Galaxy currentGalaxy;


        private int borderWidth = 32; //MAGIC NUMBER
        private int moveSpeed = 5; //MAGIC NUMBER
        public ViewScreenWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            currentDisplay = GameOptions.DisplayMode.galaxyView;
            galaxyViewWindow = new Rectangle(0, 0, width, height);
        }

        public void LoadContent(Texture2D galaxyViewTextures, SpriteFont font, Galaxy gal)
        {
            detailFont = font;
            currentGalaxy = gal;

            galaxyIcons = new IconHandler(galaxyViewTextures, 3, 6);
        }


        public override void MouseOver(MouseState mouseState)
        {
            base.MouseOver(mouseState);

            //GALAXY VIEW WINDOW EVENTS
            //Detect if the mouse is within the edge boundaries of the viewer to move it

            if (currentDisplay == GameOptions.DisplayMode.galaxyView)
            {
                if (mouseState.X > Window.X && mouseState.X < Window.X + borderWidth)
                {
                    //Left border
                    if (galaxyViewWindow.Left > 0)
                        galaxyViewWindow.X -= moveSpeed;
                }
                if (mouseState.X > Window.Right - borderWidth && mouseState.X < Window.Right)
                {
                    //Right border
                    if (galaxyViewWindow.Right < currentGalaxy.Width)
                    {
                        galaxyViewWindow.X += moveSpeed;
                    }
                }
                if (mouseState.Y > Window.Top && mouseState.Y < Window.Top + borderWidth)
                {
                    //Top border
                    if (galaxyViewWindow.Top > 0)
                    {
                        galaxyViewWindow.Y -= moveSpeed;
                    }
                }
                if (mouseState.Y > Window.Bottom - borderWidth && mouseState.Y < Window.Bottom)
                {
                    //Bottom border
                    if (galaxyViewWindow.Bottom < currentGalaxy.Height)
                    {
                        galaxyViewWindow.Y += moveSpeed;
                    }
                }
            }

        }

        public override void MouseDown(MouseState mouseState)
        {

        }

        public override void MouseUp(MouseState mouseState)
        {

        }

        public override void MouseClick(MouseState mouseState)
        {

        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            //draw base window
            base.Draw(spriteBatch);

            switch (currentDisplay)
            {
                case GameOptions.DisplayMode.blankView:
                    DrawBlankView(spriteBatch);
                    break;
                case GameOptions.DisplayMode.galaxyView:
                    DrawGalaxyView(spriteBatch);
                    break;
                case GameOptions.DisplayMode.systemView:
                    DrawSystemView(spriteBatch);
                    break;
                case GameOptions.DisplayMode.planetView:
                    DrawPlanetView(spriteBatch);
                    break;
            }
        }

        public void DrawBlankView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = base.DefaultBackground;
        }

        public void DrawGalaxyView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
            Rectangle sourceRect;

            //Cycle through list of stars in the galaxy, find the ones in the current viewing window. 
            if (currentGalaxy.systems.Count == 0)
                return;

            spriteBatch.Begin();
            foreach (StarSystem s in currentGalaxy.systems)
            {
                //Check to see if in current viewing window. 
                if (galaxyViewWindow.Contains(s.XCoord, s.YCoord))
                {
                    //draw this star
                    switch (s.Type)
                    {
                        case Types.StarType.ClassO:
                        case Types.StarType.ClassB:
                        case Types.StarType.ClassA:
                            sourceRect = galaxyIcons.getIconRectangle(1, 0);
                            break;
                        case Types.StarType.ClassF:
                        case Types.StarType.ClassG:
                            sourceRect = galaxyIcons.getIconRectangle(0, 0);
                            break;
                        case Types.StarType.ClassK:
                        case Types.StarType.ClassM:
                            sourceRect = galaxyIcons.getIconRectangle(2, 0);
                            break;
                        default:
                            sourceRect = galaxyIcons.getIconRectangle(0, 0);
                            break;
                    }

                    spriteBatch.Draw(galaxyIcons.iconTexture, new Vector2(s.XCoord - galaxyViewWindow.X, s.YCoord - galaxyViewWindow.Y), sourceRect, Color.White);
                }
            }

            spriteBatch.End();
        }

        public void DrawSystemView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
        }
        
        public void DrawPlanetView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
        }
    }
}
