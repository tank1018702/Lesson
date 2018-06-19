using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    class Program
    {
        static void Main(string[] args)
        {
            GameObject a = new GameObject(0, 0, ConsoleColor.Red);

            GameObject b = a;
            b.x = 1;
            Console.WriteLine(a.x + "|" + b.x);
            Console.ReadKey();
        }
    }
}
