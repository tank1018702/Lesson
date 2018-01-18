using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            int z = 7;
            double x = z / 1000.000000 + 1;
            for (int i = 1; i < 21; i++)
            {

                double d = n / 10.0 + 1;
                double a =(int)( Math.Log(d, x));
                Console.WriteLine("{0}:{1}", i, a);
                n++;
            }

            Console.ReadKey();
        }
    }
}
