using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LoveIsWar
{
    class Highscore
    {
        public string strScore;
        public int score;
        public int readScore()
        {
            StreamReader input = new StreamReader("Highscore");

            strScore = input.ReadLine();
            int.TryParse(strScore, out score);
            //closes the file
            input.Close();
            return score;
        }





    }
}
