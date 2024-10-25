﻿using Microsoft.Xna.Framework;
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
       

        public Tile(Vector2 pos, Texture2D tex, bool notWalkable) : base(pos, tex)
        {
            this.notWalkable = notWalkable;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }
    }
}
