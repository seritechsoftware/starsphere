using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace starsphere
{
    class AnimatedSprite
    {

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int AnimationSpeed { get; set; }
        public bool BackAndForth { get; set; }

        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int timeSincePreviousUpdate;
        private bool goingBackward;

        public AnimatedSprite(Texture2D texture, int speed, int rows, int columns, int minTile, int maxTile, bool backAndForth)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            AnimationSpeed = speed;
            BackAndForth = backAndForth;

            currentFrame = minTile;
            startFrame = minTile;
            endFrame = maxTile;

            timeSincePreviousUpdate = 0;
            goingBackward = false;
        }

        public void Update(GameTime gameTime)
        {
            timeSincePreviousUpdate += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSincePreviousUpdate >= AnimationSpeed)
            {
                timeSincePreviousUpdate = 0;

                if (!BackAndForth)
                {
                    currentFrame++;
                    if (currentFrame == endFrame)
                    {
                        currentFrame = startFrame;
                    }
                }
                else
                {
                    if (!goingBackward)
                    {
                        currentFrame++;
                        if (currentFrame == endFrame)
                        {
                            goingBackward = true;
                        }
                    }
                    else
                    {
                        currentFrame--;
                        if (currentFrame == startFrame)
                        {
                            goingBackward = false;
                        }
                    }
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void ForceFrame(int frameNum)
        {
            if (frameNum >= startFrame && frameNum <= endFrame)
            {
                currentFrame = frameNum;
            }
        }
    }
}
