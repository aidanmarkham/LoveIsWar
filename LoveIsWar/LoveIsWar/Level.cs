using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoveIsWar
{
    //will do things like load level and handle the movement
    class Level: GameObject
    {
        TimeSpan enemyPeriod; // this holds the frequency that enemies should be spawned
        TimeSpan enemyCounter; // this holds how long it's been since the last time an enemy spawned
        int targetScore; //this holds the target score until the level boss appears
        List<Enemy> enemies; // this list holds all the enemies that are active
        Texture2D enemyBullet;
        Texture2D enemyTexture;

        public Level(Texture2D tex, Texture2D enemTex, Texture2D enemBullet, int w, int h)
            : base(tex)
        {
            targetScore = int.MaxValue; // default value, this means that the level wont end for a long long time.
            enemyPeriod = new TimeSpan(0, 0, 0, 0, 500); //set the period for this level
            enemyCounter = new TimeSpan(0); // inits the counter for enemies
            location.Width = w; // gets the width and height of the screen
            location.Height = h;
            enemies = new List<Enemy>(); //inits the list for enemies

            enemyTexture = enemTex;
            enemyBullet = enemBullet;
        }
        public override void Update(TimeSpan deltaTime)
        {
            enemyCounter += deltaTime; //increases the counter by the amount of time since the last update
            location.Y += 3; //moves the floor 
            if (location.Y > location.Height) //if the floor gets to far away, bring it back
            {
                location.Y = 0;
            }

            for (int i = 0; i < enemies.Count; i++) //update all the enemies
            {
                if (enemies[i] != null)
                {
                    enemies[i].Update(deltaTime);
                }
            }

            if (enemyCounter > enemyPeriod) // if the enemy counter gets to a large enough amount of time, reset the counter and spawn an enewy
            {
                enemyCounter = new TimeSpan(0);
                SpawnEnemy();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                }
            }

            base.Update(deltaTime);
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, new Rectangle(location.X, location.Y - location.Height, location.Width, location.Height), Color.White); // draw one level
            sb.Draw(texture, location, Color.White); // draw the other level image
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].Draw(sb);
                }
            }
        }
        public void SpawnEnemy(){
            enemies.Add(new Enemy(enemyTexture, enemyBullet));
        }
        public List<Enemy> Enemies
        {
            set { enemies = value; }
            get { return enemies; }
        }
    }
}
