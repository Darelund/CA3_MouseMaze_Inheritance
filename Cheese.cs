using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_MouseMaze_Inheritance
{
    public class Cheese : GameObject
    {
        public bool IsEaten { get; set; } = false;
        public virtual Rectangle collider
        {
            get => new Rectangle((int)pos.X, (int)pos.Y, 50, 25);
        }
        public Cheese(Vector2 pos, Texture2D tex) : base(pos, tex)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
           // base.Draw(spriteBatch);
           // spriteBatch.Draw(tex, pos, null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

            if(!IsEaten)
            spriteBatch.Draw(tex, collider, Color.White);
        }
    }
}
