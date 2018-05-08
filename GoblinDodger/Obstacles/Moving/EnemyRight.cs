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
    class EnemyRight : Enemy
    {
        //Enemy stats
        public bool isActive = true;
        public Texture2D EnemyTexture;

        public static ContentManager content;



        public EnemyRight(Vector2 EnemyPosition, int Level = 1) : base(EnemyPosition, Level)
        {



        }





        public override void Load(ContentManager content)
        {

            EnemyRight.content = content;



            EnemyTexture = content.Load<Texture2D>("Goblin/goblinRight");

            EnemyRectangle = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyTexture.Width, EnemyTexture.Height);
        }

        public override void Update(GameTime gametime)
        {

            EnemyPosition.X += enemySpeed * gametime.ElapsedGameTime.Milliseconds;


            base.Update(gametime);
            if (EnemyPosition.X > 6000)
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
