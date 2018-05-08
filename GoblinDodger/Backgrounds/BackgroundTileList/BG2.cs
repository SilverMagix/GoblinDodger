using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1.Backgrounds.BackgroundTileList
{
    class BG2 : BackgroundTiles
    {
        public new static Texture2D BackgroundLayer;
        public static float tilespeed = 0.010f;
        public BG2(string path, Vector2 position) : base(path, position)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundLayer, BackgroundPosition, null, Color.White, 0f, Vector2.Zero, 5.247f, SpriteEffects.None, 0f);
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
            BackgroundLayer = base.BackgroundLayer;
        }

        public override void Update(GameTime gametime)
        {
            if (Player.limitRight)
            {

                BackgroundPosition.X -= Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds * tilespeed;


            }
            if (Player.limitLeft)
            {

                BackgroundPosition.X += Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds * tilespeed;


            }
        }
    }
}
