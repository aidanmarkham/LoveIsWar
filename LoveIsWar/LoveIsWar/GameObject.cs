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
        public Rectangle location; //holds the location, width, and height of the object
        public Vector2 velocity; //holds the velocity of the object
        public float dampening; //holds the dampening value
        public Texture2D texture; //holds the texture 
        public bool alive;
        
        //Game object Constructor
        public GameObject(Texture2D tex)
        {
            //instantiates to default values
            texture = tex;
            location = new Rectangle(0, 0, texture.Width, texture.Height);
            dampening = 1;
            alive = true;
        }

        public Rectangle Location
        {
            set { location = value; }
            get { return location; }
        }
        public float Dampening 
        {
            get { return dampening; }
            set { dampening = value; }
        }
        public virtual void Draw(SpriteBatch sb)
        {
            if (alive)
            {
                sb.Draw(texture, location, Color.White);
            }
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
