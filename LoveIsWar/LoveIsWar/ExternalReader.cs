using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//streams
using System.IO;

namespace LoveIsWar
{
    class ExternalReader
    {
        //array containing values
        string[] filenames = new string[8];
        //CHANGE LENGTH OF STRING ARRAY TO ADJUST FOR ADDITIONAL FILES


        //base constructor
        public ExternalReader()
        {

        }

        //method to read in a binary file
        public void Read(string filename)
        {
            //try to catch exceptions
            try
            {
               
                //open a stream
                Stream str = File.OpenRead(filename);

                //make a streamreader reading from the file
                BinaryReader input = new BinaryReader(str);

                //read from the stream in a loop and set each value to the array
                for(int i = 0; i < filenames.Length; i++)
                {
                    string line = input.ReadString();
                    filenames[i] = line;
                }

                //close the stream
                input.Close();

                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Test()
        {
            //try/catch
            try
            {
                for(int i = 0; i < filenames.Length; i++)
                {
                    Console.WriteLine(filenames[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
