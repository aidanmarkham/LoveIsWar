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
        public Level(Texture2D tex, int w, int h)
            : base(tex)
        {
            location.Width = w;
            location.Height = h;
        }
        public override void Update()
        {
            
            location.Y += 3;
            if (location.Y > location.Height)
            {
                location.Y = 0;
            }
            base.Update();
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, new Rectangle(location.X, location.Y - location.Height, location.Width, location.Height), Color.White);
            sb.Draw(texture, location, Color.White);
        }
    }
}
