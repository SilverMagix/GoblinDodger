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
    public class Obstacle
    {
        public  Vector2 ObstaclePosition;
        public Texture2D ObstacleTexture;
        public Obstacle(Vector2 ObstaclePosition)
        {
            this.ObstaclePosition = ObstaclePosition;
        }
        public void Load(ContentManager content)
        {
            ObstacleTexture = content.Load<Texture2D>("Tile");

        }
        public void Update(GameTime gametime)
        {



            if (Player.limitRight)
            {

                ObstaclePosition.X -= Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }
            if (Player.limitLeft)
            {

                ObstaclePosition.X += Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }




        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ObstacleTexture, ObstaclePosition, Color.White);

        }
    }
}
