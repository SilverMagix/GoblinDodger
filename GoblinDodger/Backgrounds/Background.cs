using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestGame1.Backgrounds.BackgroundTileList;

namespace TestGame1.Backgrounds
{
    class Background : DummyClass
    {
        public static List<List<BackgroundTiles>> backgroundTiles = new List<List<BackgroundTiles>>();

        public void Initialize()
        {

            backgroundTiles.Add(new List<BackgroundTiles>());
            backgroundTiles.Add(new List<BackgroundTiles>());
            backgroundTiles.Add(new List<BackgroundTiles>());
            backgroundTiles.Add(new List<BackgroundTiles>());
            backgroundTiles.Add(new List<BackgroundTiles>());

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var e in backgroundTiles)
            {
                foreach (var f in e)
                {
                    if ((f.BackgroundPosition.X+2720 > 0) && (f.BackgroundPosition.X < 1900))
                    {
                        f.Draw(spriteBatch);
                    }
                }

            }

        }

        public override void Load(ContentManager content)
        {
            backgroundTiles[0].Add(new BG("layers/parallax-mountain-bg", new Vector2(0, 0)));
            backgroundTiles[0].Add(new BG2("layers/parallax-mountain-bg2", new Vector2(1400, 0)));
            backgroundTiles[4].Add(new Foreground("layers/parallax-mountain-foreground-trees", new Vector2(0, 0)));
            backgroundTiles[4].Add(new Foreground("layers/parallax-mountain-foreground-trees", new Vector2(2720, 0)));
            backgroundTiles[1].Add(new MontainFar("layers/parallax-mountain-montain-far", new Vector2(0, 0)));
            backgroundTiles[1].Add(new MontainFar("layers/parallax-mountain-montain-far", new Vector2(1360, 0)));
            backgroundTiles[2].Add(new Mountains("layers/parallax-mountain-mountains", new Vector2(0, 0)));
            backgroundTiles[2].Add(new Mountains("layers/parallax-mountain-mountains", new Vector2(2720, 0)));
            backgroundTiles[3].Add(new MountainTrees("layers/parallax-mountain-trees", new Vector2(0, 0)));
            backgroundTiles[3].Add(new MountainTrees("layers/parallax-mountain-trees", new Vector2(2720, 0)));
            backgroundTiles[0][0].Load(content);
            backgroundTiles[0][1].Load(content);
            backgroundTiles[1][0].Load(content);
            backgroundTiles[2][0].Load(content);
            backgroundTiles[3][0].Load(content);
            backgroundTiles[4][0].Load(content);


        }

        public override void Update(GameTime gametime)
        {

            foreach (var e in backgroundTiles)
            {
                foreach (var f in e)
                {


                    f.Update(gametime);
                }
            }
            foreach (var e in backgroundTiles)
            {
                for (int i = 0; i < e.Count; i++)
                {
                    if ((e[i].BackgroundPosition.X + 1360 > 1890) && (e[i].BackgroundPosition.X + 1360 < 1910) && (i == e.Count - 1))
                    {
                        switch (e[i].GetType().ToString())
                        {

                            case "TestGame1.Backgrounds.BackgroundTileList.BG2":

                                backgroundTiles[0].Add(new BG2("layers/parallax-mountain-bg2", new Vector2(1900, 0)));

                                break;
                            case "TestGame1.Backgrounds.BackgroundTileList.MontainFar":

                                backgroundTiles[1].Add(new MontainFar("layers/parallax-mountain-montain-far", new Vector2(1900, 0)));

                                break;
                        }
                    }
                    if ((e[i].BackgroundPosition.X + 2720 > 1890) && (e[i].BackgroundPosition.X + 2720 < 1910) && (i == e.Count - 1))
                    {
                        switch (e[i].GetType().ToString())
                        {
                            case "TestGame1.Backgrounds.BackgroundTileList.MountainTrees":

                                backgroundTiles[3].Add(new MountainTrees("layers/parallax-mountain-trees", new Vector2(1900, 0)));

                                break;
                            case "TestGame1.Backgrounds.BackgroundTileList.Mountains":

                                backgroundTiles[2].Add(new Mountains("layers/parallax-mountain-mountains", new Vector2(1900, 0)));

                                break;
                            case "TestGame1.Backgrounds.BackgroundTileList.Foreground":

                                backgroundTiles[4].Add(new Foreground("layers/parallax-mountain-foreground-trees", new Vector2(1900, 0)));

                                break;
                        }

                    }
                }
            }
        }
    }
}







