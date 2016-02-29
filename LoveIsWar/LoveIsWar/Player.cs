using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveIsWar
{
    //Holds info about the player
    class Player
    {
        Vector2 location;
        
        public Player()
        {
            location = new Vector2(0, 0);
        }
        public void Update(Vector2 newLoc)
        {
            location += newLoc;
        }
    }
}
