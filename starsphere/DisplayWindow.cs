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
    class DisplayWindow
    {
        private Rectangle windowRect;
        private Rectangle topBorderRect, leftBorderRect, rightBorderRect, bottomBorderRect;

        private Texture2D windowTex;
        private Texture2D horzBorderTex;
        private Texture2D vertBorderTex;

        public DisplayWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture)
        {
            windowRect = new Rectangle(x, y, width, height);
            topBorderRect = new Rectangle(x-borderWidth, y-borderWidth, width+borderWidth, borderWidth);
            leftBorderRect = new Rectangle(x-borderWidth, y-borderWidth, borderWidth, height+borderWidth*2);
            rightBorderRect = new Rectangle(x + width, y-borderWidth, borderWidth, height + borderWidth*2);
            bottomBorderRect = new Rectangle(x - borderWidth, y + height, width + borderWidth, borderWidth);

            windowTex = windowTexture;
            horzBorderTex = horzBorderTexture;
            vertBorderTex = vertBorderTexture;
        }

        public int Height
        {
            get
            {
                return windowRect.Height;
            }
        }

        public int Width
        {
            get
            {
                return windowRect.Width;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(windowTex, windowRect, Color.White);
            spriteBatch.Draw(horzBorderTex, topBorderRect, Color.White);
            spriteBatch.Draw(horzBorderTex, bottomBorderRect, Color.White);
            spriteBatch.Draw(vertBorderTex, leftBorderRect, Color.White);
            spriteBatch.Draw(vertBorderTex, rightBorderRect, Color.White);
           
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, bool drawBorders)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(windowTex, windowRect, Color.White);
            if (drawBorders)
            {
                spriteBatch.Draw(horzBorderTex, topBorderRect, Color.White);
                spriteBatch.Draw(horzBorderTex, bottomBorderRect, Color.White);
                spriteBatch.Draw(vertBorderTex, leftBorderRect, Color.White);
                spriteBatch.Draw(vertBorderTex, rightBorderRect, Color.White);
            }
            
            spriteBatch.End();
        }
    }
}
