using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGame1.Obstacles;

namespace TestGame1.Logic
{
    class Collisions
    {
        private static bool isTop = false;
        private bool wasTop = false;
        private float obstacleTrueLeft;
        private float obstacleTrueRight;
        private float obstacleTrueUp;
        public void TestCollisions(ObstacleList obstacle)
        {


            foreach (var e in obstacle.obstacles)
            {

                obstacleTrueLeft = e.ObstaclePosition.X;
                obstacleTrueRight = e.ObstaclePosition.X + e.ObstacleTexture.Width;
                obstacleTrueUp = e.ObstaclePosition.Y - e.ObstacleTexture.Height / 2;
                if (e.ObstaclePosition.X - Player.PlayerTrueRightX < 30 && e.ObstaclePosition.X - Player.PlayerTrueRightX > -30)
                {
                    if ((Player.PlayerTrueRightX > obstacleTrueLeft-8) &&
                        (Player.PlayerTrueRightX < obstacleTrueLeft +10) &&
                        (Player.PlayerTrueUpY > obstacleTrueUp + 30))
                    {

                        Player.canMoveRight = false;
                    }
                    else
                    {
                        Player.canMoveRight = true;
                    }
                }
               

                if (Player.PlayerTrueLeftX - obstacleTrueRight < 20 && Player.PlayerTrueLeftX - obstacleTrueRight > -16)
                {
                    if ((Player.PlayerTrueLeftX > obstacleTrueRight -10) &&
                      (Player.PlayerTrueLeftX < obstacleTrueRight+10) &&
                      (Player.PlayerTrueUpY > obstacleTrueUp + 30))
                    {


                        Player.canMoveLeft = false;
                    }
                    else
                    {
                        Player.canMoveLeft = true;
                    }

                }
                if ((Player.PlayerTrueRightX > obstacleTrueLeft + 10) &&
                     (Player.PlayerTrueLeftX < obstacleTrueRight -10) &&
                    (Player.PlayerTrueUpY > obstacleTrueUp))
                {

                    Player.PlayerPosition.Y = obstacleTrueUp + 25;
                    isTop = true;
                    Player.timeToFall = 0;
                    Player.isJumping = false;
                    Player.countJump = 0;
                }
                else { isTop = false; }
                if (!isTop && wasTop && Player.PlayerPosition.Y > e.ObstaclePosition.Y - e.ObstacleTexture.Height / 2 + 24)
                {
                    Player.isFalling = true;
                    Player.timeToFall = 0;
                    Player.isJumping = false;
                }
                wasTop = isTop;
            }
        }

    }
}
