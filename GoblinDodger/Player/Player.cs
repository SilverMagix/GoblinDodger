using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using TestGame1.Logic;

namespace TestGame1
{
    class Player : DummyClass
    {
        //Texture and Position
        public static Vector2 PlayerPosition = new Vector2(0, 720);
        public static Texture2D PlayerTextureLeft;
        public static Texture2D PlayerTextureRight;
        public static Texture2D PlayerTexture;
        public static Rectangle PlayerRectangle;

        //General Player stats
        public static int lives = 100;
        static public bool isActive = true;
        private KeyboardState previousState = Keyboard.GetState();
        public static bool isWon = false;


        //Gravity-related variables
        public const float TIME_MAX_IN_AIR = 0.18f;
        public static bool isFalling;
        public static bool isJumping;
        public static float timeToFall = 0f;
        private float timeJumping = 0f;
        static public int countJump = 0;
        private float playerAccel = 900f;
        private float playerStartingJumpSpeed = 37f;

        //Player's movements Left-Right
        private bool start = true;
        private int end = 0;
        static public bool limitRight = false;
        static public bool limitLeft = false;
        public static bool canMoveLeft = true;
        public static bool canMoveRight = true;

        //Player
        
        public static float playerSpeed = 1f;
        public static float PlayerTrueRightX;
        public static float PlayerTrueLeftX;
        public static float PlayerTrueUpY;
        public static float PlayerTrueDownY ;

        //Events
        public delegate void MovementHandler(GameTime gametime);

        public MovementHandler PlayerMoves;
       

        public override void Update(GameTime gametime)
        {
            
            Player.limitRight = false;
            Player.limitLeft = false;
            KeyboardState state = Keyboard.GetState();

            Gravity(state, gametime);

            PlayerRelativePosition(state, gametime, start);
            PlayerRelativePosition(state, gametime, start, end);
            if (end == 1) {
                if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) && canMoveRight)
                {
                    PlayerPosition.X += playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                    PlayerTexture = PlayerTextureRight;
                }

                if ((state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) && canMoveLeft)
                {
                    PlayerPosition.X -= playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                    PlayerTexture = PlayerTextureLeft;
                }

                if (PlayerPosition.X < Game1.graphics.PreferredBackBufferWidth / 2 - 100)
                {
                    end = 0;

                }

            }
            
            if (Floor.tiles[0].TilePosition.X >= -21)
            {
                start = true;
                

            }
            if (Floor.tiles[0].TilePosition.X <= -5500)
            {
                end = 1;


            }
            if (PlayerPosition.X > Game1.graphics.PreferredBackBufferWidth / 2 - 100 && end == 0)
            {
                PlayerPosition.X = Game1.graphics.PreferredBackBufferWidth / 2 - 100;
                start = false;
            }
            if (PlayerPosition.X < Game1.graphics.PreferredBackBufferWidth / 2 - 100 && end == 1)
            {
                PlayerPosition.X = Game1.graphics.PreferredBackBufferWidth / 2 - 100;
                end = 0;
            }
            if (PlayerPosition.Y > Game1.graphics.PreferredBackBufferHeight)
            {
                isActive = false;
            }
            if ( PlayerPosition.X > Game1.graphics.PreferredBackBufferWidth - PlayerTexture.Width)
            {
                PlayerPosition.X = Game1.graphics.PreferredBackBufferWidth - PlayerTexture.Width;
            }
            if (PlayerPosition.X < 0)
            {
                PlayerPosition.X = 0;
            }
            SettingTruePosition();
            
            if (lives <= 0) {
                
                isActive = false;
            }
        }
        public void PlayerRelativePosition(KeyboardState state, GameTime gametime, bool start) {

            if (start)
            {

                if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) && canMoveRight)
                {
                    PlayerPosition.X += playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                    PlayerTexture = PlayerTextureRight;
                }

                if ((state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) && canMoveLeft)
                {
                    PlayerPosition.X -= playerSpeed * gametime.ElapsedGameTime.Milliseconds;
                    PlayerTexture = PlayerTextureLeft;
                }

                if (PlayerPosition.X > Game1.graphics.PreferredBackBufferWidth / 2 - 100)
                {
                    start = false;

                }
            }
        }
        public void PlayerRelativePosition(KeyboardState state, GameTime gametime, bool start, int end)
        {
            if (!start && end == 0)
            {



                if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) && canMoveRight)
                {
                    limitRight = true;
                    PlayerTexture = PlayerTextureRight;
                }


                if ((state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) && canMoveLeft)
                {
                    limitLeft = true;
                    PlayerTexture = PlayerTextureLeft;
                }



            }
        }


        public void Gravity(KeyboardState state, GameTime gametime)
        {

            if ((state.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(
               Keys.Space)) & countJump < 2)
            {
                countJump++;
                isJumping = true;
                isFalling = false;
                timeJumping = 0;
            }

            isMoving(gametime);


            foreach (var tile in Floor.tiles)
            {

                if (((tile.TilePosition.X - Tile.TileTexture.Width / 2) < PlayerPosition.X + PlayerTexture.Width / 2) & (PlayerPosition.X - PlayerTexture.Width / 2 < (tile.TilePosition.X + Tile.TileTexture.Width)))
                {
                    if (PlayerPosition.Y > tile.TilePosition.Y - Tile.TileTexture.Height / 2)
                    {
                        PlayerPosition.Y = tile.TilePosition.Y - Tile.TileTexture.Height / 2 + 24;

                        countJump = 0;
                        isFalling = false;

                    }


                }
            }
            previousState = state;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(PlayerTexture, PlayerPosition, Color.White);
        }
        public override void Load(ContentManager content)
        {

            PlayerTextureLeft = content.Load<Texture2D>("playerleft");
            PlayerTextureRight = content.Load<Texture2D>("playerright");
            PlayerTexture = PlayerTextureRight;
            PlayerRectangle = new Rectangle((int)PlayerPosition.X, (int)PlayerPosition.Y, PlayerTexture.Width, PlayerTexture.Height);
            PlayerMoves += inJump;
            PlayerMoves += inFall;
        }
        public void isMoving(GameTime gametime) {
            if (isJumping || isFalling) {
                PlayerMoves(gametime);
            }

        }
        public void inJump(GameTime gametime)
        {

            if (isJumping)
            {
                if (timeJumping < TIME_MAX_IN_AIR)
                {
                    timeJumping += (float)gametime.ElapsedGameTime.Milliseconds / 1000;
                    PlayerPosition.Y -= (playerStartingJumpSpeed - (float)Math.Pow(timeJumping, 2) * playerAccel);

                }
                else
                {
                    isFalling = true;
                    timeToFall = 0;
                    isJumping = false;
                }
            }


           

        }
        public void inFall(GameTime gametime)
        {


            if (isFalling)
            {
                timeToFall += (float)gametime.ElapsedGameTime.TotalSeconds;
                PlayerPosition.Y += ((float)Math.Pow(timeToFall, 2) * playerAccel);

            }

        }
        public void SettingTruePosition() {
            PlayerTrueRightX = PlayerPosition.X + PlayerTexture.Width;
            PlayerTrueLeftX = PlayerPosition.X;
            PlayerTrueUpY = PlayerPosition.Y;
            PlayerTrueDownY = PlayerPosition.Y + PlayerTexture.Height;
            PlayerRectangle.X = (int)PlayerPosition.X;
            PlayerRectangle.Y = (int)PlayerPosition.Y;
        }
    }


}
