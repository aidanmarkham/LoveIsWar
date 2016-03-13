using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveIsWar
{
    //Holds info about the player
    class Player: GameObject
    {
        float speed;

        public Player(Texture2D tex)
            : base(tex)
        {
            speed = 3;
            dampening = 1.3f;
        }
        public void Update(KeyboardState kb)
        {

            if (kb.IsKeyDown(Keys.Up))
            {
                velocity.Y = -speed;
            }
            if (kb.IsKeyDown(Keys.Down))
            {
                velocity.Y = speed;
            }
            if (kb.IsKeyDown(Keys.Left))
            {
                velocity.X = -speed;
            }
            if (kb.IsKeyDown(Keys.Right))
            {
                velocity.X = speed;
            }

            location.X = location.X + (int)velocity.X;
            location.Y = location.Y + (int)velocity.Y;

            velocity = velocity / dampening;

            if (location.X < 0)
            {
                location.X = 0;
            }
            else if (location.Y < 0)
            {
                location.Y = 0;
            } //else if (location.Y > texture.Width )
        }


        /*//Player Shoot Method
        public override void Shoot(Texture2D bulletTexture, SpriteBatch spritebatch)
        {
            //creates a new bullet object
            Bullet playerBullet = new Bullet(bulletTexture);

            //draws the bullet at the position of the player
            playerBullet.Draw(spritebatch);
       
            
        } */

        public float Speed
        {
            get { return speed; }
            set { speed = value;}
        }
    }
}
