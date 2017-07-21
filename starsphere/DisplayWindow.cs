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
    class DisplayWindow
    {
        private Rectangle windowRect;
        private Rectangle topBorderRect, leftBorderRect, rightBorderRect, bottomBorderRect;

        private Texture2D windowTex;
        private Texture2D horzBorderTex;
        private Texture2D vertBorderTex;

        private Color hoverColor;
        private bool mouseOn;

        public DisplayWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture)
        {
            windowRect = new Rectangle(x, y, width, height);
            topBorderRect = new Rectangle(x-(int)borderWidth, y-borderWidth, width + borderWidth*2, borderWidth);
            leftBorderRect = new Rectangle(x-borderWidth, y, borderWidth, height);
            rightBorderRect = new Rectangle(x + width, y, borderWidth, height);
            bottomBorderRect = new Rectangle(x - (int)borderWidth, y + height, width + borderWidth*2, borderWidth);

            windowTex = windowTexture;
            horzBorderTex = horzBorderTexture;
            vertBorderTex = vertBorderTexture;
            hoverColor = Color.White;
            mouseOn = false;
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
                spriteBatch.Draw(horzBorderTex, topBorderRect, null, hoverColor, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
                spriteBatch.Draw(horzBorderTex, bottomBorderRect, null, hoverColor, 0.0f, new Vector2(0, 0), SpriteEffects.FlipVertically, 0.0f);
                spriteBatch.Draw(vertBorderTex, leftBorderRect, null, hoverColor, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
                spriteBatch.Draw(vertBorderTex, rightBorderRect, null, hoverColor, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            }

            spriteBatch.End();
        }


        //Placeholders for the children class methods.
        public virtual void MouseOver(MouseState mouseState)
        {
            mouseOn = true;
            hoverColor = Color.Green;
        }

        public virtual void MouseDown(MouseState mouseState)
        {
        }

        public virtual void MouseUp(MouseState mouseState)
        {
        }

        public virtual void MouseClick(MouseState mouseState)
        { 
        }

        public virtual void MouseOff(MouseState mouseState)
        {
            mouseOn = false;
            hoverColor = Color.White;
        }

    }
}
