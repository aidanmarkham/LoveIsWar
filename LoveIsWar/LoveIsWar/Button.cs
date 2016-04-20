using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace LoveIsWar
{
    class Button
    {
        public Rectangle button;//size and place of button
        public Texture2D texture;//texture of the button
        SpriteFont spritefont;//words on the button
        int xpos;//position of x
        int ypos;//position of y;
        int buttonWidth;
        int buttonHeight;

        public Button(int x, int y, int width, int height,Texture2D text, SpriteFont font)
        {
            button = new Rectangle(x, y, width, height);
            texture = text;
            spritefont = font;
            xpos = x;
            ypos = y;
            buttonWidth = width;
            buttonHeight = height;
        }
        public void Drawbutton(SpriteBatch sb,string word)
        {
            
            sb.Draw(texture, button, Color.White);
            sb.DrawString(spritefont, word, new Vector2(xpos+50, ypos), Color.Black);
            
        }
        
        /*public bool isClicked(MouseState mouseState)
        {
            
            if(mouseState.LeftButton==ButtonState.Pressed)
            {
                if(mouseState.Position >= button.)
            }


            return false;
        }
        */

    }
}
