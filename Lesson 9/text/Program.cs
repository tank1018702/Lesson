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

            
            for (int i = 1; i < 21; i++)
            {

                double d = (n+10)/1000.0+1 ;
                double a = Math.Log(d,1.008);
                Console.WriteLine("{0}:{1}", i, a);
                n++;
            }

            Console.ReadKey();
        }
    }
}
