using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestGame1.Obstacles.Moving;

namespace TestGame1.HUD
{
    class Score : DummyClass
    {

        public Vector2 ScorePosition = new Vector2(20, 20);
        public Vector2 LivesPosition = new Vector2(20, 65);
        public Vector2 ScoreBoardPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 400, Game1.graphics.PreferredBackBufferHeight / 2 - 400);
        public Vector2 GoblinPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 250);
        public Vector2 BirdPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 150);
        public Vector2 FlyPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 50);
        public Vector2 ReadPosition1 = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 380);
        public Vector2 ReadPosition2 = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 100, Game1.graphics.PreferredBackBufferHeight / 2 - 250);
        public Vector2 ReadPosition3 = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 100, Game1.graphics.PreferredBackBufferHeight / 2 - 150);
        public Vector2 ReadPosition4 = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 100, Game1.graphics.PreferredBackBufferHeight / 2 - 50);
        public Texture2D ScoreBoard;
        public Texture2D TextureGoblin;
        public Texture2D TextureBird;
        public Texture2D TextureFly;
        public SpriteFont ScoreFont;
        public string ScoreNumber;
        public string LivesNumber;
        public double time;
        public string lives;
        public StreamReader docRead;
        string[] list;
        int i = 0;
        public override void Load(ContentManager content)
        {

            ScoreFont = content.Load<SpriteFont>("HUD/Score");
            ScoreBoard = content.Load<Texture2D>("HUD/ScoreBoard");
            TextureGoblin = content.Load<Texture2D>("Goblin/goblinRight");
            TextureBird = content.Load<Texture2D>("Bird/birdRight");
            TextureFly = content.Load<Texture2D>("Fly/flyRight");
            LivesNumber = Player.lives.ToString();
        }
        public override void Update(GameTime gametime)
        {
            if (Player.isActive)
            {
                time += gametime.ElapsedGameTime.TotalSeconds;
                lives = Player.lives.ToString();
            }
            else { lives = "0"; }
            ScoreNumber = "Score: " + (int)time;
            LivesNumber = "Health: " + lives + "%";
            if (time > 120) {
                Player.isWon = true;
                Player.isActive = false;
            }


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Player.isWon)
            {

                spriteBatch.DrawString(ScoreFont, LivesNumber, LivesPosition, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);

                if (!Player.isActive)
                {
                    if (i < 1)
                    {
                        list = File.ReadAllLines(EnemyList.filename);
                        i++;
                        GoblinPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 250);
                        BirdPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 150);
                        FlyPosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 200, Game1.graphics.PreferredBackBufferHeight / 2 - 50);
    }
                    spriteBatch.Draw(ScoreBoard, ScoreBoardPosition, Color.White);
                    spriteBatch.DrawString(ScoreFont, list[0], ReadPosition1, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(ScoreFont, list[1], ReadPosition2, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(ScoreFont, list[2], ReadPosition3, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(ScoreFont, list[3], ReadPosition4, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(TextureBird, BirdPosition, Color.White);
                    spriteBatch.Draw(TextureGoblin, GoblinPosition, Color.White);
                    spriteBatch.Draw(TextureFly, FlyPosition, Color.White);
                    ScorePosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 300, Game1.graphics.PreferredBackBufferHeight / 2 + 60);
                    ScoreNumber += " seconds";
                }
                spriteBatch.DrawString(ScoreFont, ScoreNumber, ScorePosition, Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);

            }
            else {
                ScoreNumber = "Congratz you won!";
                ScorePosition = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 210, Game1.graphics.PreferredBackBufferHeight / 2 - 30);
                spriteBatch.Draw(ScoreBoard, ScoreBoardPosition, Color.White);
                spriteBatch.DrawString(ScoreFont, ScoreNumber, ScorePosition, Color.Orange, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            }
            if (time < 10) {
                GoblinPosition = new Vector2(50,150);
                BirdPosition = new Vector2(50,250);
                FlyPosition = new Vector2(50,350);
                spriteBatch.Draw(TextureBird, BirdPosition, Color.White);
                spriteBatch.Draw(TextureGoblin, GoblinPosition, Color.White);
                spriteBatch.Draw(TextureFly, FlyPosition, Color.White);
                spriteBatch.DrawString(ScoreFont, "-10", new Vector2(150, 150), Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(ScoreFont, "-20", new Vector2(150, 250), Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(ScoreFont, "-30", new Vector2(150, 350), Color.Black, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);

            }

        }
    }
}
