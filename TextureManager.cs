using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_MouseMaze_Inheritance
{
    public class TextureManager
    {
        public static Texture2D wallTex;
        public static Texture2D floorTex;
        public static Texture2D cheeseTex;
        public static Texture2D mouseTex;
        public static Texture2D emptyTex;

        public static void LoadTextures(ContentManager content)
        {
            wallTex = content.Load<Texture2D>("walltile");
            floorTex = content.Load<Texture2D>("floortile");
            cheeseTex = content.Load<Texture2D>("cheese");
            mouseTex = content.Load<Texture2D>("mouse");
            emptyTex = content.Load<Texture2D>("empty");
        }
    }
}
