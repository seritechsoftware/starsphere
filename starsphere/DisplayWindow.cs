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
            topBorderRect = new Rectangle(x-(int)borderWidth/2, y-borderWidth, width+borderWidth, borderWidth);
            leftBorderRect = new Rectangle(x-borderWidth, y, borderWidth, height);
            rightBorderRect = new Rectangle(x + width, y, borderWidth, height);
            bottomBorderRect = new Rectangle(x - (int)borderWidth/2, y + height, width + borderWidth, borderWidth);

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

        public Rectangle Window
        {
            get
            {
                return windowRect;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, true);
        }

        public void Draw(SpriteBatch spriteBatch, bool drawBorders)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(windowTex, windowRect, Color.White);
            if (drawBorders)
            {
                spriteBatch.Draw(horzBorderTex, topBorderRect, null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
                spriteBatch.Draw(horzBorderTex, bottomBorderRect, null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipVertically, 0.0f);
                spriteBatch.Draw(vertBorderTex, leftBorderRect, null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
                spriteBatch.Draw(vertBorderTex, rightBorderRect, null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            }

            spriteBatch.End();
        }
    }
}
