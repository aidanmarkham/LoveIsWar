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
        Random rand;
        public Enemy(Texture2D tex)
            : base(tex)
        {
            rand = new Random();

            location.X = rand.Next(0, 800);
        }
        public override void Update(TimeSpan deltaTime) {
            location.Y += (int)(0.1 * deltaTime.Milliseconds);
        }

    }
}
