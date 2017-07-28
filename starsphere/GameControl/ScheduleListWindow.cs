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
    class ScheduleListWindow : DisplayWindow
    {
        private DateTime currentInGameTime;

        private SpriteFont timeFont;

        private IconHandler buttonIcons;
        private IconHandler displayIcons;

        private Rectangle buttonPause, buttonForward, buttonFast;
        private int buttonPauseNum = 2, buttonForwardNum = 1, buttonFastNum = 0;
        private int buttonPressedNum = 1;

        private Rectangle vertTimeLineTop, vertTimeLine, vertTimeLineBottom;
        private Rectangle horzTimeLine;

        private int midLine;

        private Rectangle timeBox;
        private int textX;
        private int textY;

        public ScheduleListWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            //Create buttons for speed control
            int buttonXStart = x + 3 * (int)(width / 4);
            int buttonWidth = (int)(width / 4) / 3;
            int buttonHeight = buttonWidth;
            int buttonYStart = y;

            buttonPause = new Rectangle(buttonXStart, buttonYStart, buttonWidth, buttonHeight);
            buttonForward = new Rectangle(buttonXStart + buttonWidth, buttonYStart, buttonWidth, buttonHeight);
            buttonFast = new Rectangle(buttonXStart + buttonWidth * 2, buttonYStart, buttonWidth, buttonHeight);


            //Create time lines
            int vertTimeLineY = y;
            int vertTimeLineX = x + width / 10;
            int lineWidth = 64;
            vertTimeLineTop = new Rectangle(vertTimeLineX, vertTimeLineY, lineWidth, lineWidth);
            vertTimeLine = new Rectangle(vertTimeLineX, vertTimeLineY + lineWidth, lineWidth, height - lineWidth);
            vertTimeLineBottom = new Rectangle(vertTimeLineX, vertTimeLineY + height - lineWidth, lineWidth, lineWidth);

            midLine = (int)(height / 2) - (int)(lineWidth / 2);
            //horzTimeLineLeft = new Rectangle(x, y + midLine , lineWidth, lineWidth);
            horzTimeLine = new Rectangle(x, y + midLine, width, lineWidth);
            //horzTimeLineRight = new Rectangle(x + width - lineWidth, y + midLine, lineWidth, lineWidth);

            timeBox = new Rectangle(x, y, vertTimeLine.Right + lineWidth - x, lineWidth * 3 / 2);

        }

        public void LoadTexture(Texture2D buttonTex, Texture2D timeLineTex, SpriteFont font)
        {
            buttonIcons = new IconHandler(buttonTex, 3, 6);
            displayIcons = new IconHandler(timeLineTex, 3, 6);

            timeFont = font;

            textX = base.Window.X + timeFont.LineSpacing / 2;
            textY = base.Window.Y + timeFont.LineSpacing / 2;
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
            //Check pause button
            if (buttonPause.Contains(mouseState.X, mouseState.Y))
            {
                buttonPressedNum = buttonPauseNum;
            }
            //Check forward button
            else if (buttonForward.Contains(mouseState.X, mouseState.Y))
            {
                buttonPressedNum = buttonForwardNum;
            }
            //Check fast button
            else if (buttonFast.Contains(mouseState.X, mouseState.Y))
            {
                buttonPressedNum = buttonFastNum;
            }
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

            //Begin Drawing
            spriteBatch.Begin();

            //Drawing goes here:
            Rectangle sourceRectangle;

            //Draw current time marker line
            //Draw line
            sourceRectangle = displayIcons.getIconRectangle(0, 2);
            spriteBatch.Draw(displayIcons.iconTexture, vertTimeLine, sourceRectangle, Color.White);
            //Draw Top of Line
            sourceRectangle = displayIcons.getIconRectangle(0, 1);
            spriteBatch.Draw(displayIcons.iconTexture, vertTimeLineTop, sourceRectangle, Color.White);
            //Draw bottom of line
            sourceRectangle = displayIcons.getIconRectangle(0, 3);
            spriteBatch.Draw(displayIcons.iconTexture, vertTimeLineBottom, sourceRectangle, Color.White);


            //Draw time line
            //Draw line
            sourceRectangle = displayIcons.getIconRectangle(1, 0);
            spriteBatch.Draw(displayIcons.iconTexture, horzTimeLine, sourceRectangle, Color.White);
            /*Draw Left of Line
            sourceRectangle = displayIcons.getIconRectangle(0, 0);
            spriteBatch.Draw(displayIcons.iconTexture, horzTimeLineLeft, sourceRectangle, Color.White);
            //Draw Right of line
            sourceRectangle = displayIcons.getIconRectangle(2, 0);
            spriteBatch.Draw(displayIcons.iconTexture, horzTimeLineRight, sourceRectangle, Color.White);*/


            //Draw the time
            sourceRectangle = displayIcons.getIconRectangle(1, 3);
            spriteBatch.Draw(displayIcons.iconTexture, timeBox, sourceRectangle, Color.White);
            spriteBatch.DrawString(timeFont, currentInGameTime.ToShortTimeString(), new Vector2(textX, textY), Color.White);
            spriteBatch.DrawString(timeFont, currentInGameTime.ToShortDateString(), new Vector2(textX, textY + timeFont.LineSpacing), Color.White);

            //TODO: Draw event markers

            //Draw the buttons
            //Draw pause button
            if (buttonPressedNum == buttonPauseNum)
                sourceRectangle = buttonIcons.getIconRectangle(1, 2);
            else
                sourceRectangle = buttonIcons.getIconRectangle(0, 2);

            spriteBatch.Draw(buttonIcons.iconTexture, buttonPause, sourceRectangle, Color.White);

            //Draw forward button
            if (buttonPressedNum == buttonForwardNum)
                sourceRectangle = buttonIcons.getIconRectangle(1, 1);
            else
                sourceRectangle = buttonIcons.getIconRectangle(0, 1);

            spriteBatch.Draw(buttonIcons.iconTexture, buttonForward, sourceRectangle, Color.White);

            //Draw fast button
            if (buttonPressedNum == buttonFastNum)
                sourceRectangle = buttonIcons.getIconRectangle(1, 0);
            else
                sourceRectangle = buttonIcons.getIconRectangle(0, 0);

            spriteBatch.Draw(buttonIcons.iconTexture, buttonFast, sourceRectangle, Color.White);


            //End Drawing
            spriteBatch.End();

        }
    }
}
