using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_MouseMaze_Inheritance
{
    public class Tile : GameObject
    {
        private bool notWalkable;
        public bool NotWalkable => notWalkable;

        //public float Rotation = 0;
        //public Vector2 Origin = new Vector2(25, 25);
        //public float Scale = 2;


        public Tile(Vector2 pos, Texture2D tex, bool notWalkable) : base(pos, tex)
        {
            this.notWalkable = notWalkable;
          //  pos *= Scale;
        }
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
