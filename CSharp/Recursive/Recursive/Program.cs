using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSimple
{
    class Program
    {
        static void Loop(int n)
        {
            Console.WriteLine(n);
            if (n == 1)
            {
                return;
            }
            Loop(n - 1);
        }

        static void Main(string[] args)
        {
            Loop(10);
            Console.ReadKey();
        }
    }
}
