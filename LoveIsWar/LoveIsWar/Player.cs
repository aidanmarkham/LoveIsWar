using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveIsWar
{
    //Holds info about the player
    class Player: GameObject
    {


        public Player(Texture2D tex)
            : base(tex)
        {
            
        }
        public void Update(Vector2 newLoc)
        {
            base.location += newLoc;
        }
    }
}
