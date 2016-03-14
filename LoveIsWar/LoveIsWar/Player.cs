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
        List<Bullet> bullets = new List<Bullet>();
        Bullet playerBullet;
        int screenWidth;
        int screenHeight;
        public Player(Texture2D tex, Texture2D bulletTex, int scrWidth, int scrHeight)
            : base(tex)
        {
            screenWidth = scrWidth;
            screenHeight = scrHeight;
            location = new Rectangle(screenWidth/2, scrHeight - texture.Height, texture.Width, texture.Height);
            playerBullet = new Bullet(bulletTex);
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
            if (kb.IsKeyDown(Keys.Space))
            {
                Shoot();
            }
            //This code block handles player movement


            location.X = location.X + (int)velocity.X;
            location.Y = location.Y + (int)velocity.Y;
            //Update the players location

            velocity = velocity / dampening;
            //dampen the player's speed

            if (location.X < 0)
            {
                location.X = 0;
            }
            if (location.Y < 0)
            {
                location.Y = 0;
            }
            if (location.X > screenWidth - location.Width)
            {
                location.X = screenWidth - location.Width;
            }
            if (location.Y > screenHeight - location.Height)
            {
                location.Y = screenHeight - location.Height;
            }
            // keep the player on screen.

            playerBullet.location = location;
            //updates the location of the default bullet

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }
            //update the player's bullets
        }


        //Player Shoot Method
        public override void Shoot()
        {
            //creates a new bullet object
            
            bullets.Add(new Bullet(playerBullet));
        } 

        public float Speed
        {
            get { return speed; }
            set { speed = value;}
        }

        public override void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                sb.Draw(bullets[i].texture, bullets[i].location, Color.White);
            }
            base.Draw(sb);
        }
    }
}
