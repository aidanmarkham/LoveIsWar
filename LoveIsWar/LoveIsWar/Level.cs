using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LoveIsWar
{
    //will do things like load level and handle the movement
    class Level: GameObject
    {
        public Level(Texture2D tex)
            : base(tex)
        {
            
        }
    }
}
