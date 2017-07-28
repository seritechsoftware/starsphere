using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Starsphere.GameControl
{
    class DetailListWindow : DisplayWindow
    {
        private GameOptions.DetailMode currentDisplay;

        private SpriteFont displayFont;
        private Vector2 displayCorner;
        private Color fontColor;

        public DetailListWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
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
