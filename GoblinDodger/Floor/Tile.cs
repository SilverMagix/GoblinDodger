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
    class Tile
    {
        public Vector2 TilePosition;
        static public Texture2D TileTexture;
       
        public Tile(Vector2 TilePosition)
        {

            
            this.TilePosition = TilePosition;
           
        }



        public void Load(ContentManager content)
        {
            TileTexture = content.Load<Texture2D>("Tile");
            
        }
    }
}
