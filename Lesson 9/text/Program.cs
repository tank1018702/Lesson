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

            double x = 4.65;
            for (int i = 1; i < 21; i++)
            {

                double d = n/10.0+1 ;
                double a =(int)( Math.Pow(x,d));
                Console.WriteLine("{0}:{1}", i, a);
                n++;
            }

            Console.ReadKey();
        }
    }
}
