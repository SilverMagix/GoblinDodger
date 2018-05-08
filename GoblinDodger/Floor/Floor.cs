
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame1
{
    class Floor
    {

        static public List<Tile> tiles = new List<Tile>();
        ContentManager content;

        private bool done = false;

        public void Initialize( ContentManager content) {
            this.content = content;
            
            float tempY = Game1.graphics.PreferredBackBufferHeight - content.Load<Texture2D>("Tile").Height / 4 * 2;
            tiles.Add(new Tile(new Vector2(0, tempY)));
            while(tiles[tiles.Count - 1].TilePosition.X<Game1.graphics.PreferredBackBufferWidth) {
                tiles.Add(new Tile(new Vector2(tiles[tiles.Count - 1].TilePosition.X + content.Load<Texture2D>("Tile").Width-1, tiles[0].TilePosition.Y)));
                
            }
        }

        public void Load() {       
            tiles[0].Load(content);
        }

        public void Update(GameTime gametime) {

            if (!done)
            {

                while (tiles[tiles.Count - 1].TilePosition.X < 7500)
                {

                    tiles.Add(new Tile(new Vector2(tiles[tiles.Count - 1].TilePosition.X + Tile.TileTexture.Width, tiles[0].TilePosition.Y)));

                }

                done = true;


            }

            if (Player.limitRight)
            {

                foreach (var e in tiles)
                {
                    e.TilePosition.X -= Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                }
               
            }
            if (Player.limitLeft) {
                foreach (var e in tiles)
                {
                    e.TilePosition.X += Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                }
               
            }

           
           
            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var e in tiles)
            {
                spriteBatch.Draw(Tile.TileTexture, e.TilePosition, Color.White);
            }
        }

    }
}
