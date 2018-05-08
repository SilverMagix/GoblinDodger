using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1.Backgrounds
{
    abstract class BackgroundTiles
    {
        public Vector2 BackgroundPosition;
        public Texture2D BackgroundLayer;
        public string path;
       

        public BackgroundTiles(string path,Vector2 position) {

            this.path = path;
            BackgroundPosition = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundLayer, BackgroundPosition, null, Color.White, 0f, Vector2.Zero, 5f, SpriteEffects.None, 0f);
        }

        public virtual void Load(ContentManager content)
        {
            BackgroundLayer = content.Load<Texture2D>(path);
        }

      

        public virtual void Update(GameTime gametime)
        {
            if (Player.limitRight)
            {

                BackgroundPosition.X -= Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }
            if (Player.limitLeft)
            {

                BackgroundPosition.X += Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }
        }
    }
}
