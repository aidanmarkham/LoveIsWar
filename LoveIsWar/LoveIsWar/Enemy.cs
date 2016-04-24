using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoveIsWar
{
    //Main class for enemies, boss will inherit this class
    class Enemy : GameObject
    {
        Texture2D enemyBullet;
        Random rand;
        List<Bullet> bullets;
        int bulletTime;
        int fireRate;
        Player player;

        public Enemy(Texture2D tex, Texture2D bullet, Player gamePlayer, Random rand)
            : base(tex)
        {
            enemyBullet = bullet;
            
            bulletTime = 0;
            fireRate = 1000;
            location.Y = -tex.Height;
            location.X = rand.Next(0, 800 - tex.Width);
            bullets = new List<Bullet>();
            player = gamePlayer;
        }



        public override void Shoot()
        {
            bullets.Add(new Bullet(enemyBullet));
            bullets[bullets.Count - 1].Speed = -7;
            bullets[bullets.Count - 1].Location = location;
        }
        public override void Update(TimeSpan deltaTime)
        {
            location.Y += (int)(0.1 * deltaTime.Milliseconds);
            if (bulletTime > fireRate)
            {
                Shoot();
                bulletTime = 0;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                //handles when bullets collide with the player
                if (bullets[i] != null)
                {
                    bullets[i].Update(deltaTime);

                    if (bullets[i].CheckCollision(player) == true)
                    {
                        player.Lives--;
                        bullets[i] = null;
                    }
                }
            }
            bulletTime += deltaTime.Milliseconds; //updates bullet counter
        }

        public override void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    sb.Draw(enemyBullet, bullets[i].location, Color.White);
                }
            }

            base.Draw(sb);
        }

        public List<Bullet> Bullets
        {
            set { bullets = value; }
            get { return bullets; }
        }
    }
}
