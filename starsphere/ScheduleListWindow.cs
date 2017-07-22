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
    class ScheduleListWindow : DisplayWindow
    {
        private DateTime currentInGameTime;
        private SpriteFont timeFont;

        public ScheduleListWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {

        }

        public void LoadTexture(SpriteFont font)
        {
            timeFont = font;
        }

        public DateTime DisplayedTime
        {
            get
            {
                return currentInGameTime;
            }

            set
            {
                currentInGameTime = value;
            }
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


            spriteBatch.Begin();

            //Drawing goes here:
            int textX = base.Window.X;
            int textY = base.Window.Y;
            spriteBatch.DrawString(timeFont, currentInGameTime.ToShortTimeString(), new Vector2(textX, textY), Color.White);
            spriteBatch.DrawString(timeFont, currentInGameTime.ToShortDateString(), new Vector2(textX, textY + timeFont.LineSpacing), Color.White);

            spriteBatch.End();

        }
    }
}
