using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static int Fibonacci(int i)
        {
            if (i == 0 || i==1)
            {
                return 1;
            }
            return Fibonacci(i-1) + Fibonacci(i-2);
        }

        static void Main(string[] args)
        {
            for (int i=0; i<40; ++i)
            {
                Console.WriteLine(Fibonacci(i));
            }
            Console.ReadKey();
        }
    }
}
