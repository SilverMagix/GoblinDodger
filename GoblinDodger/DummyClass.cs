using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame1
{
    abstract class DummyClass
    {
        
        public abstract void Update(GameTime gametime);

        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Load(ContentManager content);

    }
}
