using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LoveIsWar
{ 
    //This class will hold information about the bullets.
    class Bullet: GameObject
    {
        //is the bullet active or not
        private Boolean active;

        //speed of the bullet
        private float speed;

        //Active property
        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }
        //Bullet Speed property
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Bullet(Texture2D tex)
            : base(tex)
        {
            this.active = true;
        }
        public Bullet(Bullet bullet) : base(bullet.texture)
        {
            this.active = bullet.active;
            this.location = bullet.location;
            this.speed = 7;
        }

        //CheckCollision method (returns a boolean to be checked in the update method)
        public Boolean CheckCollision(GameObject gameObject)
        {
            if (active == true)
            {
                if (this.location.Intersects(gameObject.location) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Bullet update method
        public override void Update(TimeSpan deltaTime)
        {
            //bullets move constantly upward
            velocity.Y = -speed;
            location.Y = location.Y + (int)velocity.Y;

            //if(CheckCollision()) not sure where to implement this

        }
    }
}
