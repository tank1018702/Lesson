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
            
            
            for (int i = 1; i < 21; i++)
            {

                int damagemodifier = (int)Math.Log((i / 10.0 + 1), 1.0055);
                Console.WriteLine("{0}:{1}", i,damagemodifier);
                
            }

            Console.ReadKey();
        }
    }
}
