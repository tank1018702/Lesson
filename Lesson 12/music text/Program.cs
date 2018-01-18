using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace music_text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the wav file name:");
            string filename = Console.ReadLine();
            if (System.IO.File.Exists(filename))
            {
                SoundPlayer s = new SoundPlayer(filename);
                s.Play();
            }
            Console.WriteLine("Done");
        }
    }
}
