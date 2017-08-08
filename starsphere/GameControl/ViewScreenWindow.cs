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
    public class ViewScreenWindow : DisplayWindow
    {
        private GameOptions.DisplayMode currentDisplay;
        private SpriteFont detailFont;
        private IconHandler galaxyIcons;
        private Rectangle galaxyViewWindow; //window that only shows a portion of the galaxy
        private Rectangle systemViewWindow; //window to show the star system

        //Game Logic Variables
        private Galaxy currentGalaxy;
        private StarSystem selectedSystem;

        private int borderWidth = 32; //MAGIC NUMBER
        private int moveSpeed = 5; //MAGIC NUMBER

        public GameOptions.DisplayMode ViewScreenMode { get { return currentDisplay; } set { currentDisplay = value; } }

        public ViewScreenWindow(WindowController wc, int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(wc, x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            currentDisplay = GameOptions.DisplayMode.blankView;
            galaxyViewWindow = new Rectangle(x, y, width, height);
            systemViewWindow = new Rectangle(x, y, width, height);
        }

        public void LoadContent(Texture2D galaxyViewTextures, SpriteFont font, Galaxy gal)
        {
            detailFont = font;
            currentGalaxy = gal;
            selectedSystem = currentGalaxy.Home;

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

            //SYSTEM VIEW WINDOW EVENTS
            else if (currentDisplay == GameOptions.DisplayMode.systemView)
            {

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
            switch (currentDisplay)
            {
                case GameOptions.DisplayMode.blankView:

                    break;
                case GameOptions.DisplayMode.galaxyView:
                    //Did they click a star system
                    Rectangle clickRect = galaxyIcons.getIconRectangle(0, 0);
                    foreach (StarSystem s in currentGalaxy.systems)
                    {
                        //Check to see if in current viewing window. 
                        if (galaxyViewWindow.Contains(s.XCoord, s.YCoord))
                        {
                            //switch mousecoords to window coords
                            Vector2 mouseClickPos = new Vector2(galaxyViewWindow.X + mouseState.X, galaxyViewWindow.Y + mouseState.Y);
                            clickRect.Location = new Point(s.XCoord, s.YCoord);
                            if (clickRect.Contains(mouseClickPos))
                            {
                                if (selectedSystem != null)
                                    selectedSystem.Selected = false;
                                s.Selected = true;
                                selectedSystem = s;

                                //Display SelectedStar
                                WindowCon.ChangeDetailListMode(GameOptions.DetailMode.starInfo);
                                WindowCon.ChangeDetailStar(selectedSystem);
                            }

                        }
                    }
                    break;
                case GameOptions.DisplayMode.systemView:

                    break;
                case GameOptions.DisplayMode.baseView:

                    break;

                case GameOptions.DisplayMode.scienceView:

                    break;
                case GameOptions.DisplayMode.personnelView:

                    break;
            }
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
                case GameOptions.DisplayMode.baseView:
                    DrawBaseView(spriteBatch);
                    break;
                case GameOptions.DisplayMode.scienceView:
                    DrawBaseView(spriteBatch);
                    break;
                case GameOptions.DisplayMode.personnelView:
                    DrawPersonnelView(spriteBatch);
                    break;
            }

            base.DrawBorders(spriteBatch);
        }

        private void DrawBlankView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = base.DefaultBackground;
        }

        private void DrawGalaxyView(SpriteBatch spriteBatch)
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
                    sourceRect = GetStarType(s.Type);

                    Vector2 coords = new Vector2(s.XCoord - galaxyViewWindow.X, s.YCoord - galaxyViewWindow.Y);
                    spriteBatch.Draw(galaxyIcons.iconTexture, coords, sourceRect, Color.White);

                    if (s.Selected)
                    {
                        sourceRect = galaxyIcons.getIconRectangle(0, 1);
                        spriteBatch.Draw(galaxyIcons.iconTexture, coords, sourceRect, Color.White);
                    }
                }
            }

            spriteBatch.End();
        }

        private Rectangle GetStarType(Types.StarType type)
        {
            Rectangle sourceRect;
            switch (type)
            {
                case Types.StarType.ClassO:
                case Types.StarType.ClassB:
                case Types.StarType.ClassA:
                    sourceRect = galaxyIcons.getIconRectangle(1, 0); //MAGIC NUMBERS
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

            return sourceRect;
        }

        private Rectangle GetSystemViewStarType(Types.StarType type)
        {
            Rectangle sourceRect;
            switch (type)
            {
                case Types.StarType.ClassO:
                case Types.StarType.ClassB:
                case Types.StarType.ClassA:
                    sourceRect = galaxyIcons.getIconRectangle(1, 3); //MAGIC NUMBERS
                    break;
                case Types.StarType.ClassF:
                case Types.StarType.ClassG:
                    sourceRect = galaxyIcons.getIconRectangle(0, 3);
                    break;
                case Types.StarType.ClassK:
                case Types.StarType.ClassM:
                    sourceRect = galaxyIcons.getIconRectangle(2, 3);
                    break;
                default:
                    sourceRect = galaxyIcons.getIconRectangle(0, 3);
                    break;
            }

            return sourceRect;
        }

        private void DrawSystemView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;

            if (selectedSystem == null)
                return;

            Rectangle sourceRect;

            spriteBatch.Begin();

            sourceRect = GetSystemViewStarType(selectedSystem.Type);
            Vector2 center = new Vector2(systemViewWindow.Left, (int)(systemViewWindow.Height / 2));
            spriteBatch.Draw(galaxyIcons.iconTexture, center, sourceRect, Color.White);

            //sort planets by orbital distance
            if (selectedSystem.Discovered)
            {
                if (selectedSystem.NumberOfPlanets != 0)
                {
                    IEnumerable<Planet> order = selectedSystem.planets.OrderBy(planet => planet.OrbitalNumber);
                    int maxOrbit = order.Last().OrbitRadius;

                    int previousEnd = sourceRect.Width;
                    foreach (Planet p in order)
                    {
                        int radius = (int)(((systemViewWindow.Width - center.X) / maxOrbit) * p.OrbitRadius);
                        if (radius < previousEnd)
                            radius = previousEnd;
                        sourceRect = GetPlanetType(p.SizeOfPlanet);
                        spriteBatch.Draw(galaxyIcons.iconTexture, new Vector2(center.X + radius, center.Y), sourceRect, p.PlanetColor);
                        previousEnd = radius + sourceRect.Width;
                    }
                }
            }

            spriteBatch.End();
        }

        private Rectangle GetPlanetType(Types.PlanetSize ps)
        {
            Rectangle sourceRect;

            switch(ps)
            {
                case Types.PlanetSize.DwarfPlanet:
                case Types.PlanetSize.Planetoid:
                    sourceRect = galaxyIcons.getIconRectangle(1, 1); //MAGIC NUMBERS
                    break;
                case Types.PlanetSize.SEClass:
                case Types.PlanetSize.EClass:
                    sourceRect = galaxyIcons.getIconRectangle(0, 2);
                    break;
                case Types.PlanetSize.NClass:
                case Types.PlanetSize.JClass:
                case Types.PlanetSize.SJClass:
                    sourceRect = galaxyIcons.getIconRectangle(2, 1);
                    break;
                default:
                    sourceRect = galaxyIcons.getIconRectangle(0, 2);
                    break;
            }

            return sourceRect;
        }

        private void DrawBaseView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
        }

        private void DrawScienceView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
        }

        private void DrawPersonnelView(SpriteBatch spriteBatch)
        {
            base.backgroundColor = Color.Black;
        }
    }
}
