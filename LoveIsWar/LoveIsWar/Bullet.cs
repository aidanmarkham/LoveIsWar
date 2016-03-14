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
        Boolean active;

        //Active property
        public Boolean Active
        {
            get { return active; }
            set { active = value; }
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

        }

        /*//CheckCollision method
        public Boolean CheckCollision(GameObject gameObject)
        {
            if (active == true)
            {
                
            }
        } */
    }
}
