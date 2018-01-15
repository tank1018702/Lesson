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
            while(true)
            {
                string input = Console.ReadLine();
                
                bool b = double.TryParse(input, out double n);
                 n = n / 10 + 1;
                double a = Math.Log(n,1.02);
                Console.WriteLine(a);
            }
            
            
        }
    }
}
