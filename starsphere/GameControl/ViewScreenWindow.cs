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
    class ViewScreenWindow : DisplayWindow
    {
        private GameOptions.DisplayMode currentDisplay;
        private SpriteFont detailFont;
        private Texture2D galaxyTextures;

        public ViewScreenWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            currentDisplay = GameOptions.DisplayMode.galaxyView;
        }

        public void LoadTexture(Texture2D galaxyViewTextures, SpriteFont font)
        {
            galaxyTextures = galaxyViewTextures;
            detailFont = font;
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
