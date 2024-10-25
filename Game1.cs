using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CA3_MouseMaze_Inheritance
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize = 50;
        public static List<GameObject> GameObjects;

        public MousePlayer mousePlayer;
        public Cheese cheese;
        public HammerMan hammarMan;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadTextures(Content);

            CreateLevel("maze.txt");


            //----------------Koden nedan används inte på grund av att vi skapade metoder----------------

            //StreamReader streamReader = new StreamReader("maze.txt");
            //List<string> result = new List<string>();

            //while (!streamReader.EndOfStream)
            //{
            //    string line = streamReader.ReadLine();
            //    result.Add(line);
            //    System.Diagnostics.Debug.WriteLine(line);
            //}
            //streamReader.Close();

            // List<string> result = ReadFromFile("maze.txt");

            //tileArray = new Tile[result[0].Length,result.Count];

            //for (int i = 0; i< result.Count; i++)
            //{
            //    for (int j = 0; j < result[0].Length; j++)
            //    {
            //        if (result[i][j] == 'w')
            //        {
            //            tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.wallTex, true);
            //        }
            //        else
            //        {
            //            tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.floorTex, false);
            //        }
            //    }
            //}
            // TODO: use this.Content to load your game content here

        }

        public List<string> ReadFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            List<string> result = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                result.Add(line);
                System.Diagnostics.Debug.WriteLine(line);
            }
            streamReader.Close();

            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> result = ReadFromFile(fileName);

            tileArray = new Tile[result[0].Length, result.Count];

            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    if (result[i][j] == 'w')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.wallTex, true);
                    }
                    else
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.floorTex, false);
                    }
                  
                    if (result[i][j] == 'p') // Används om man vill att 'p'/player objektet ska hanteras i samma if-sats kedja som andra delar.
                    {
                        mousePlayer = new MousePlayer(new Vector2(j * tileSize, i * tileSize), TextureManager.smallMouseTex);
                    }
                    else if (result[i][j] == 'c') // Används om man vill att 'p'/player objektet ska hanteras i samma if-sats kedja som andra delar.
                    {
                        cheese = new Cheese(new Vector2(j * tileSize, i * tileSize), TextureManager.cheeseTex);
                    }
                    else if (result[i][j] == 'h') // Används om man vill att 'p'/player objektet ska hanteras i samma if-sats kedja som andra delar.
                    {
                        hammarMan = new HammerMan(new Vector2(j * tileSize, i * tileSize), TextureManager.HammerMan_sprite_sheet);
                    }
                }
            }
          //  GameObjects.AddRange(tileArray);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mousePlayer.Update(gameTime);
            hammarMan.Update(gameTime);

           if(mousePlayer.collider.Intersects(cheese.collider))
            {
                cheese.IsEaten = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Tile t in tileArray)
            {
                t.Draw(spriteBatch);
            }
            cheese.Draw(spriteBatch);
            hammarMan.Draw(spriteBatch);
            mousePlayer.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public static bool GetTileAtPosition(Vector2 pos)
        {
            return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].NotWalkable;
        }
    }
}
