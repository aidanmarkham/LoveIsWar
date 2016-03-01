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
        public Bullet(Texture2D tex)
            : base(tex)
        {
            
        }
    }
}
