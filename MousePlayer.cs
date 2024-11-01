using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_MouseMaze_Inheritance
{
    public class MousePlayer : GameObject
    {
       private Rectangle rec;

       private Vector2 destination;
       private Vector2 direction;
       private float speed;
       private bool moving;

        private float rotation;

        public MousePlayer(Vector2 pos, Texture2D texture): base(pos, texture)
        {
            rec = new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize);
            destination = Vector2.Zero;
            direction = Vector2.Zero;
            speed = 200;
            moving = false;
        }
        public virtual Rectangle collider
        {
            get => new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
        }

        public override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();

            if (!moving)
            {
                //if (KeyMouseReader.KeyPressed(Keys.Up))
                //{
                //    //direction = new Vector2(0, -1);
                //    //Vector2 newDestination = pos + Game1.tileSize * direction;

                //    //if (!Game1.GetTileAtPosition(newDestination)) 
                //    //{
                //    //    destination = newDestination;
                //    //    moving = true;
                //    //}

                //    ChangeDirection(new Vector2(0, -1));

                //}
                //else if (KeyMouseReader.KeyPressed(Keys.Down))
                //{
                //    ChangeDirection(new Vector2(0, 1));
                //}
                //else if (KeyMouseReader.KeyPressed(Keys.Left))
                //{
                //    ChangeDirection(new Vector2(-1, 0));
                //}
                //else if (KeyMouseReader.KeyPressed(Keys.Right))
                //{
                //    ChangeDirection(new Vector2(1, 0));
                //}

                //Samma som uppe men kan hålla in nu
                if (KeyMouseReader.KeyIsPressed(Keys.Up))
                {
                    //direction = new Vector2(0, -1);
                    //Vector2 newDestination = pos + Game1.tileSize * direction;

                    //if (!Game1.GetTileAtPosition(newDestination)) 
                    //{
                    //    destination = newDestination;
                    //    moving = true;
                    //}
                    rotation = MathHelper.ToRadians(180);
                    ChangeDirection(new Vector2(0, -1));

                }
                else if (KeyMouseReader.KeyIsPressed(Keys.Down))
                {
                    ChangeDirection(new Vector2(0, 1));
                    rotation = MathHelper.ToRadians(0);
                }
                else if (KeyMouseReader.KeyIsPressed(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0));
                    rotation = MathHelper.ToRadians(90);
                }
                else if (KeyMouseReader.KeyIsPressed(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0));
                    rotation = MathHelper.ToRadians(270);
                }


            }
            else
            {
                pos = pos + direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                rec.X = (int)pos.X;
                rec.Y = (int)pos.Y;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }


        }
       

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + Game1.tileSize * direction;

            if (!Game1.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos + new Vector2(25, 30), null, Color.White, rotation, new Vector2(25, 30), 1f, SpriteEffects.None, 0f);
           // spriteBatch.Draw(tex, rec, Color.White);

        }
    }
}
