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
    public class DetailListWindow : DisplayWindow
    {
        private GameOptions.DetailMode currentDisplay;

        private SpriteFont displayFont;
        private Vector2 displayCorner;
        private Color fontColor;

        private StarSystem currentSystem;

        public DetailListWindow(WindowController wc, int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(wc, x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            base.backgroundColor = Color.Black;
        }

        public void LoadTexture(SpriteFont font)
        {
            currentDisplay = GameOptions.DetailMode.blankInfo;
            displayFont = font;
            displayCorner = new Vector2((float)Window.X + displayFont.LineSpacing, (float)Window.Y + displayFont.LineSpacing); //Give a little border to the writing.
            fontColor = Color.LightGreen;
        }

        public GameOptions.DetailMode DetailWindowMode { get { return currentDisplay; } set { currentDisplay = value; } }
        public StarSystem DisplaySystem { get { return currentSystem; } set { currentSystem = value; } }

        public override void MouseOver(MouseState mouseState)
        {
            base.MouseOver(mouseState);

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
                case GameOptions.DetailMode.blankInfo:
                    DrawBlankInfo(spriteBatch);
                    break;

                case GameOptions.DetailMode.planetInfo:
                    DrawPlanetInfo(spriteBatch);
                    break;

                case GameOptions.DetailMode.starInfo:
                    DrawStarInfo(spriteBatch);
                    break;

            }
        }

        private void PrintTextLines(SpriteBatch spriteBatch, params string[] list)
        {
            spriteBatch.Begin();

            for (int i = 0; i < list.Length; i++)
            {
                spriteBatch.DrawString(displayFont, list[i], Vector2.Add(displayCorner, new Vector2(0, displayFont.LineSpacing*i)), fontColor);
            }

            spriteBatch.End();
        }

        private void DrawStarInfo(SpriteBatch spriteBatch)
        {
            if (currentSystem.Discovered)
            {
                PrintTextLines(spriteBatch, "Stellar Information Database",
                "Star Name: " + currentSystem.Name,
                "Type: " + currentSystem.Type.ToString(),
                "Color: " + currentSystem.Color,
                "Mass: " + currentSystem.Mass + " Solar Masses",
                "Radius Size: " + currentSystem.Size + " Solar Radii",
                "Luminosity: " + currentSystem.Luminosity.ToString(),
                "Galactic Coordinates: (" + currentSystem.XCoord + ", " + currentSystem.YCoord + ")",
                "Number of Planets: " + currentSystem.NumberOfPlanets,
                "System Searched: " + currentSystem.Searched.ToString()
                );
            }
            else
            {
                PrintTextLines(spriteBatch, "Stellar Information Database",
                    "Star Name: " + currentSystem.Name,
                    "Type: " + currentSystem.Type.ToString(),
                    "Color: " + currentSystem.Color,
                    "Mass: Unknown",
                    "Radius Size: Unknown",
                    "Luminosity: Unknown",
                    "Galactic Coordinates: (" + currentSystem.XCoord + ", " + currentSystem.YCoord + ")",
                    "Number of Planets: Unknown",
                    "System Searched: " + currentSystem.Searched.ToString()
                    );
                }
            
        }

        private void DrawPlanetInfo(SpriteBatch spriteBatch)
        {

        }

        private void DrawBlankInfo(SpriteBatch spriteBatch)
        {
            PrintTextLines(spriteBatch, "StarSphere Control System 0.0.1", "", "Star Chart System - Non functional",
                "Planetary Database - Non functional", "Planetary Sensor Array - Non functional", "--------------------",
                "Base Automation Systems - Non functional", "Personnel Database - Offline", "Sphere Dialing Protocols - Core dump in progress");
        }
    }
}
