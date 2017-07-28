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
    interface Screen
    {
        void LoadContent(ContentManager content);
        void UnloadContent();

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
