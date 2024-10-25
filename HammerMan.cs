using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_MouseMaze_Inheritance
{
    public class HammerMan : Cheese
    {
        private float timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;
        private Point currentFrame = new Point(0, 0);
        private Point sheetSize = new Point(5, 1);
        private Point frameSize = new Point(261, 273);



        public override Rectangle collider
        {
            get => new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);
        }
        public HammerMan(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }
        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if (currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(tex, new Rectangle((int)pos.X + 25, (int)pos.Y + 25, 50, 50), collider, Color.White, 0f, new Vector2(261/2, 273/2), SpriteEffects.None, 1f);
        }
    }
}
