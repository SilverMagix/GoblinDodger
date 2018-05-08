using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame1.Obstacles.Moving
{
   
    class EnemyLeft : Enemy
    {
        //Enemy stats
        public bool isActive = true;
        public Texture2D EnemyTexture;
        public static ContentManager content;

        //Speed-related variables




        public EnemyLeft(Vector2 EnemyPosition, int Level = 0) : base(EnemyPosition, Level)
        {



        }





        public override void Load(ContentManager content)
        {

            EnemyLeft.content = content;
            switch (Level) {
                case (int)EnemyType.Goblin:
            EnemyTexture = content.Load<Texture2D>("Goblin/goblinLeft");
            EnemyRectangle = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyTexture.Width, EnemyTexture.Height);
                    break;
                case (int)EnemyType.Bird:
                    EnemyTexture = content.Load<Texture2D>("Goblin/birdLeft");
                    EnemyRectangle = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyTexture.Width, EnemyTexture.Height);
                    break;
                case (int)EnemyType.Fly:
                    EnemyTexture = content.Load<Texture2D>("Goblin/flyLeft");
                    EnemyRectangle = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyTexture.Width, EnemyTexture.Height);
                    break;
            }

        }

        public override void Update(GameTime gametime)
        {

            EnemyPosition.X -= enemySpeed * gametime.ElapsedGameTime.Milliseconds;


            base.Update(gametime);
            if (EnemyPosition.X < Floor.tiles[0].TilePosition.X - 100)
            {
                isActive = false;

            }
            EnemyRectangle.X = (int)EnemyPosition.X;
            EnemyRectangle.Y = (int)EnemyPosition.Y;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EnemyTexture, EnemyPosition, Color.White);
        }


    }
}
