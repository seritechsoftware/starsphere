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
    class MainControlWindow : DisplayWindow
    {
        const int buttonArrayWidth = 5;
        const int buttonArrayHeight = 3;

        Texture2D buttonGridTex;
        SpriteFont debugFont;

        private int gridTexWidth = 9;
        private int gridTexHeight = 6;
        private int tileWidth;
        private int tileHeight;

        private int buttonWidth;
        private int buttonHeight;
        private Rectangle[] buttons;
        private int buttonHoveredNum = -1; // -1 if nothing
        private int buttonClickedNum = -1; // -1 if nothing

        //use parent class constructor
        public MainControlWindow(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            buttons = new Rectangle[buttonArrayHeight * buttonArrayWidth];

            buttonWidth = (int)Window.Width / buttonArrayWidth;
            buttonHeight = (int)Window.Height / buttonArrayHeight;

            for (int i = 0; i < buttonArrayWidth; i++)
            {
                for (int j = 0; j < buttonArrayHeight; j++)
                {
                    buttons[j * buttonArrayWidth + i] = new Rectangle(Window.X + i * buttonWidth, Window.Y + j * buttonHeight, buttonWidth, buttonHeight);
                }
            }
        }  

        public void LoadTexture(Texture2D buttonGridTexture, SpriteFont font)
        {
            buttonGridTex = buttonGridTexture;
            tileWidth = buttonGridTex.Width / gridTexWidth;
            tileHeight = buttonGridTex.Height / gridTexHeight;
            debugFont = font;
        }

        private int GetButtonNum(int x, int y)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Contains(x, y))
                    return i;
            }

            return -1;
        }

        public override void MouseOver(MouseState mouseState)
        {
            base.MouseOver(mouseState);
            buttonHoveredNum = GetButtonNum(mouseState.X, mouseState.Y);
        }

        public override void MouseDown(MouseState mouseState)
        {
            buttonClickedNum = GetButtonNum(mouseState.X, mouseState.Y);
        }

        public override void MouseUp(MouseState mouseState)
        {
            if (buttonClickedNum != -1)
            {
                int returnVal = buttonClickedNum;
            }
            
            buttonClickedNum = -1;
        }

        public override void MouseClick(MouseState mouseState)
        {

        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            //draw base window
            base.Draw(spriteBatch);

            Rectangle sourceRectangle; 

            spriteBatch.Begin();

            int buttonTypeAdjustment = 0; //Change the tile you use if the button is hovered or clicked. 
            for (int i = 0; i < buttonArrayWidth; i++)
            {
                for (int j = 0; j < buttonArrayHeight; j++)
                {
                    int buttonNum = j * buttonArrayWidth + i;
                    buttonTypeAdjustment = 0;
                    
                    if (buttonClickedNum == buttonNum)
                    {
                        buttonTypeAdjustment = 1;
                    }
                    else if (buttonHoveredNum == buttonNum)
                    {
                        buttonTypeAdjustment = 2;
                    }

                    sourceRectangle = new Rectangle((int)((float)buttonNum/(float)gridTexHeight)*tileWidth*3 + tileWidth*buttonTypeAdjustment, (buttonNum % gridTexHeight) * tileHeight, tileWidth, tileHeight);
                    spriteBatch.Draw(buttonGridTex, buttons[buttonNum], sourceRectangle, Color.White);
                }
            }


            //Debug Crap
            //spriteBatch.DrawString(debugFont, "Mouse Over Button: " + buttonHoveredNum.ToString(), new Vector2(0, 0), Color.White);

            spriteBatch.End();

        }
        

    }
}
