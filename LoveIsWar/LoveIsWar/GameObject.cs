using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveIsWar
{
    
    class GameObject
    {
        public Vector2 location;
        public Vector2 velocity;
        public float dampening;
        public Texture2D texture;
        public GameObject(Texture2D tex)
        {
            location = new Vector2(0, 1);
            texture = tex;
            dampening = 1;
        }
        public float Dampening
        {
            get { return dampening; }
            set { dampening = value; }
        }
        public void Update()
        {

        }
    }
}
