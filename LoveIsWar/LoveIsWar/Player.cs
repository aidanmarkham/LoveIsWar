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
    class Player : GameObject
    {
        float speed;
        List<Bullet> bullets = new List<Bullet>();
        Bullet playerBullet;
        int screenWidth;
        int screenHeight;
        int lives = 3; // number of times the player can be hit by bullets before it's game over
        int score = 0; // current score
        Boolean isDead = false;

        double bulletTime;

        int fireRate;

        public Player(Texture2D tex, Texture2D bulletTex, int scrWidth, int scrHeight)
            : base(tex)
        {
            screenWidth = scrWidth;
            screenHeight = scrHeight;
            location = new Rectangle(screenWidth / 2, scrHeight - texture.Height, texture.Width, texture.Height);
            playerBullet = new Bullet(bulletTex);
            speed = 6;
            dampening = 1.3f;
            bulletTime = 0;
            fireRate = 100;
        }
        public void Reset()
        {
            lives = 100;
            score = 0;
            bullets = new List<Bullet>();
        }
        // property that returns the current number of lives the player has
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        // property that returns whether or not the player is dead/ should cause the game to go to a game over screen
        public Boolean IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        // propert that returns the score of the player
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void Update(KeyboardState kb, TimeSpan deltaTime, Level level)
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
                if (bulletTime > fireRate)
                {
                    Shoot();
                    bulletTime = 0;
                }

            }


            //This code block handles player movement and shooting


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
                if (bullets[i] != null)
                {
                    bullets[i].Update(deltaTime);
                }
            }
            //update the player's bullets

            // handles when player bullets hit enemies
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < level.Enemies.Count; j++)
                {
                    if (level.Enemies[j] != null && bullets[i] != null)
                    {
                        if (bullets[i].CheckCollision(level.Enemies[j]))
                        {
                            level.Enemies[j] = null;
                            bullets[i] = null;
                            score += 100; // add 100 to the score each time an enemy is killed
                        }
                    }
                    /*
                    for (int k = 0; k < level.Enemies[j].Bullets.Count; k++)
                    {
                        if (level.Enemies[j].Bullets[k].CheckCollision(this))
                        {
                            System.Threading.Thread.Sleep(5);
                        }
                    }
                     * */
                }
            }

            // handles when the player is hit by a bullet- reduces number of lives left
            for (int i = 0; i < level.Enemies.Count; i++)
            {
                if (level.Enemies[i] != null)
                {
                    for (int j = 0; j < level.Enemies[i].Bullets.Count; j++)
                    {
                        if (level.Enemies[i].Bullets[j] != null)
                        {
                            if (level.Enemies[i].Bullets[j].CheckCollision(this))
                            {
                                //bullets[i] = null;  this just causes the player bullets to disappear when they're fired
                                lives--;
                            }
                        }
                    }
                }
            }

            // if lives = 0, the player is dead
            if (lives <= 0)
            {
                isDead = true;
            }

            bulletTime += deltaTime.Milliseconds; //updates bullet counter

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
            set { speed = value; }
        }

        public override void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < bullets.Count; i++) // draw the bullets
            {
                if (bullets[i] != null)
                {
                    sb.Draw(bullets[i].texture, bullets[i].location, Color.White);
                }
            }
            base.Draw(sb);
        }

        public List<Bullet> Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }
    }
}
