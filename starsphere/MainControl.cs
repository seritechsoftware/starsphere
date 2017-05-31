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
    class MainControl : DisplayWindow
    {
        const int buttonArrayWidth = 5;
        const int buttonArrayHeight = 3;

        Texture2D buttonGridTex;
        private int gridTexWidth = 6;
        private int gridTexHeight = 6;
        private int tileWidth;
        private int tileHeight;
        private Rectangle[] button;

        //use parent class constructor
        public MainControl(int x, int y, int width, int height, int borderWidth, Texture2D windowTexture, Texture2D horzBorderTexture, Texture2D vertBorderTexture) : base(x, y, width, height, borderWidth, windowTexture, horzBorderTexture, vertBorderTexture)
        {
            button = new Rectangle[buttonArrayHeight * buttonArrayWidth];

            int buttonWidth = (int)Window.Width / buttonArrayWidth;
            int buttonHeight = (int)Window.Height / buttonArrayHeight;

            for (int i = 0; i < buttonArrayWidth; i++)
            {
                for (int j = 0; j < buttonArrayHeight; j++)
                {
                    button[j * buttonArrayWidth + i] = new Rectangle(Window.X + i * buttonWidth, Window.Y + j * buttonHeight, buttonWidth, buttonHeight);
                }
            }
        }  

        public void LoadTexture(Texture2D buttonGridTexture)
        {
            buttonGridTex = buttonGridTexture;
            tileWidth = buttonGridTex.Width / gridTexWidth;
            tileHeight = buttonGridTex.Height / gridTexHeight;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            //draw base window
            base.Draw(spriteBatch);

            Rectangle sourceRectangle; 

            spriteBatch.Begin();
            
            for (int i = 0; i < buttonArrayWidth; i++)
            {
                for (int j = 0; j < buttonArrayHeight; j++)
                {
                    int buttonNum = j * buttonArrayWidth + i;
                    sourceRectangle = new Rectangle((int)((float)buttonNum/(float)gridTexHeight)*tileWidth*2, (buttonNum % gridTexHeight) * tileHeight, tileWidth, tileHeight);
                    spriteBatch.Draw(buttonGridTex, button[buttonNum], sourceRectangle, Color.White);
                }
            }

            spriteBatch.End();

        }
        

    }
}
