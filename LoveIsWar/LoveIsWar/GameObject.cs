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
        public Rectangle location;
        public Vector2 velocity;
        public float dampening;
        public Texture2D texture;
        
        //Game object Constructor
        public GameObject(Texture2D tex)
        {
            
            texture = tex;
            location = new Rectangle(0, 0, texture.Width, texture.Height);
            dampening = 1;
        }


        public float Dampening
        {
            get { return dampening; }
            set { dampening = value; }
        }
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, location, Color.White);
        }
        public virtual void Update(TimeSpan deltaTime)
        {

        }

        //Shoot method, overridden by both Player and Enemies
        public virtual void Shoot() 
        {
        
        }
    }
}
