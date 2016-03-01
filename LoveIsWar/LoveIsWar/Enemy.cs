using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LoveIsWar
{
    //Main class for enemies, boss will inherit this class
    class Enemy: GameObject
    {
        public Enemy(Texture2D tex)
            : base(tex)
        {
            
        }
    }
}
