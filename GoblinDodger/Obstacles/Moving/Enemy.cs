using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1.Obstacles.Moving
{
    enum EnemyType
    {
        Goblin, Bird, Fly
    }
    abstract class Enemy
    {

        public int Level;
        public Vector2 EnemyPosition;
        public Rectangle EnemyRectangle;
        //Speed-related variables
        public static float enemySpeed = 0.5f;
        public Enemy(Vector2 EnemyPosition, int Level = 1)
        {
            this.Level = Level;
            this.EnemyPosition = EnemyPosition;
        }


        public virtual void Load(ContentManager content)
        {
            

        }
        public virtual void Update(GameTime gametime)
        {



            PlayerRelatedMovement(gametime);

        


        }
       
        public virtual void Draw(SpriteBatch spriteBatch)
        {

          

        }
        public void PlayerRelatedMovement(GameTime gametime)
        {
            if (Player.limitRight)
            {

                EnemyPosition.X -= Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }
            if (Player.limitLeft)
            {

                EnemyPosition.X += Player.playerSpeed * gametime.ElapsedGameTime.Milliseconds;


            }


        }
    }
}

