using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("../../map.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);

            writer.WriteLine("abcde");
            writer.WriteLine("12345");

            writer.Close();
            fs.Close();

        }
    }
}
