using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;

namespace LoveIsWar
{
    //This will carry information about anything the player can pickup 
    class Pickup: GameObject
    {
        public Pickup(Texture2D tex)
            : base(tex)
        {
            
        }
    }
}
