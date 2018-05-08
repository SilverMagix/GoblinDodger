using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1.Obstacles.Moving
{


    class EnemyList : DummyClass
    {
        public List<EnemyLeft> enemyLeft = new List<EnemyLeft>();
        public List<EnemyRight> enemyRight = new List<EnemyRight>();
        StreamWriter doc;
        StreamReader docRead;
        FileStream fileAppend;
        
        string[] stats = new string[4];
        static public string filename = @"Stats\Stats.txt";
        public int timeTospawn;
        public int switch1;
        public Random random = new Random();
        public int maxLevel = 1;
        public override void Load(ContentManager content)
        {

            filename = Path.GetFullPath(filename);
            fileAppend = new FileStream(filename, FileMode.Create);
            
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            doc = new StreamWriter(fileAppend);
            //docRead = new StreamReader(filename);
            stats[0] = "You got hit by:";
            stats[1] = "Goblins: 0";
            stats[2] = "Bird: 0";
            stats[3] = "Flies: 0";
            for (int i = 0; i < 4; i++) {
                doc.WriteLine(stats[i]); }
          
            doc.Close();
            
            
            enemyLeft.Add(new EnemyLeft(new Vector2(-100, 0)));
            enemyRight.Add(new EnemyRight(new Vector2(-100, 0)));
            enemyLeft[0].Load(content);
            enemyRight[0].Load(content);
            enemyLeft[0].isActive = false;
            enemyRight[0].isActive = false;

        }
        public override void Update(GameTime gametime)
        {
            if ((int)gametime.TotalGameTime.TotalSeconds % 20 == 0 && (int)gametime.TotalGameTime.TotalSeconds != 0)
            {
                Enemy.enemySpeed += 0.005f;
                if (maxLevel < 2)
                {
                    maxLevel++;
                }
                if (maxLevel < 3 && gametime.TotalGameTime.TotalSeconds > 40)
                {
                    maxLevel++;
                }
            }
            timeTospawn += gametime.ElapsedGameTime.Milliseconds;
            if (timeTospawn > 600)
            {
                switch1 = random.Next(0, 2);
                if (switch1 == 1)
                {
                    EnemyLeft tempLeft;
                    enemyLeft.Add(new EnemyLeft(new Vector2(Floor.tiles[Floor.tiles.Count - 1].TilePosition.X + 100, random.Next(0, 790)), random.Next(0, maxLevel)));
                    tempLeft = enemyLeft[enemyLeft.Count - 1];

                    switch (enemyLeft[enemyLeft.Count - 1].Level)
                    {
                        case (int)EnemyType.Goblin:
                            tempLeft.EnemyTexture = EnemyRight.content.Load<Texture2D>("Goblin/goblinLeft");
                            tempLeft.EnemyRectangle = new Rectangle((int)tempLeft.EnemyPosition.X, (int)tempLeft.EnemyPosition.Y, tempLeft.EnemyTexture.Width, tempLeft.EnemyTexture.Height);
                            break;
                        case (int)EnemyType.Bird:
                            tempLeft.EnemyTexture = EnemyRight.content.Load<Texture2D>("Bird/birdLeft");
                            tempLeft.EnemyRectangle = new Rectangle((int)tempLeft.EnemyPosition.X, (int)tempLeft.EnemyPosition.Y, tempLeft.EnemyTexture.Width, tempLeft.EnemyTexture.Height);
                            break;
                        case (int)EnemyType.Fly:
                            tempLeft.EnemyTexture = EnemyRight.content.Load<Texture2D>("Fly/flyLeft");
                            tempLeft.EnemyRectangle = new Rectangle((int)tempLeft.EnemyPosition.X, (int)tempLeft.EnemyPosition.Y, tempLeft.EnemyTexture.Width, tempLeft.EnemyTexture.Height);
                            break;
                    }
                }
                else
                {
                    if (gametime.TotalGameTime.TotalSeconds > 5)
                    {
                        EnemyRight tempRight;
                        enemyRight.Add(new EnemyRight(new Vector2(Floor.tiles[0].TilePosition.X - 50, random.Next(0, 790)), random.Next(0, maxLevel)));
                        tempRight = enemyRight[enemyRight.Count - 1];
                        switch (enemyRight[enemyRight.Count - 1].Level)
                        {
                            case (int)EnemyType.Goblin:
                                tempRight.EnemyTexture = EnemyRight.content.Load<Texture2D>("Goblin/goblinRight");
                                tempRight.EnemyRectangle = new Rectangle((int)tempRight.EnemyPosition.X, (int)tempRight.EnemyPosition.Y, tempRight.EnemyTexture.Width, tempRight.EnemyTexture.Height);
                                break;
                            case (int)EnemyType.Bird:
                                tempRight.EnemyTexture = EnemyRight.content.Load<Texture2D>("Bird/birdRight");
                                tempRight.EnemyRectangle = new Rectangle((int)tempRight.EnemyPosition.X, (int)tempRight.EnemyPosition.Y, tempRight.EnemyTexture.Width, tempRight.EnemyTexture.Height);
                                break;
                            case (int)EnemyType.Fly:
                                tempRight.EnemyTexture = EnemyRight.content.Load<Texture2D>("Fly/flyRight");
                                tempRight.EnemyRectangle = new Rectangle((int)tempRight.EnemyPosition.X, (int)tempRight.EnemyPosition.Y, tempRight.EnemyTexture.Width, tempRight.EnemyTexture.Height);
                                break;
                        }
                    }
                }
                timeTospawn = 0;
            }
           
            checkIfDead(gametime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            foreach (var e in enemyRight)
            {

                e.Draw(spriteBatch);

            }
            foreach (var e in enemyLeft)
            {

                e.Draw(spriteBatch);

            }
        }

        public void checkIfDead(GameTime gametime)
        {

            foreach (var e in enemyRight)
            {
                e.Update(gametime);
                if (e.EnemyRectangle.Intersects(Player.PlayerRectangle))
                {
                    e.isActive = false;

                    string number = stats[e.Level + 1].Substring(stats[e.Level + 1].ToString().LastIndexOf(":") + 2).ToString();
                    stats[e.Level + 1] = stats[e.Level + 1].Substring(0, stats[e.Level + 1].ToString().LastIndexOf(":") + 1) + " " + (Int32.Parse(number) + 1);
                    File.WriteAllLines(filename, stats);
                    Player.lives -= (e.Level + 1) * 10;
                }
            }
            foreach (var e in enemyLeft)
            {

                e.Update(gametime);
                if (e.EnemyRectangle.Intersects(Player.PlayerRectangle))
                {
                    e.isActive = false;
                    
                    string number = stats[e.Level + 1].Substring(stats[e.Level + 1].ToString().LastIndexOf(":") + 2).ToString();
                    stats[e.Level + 1] = stats[e.Level + 1].Substring(0, stats[e.Level + 1].ToString().LastIndexOf(":") + 1) + " " + (Int32.Parse(number) + 1);
                    File.WriteAllLines(filename, stats);
                    Player.lives -= (e.Level + 1) * 10;
                }
            }

            for (int i = 0; i < enemyRight.Count; i++)
            {

                if (!enemyRight[i].isActive)
                {
                    enemyRight.RemoveAt(i);
                }

            }
            for (int i = 0; i < enemyLeft.Count; i++)
            {

                if (!enemyLeft[i].isActive)
                {
                    enemyLeft.RemoveAt(i);
                }

            }

        }
    }
}
