using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class var1
    {
        public int x;
        public int y;
        public int z;
        public var1()
        {
            int x = 1;
            int y = 1;
            int z = 1;
        }
    }
    
        

    

    class Program
    {
        static void Main(string[] args)
        {
            var1 n = new var1
            {
                x = 100,
                y = 100,
                z = 100
            };
            var1 m = new var1();
            while(true)
            {
                if (n.x == 0 || n.y == 0 || n.z == 0)
                {
                    break;
                }
                else
                {
                    sum(n.x, n.y, n.z);
                    sum(m.x, m.y, m.z);
                    Console.WriteLine(" "+n.x+" "+n.y+" "+n.z );
                    Console.WriteLine(" " + m.x + " " + m.y + " " + m.z);
                }
            }
            Console.ReadKey();
            
            
        }
        static void sum(int x,int y,int z)
        {
            x = x - 1;
            y = y - 2;
            z = z - 3;

        }
    }
}
