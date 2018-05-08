using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1.Obstacles
{
    class ObstacleList:DummyClass
    {
        public List<Obstacle> obstacles = new List<Obstacle>();

        
        public override void Load(ContentManager content)
        {


            obstacles.Add(new Obstacle(new Vector2(1010, 600)));
            obstacles.Add(new Obstacle(new Vector2(2000, 600)));
            obstacles.Add(new Obstacle(new Vector2(3010, 600)));
            obstacles.Add(new Obstacle(new Vector2(4000, 600)));
            obstacles.Add(new Obstacle(new Vector2(5010, 600)));
            obstacles.Add(new Obstacle(new Vector2(6000, 600)));
            foreach (var e in obstacles) {
                e.Load(content);

            }
        }
        public override void Update(GameTime gametime)
        {

            foreach (var e in obstacles) {

                e.Update(gametime);
            }

            


        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            foreach (var e in obstacles) {

                e.Draw(spriteBatch);
            }

        }
    }
}
