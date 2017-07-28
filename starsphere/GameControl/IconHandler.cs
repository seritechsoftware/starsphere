using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Starphere.GameControl
{
    class IconHandler
    {
        private int tileWidth, tileHeight;
        private int textureWidth, textureHeight;
        private int gridWidth, gridHeight;
        private Texture2D iconTextureGrid;

        public IconHandler(Texture2D texture, int gWidth, int gHeight)
        {
            iconTextureGrid = texture;
            textureWidth = texture.Width;
            textureHeight = texture.Height;

            gridWidth = gWidth;
            gridHeight = gHeight;

            tileWidth = textureWidth / gridWidth;
            tileHeight = textureHeight / gridHeight;
        }

        public Texture2D iconTexture
        {
            get
            {
                return iconTextureGrid;
            }
        }

        public int textureTileWidth
        {
            get
            {
                return tileWidth;
            }
        }

        public int textureTileHeight
        {
            get
            {
                return tileHeight;
            }
        }

        public Rectangle getIconRectangle(int x, int y)
        {
            Rectangle returnVal = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);

            return returnVal;
        }

        //Icon num is 0 based. 
        public Rectangle getIconRectangle(int iconNum)
        {
            return getIconRectangle(iconNum % gridWidth, (int)(iconNum / gridWidth));
        }
    }
}
