using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印图形
{
    class Program
    {
        static void Triangle(int lines)
        {
            Console.WriteLine("*");
            for (int i=1; i<=lines;++i)
            {
                for (int j=0; j<i*3; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void SinGraph(int lines)
        {
            for (int i = 0; i <= lines; ++i)
            {
                double d = Math.Sin(i*0.2f)*10+20;
                //int n = (int)(d * 10) + 20;
                int n = (int)d;
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static Random random = new Random();

        static int[] GenMap()
        {
            int[] map = new int[60];
            for (int i=0; i<map.Length; ++i)
            {
                map[i] = random.Next(2, 15);
            }
            return map;
        }

        static void DrawMountain(int[] map)
        {
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < map.Length; ++j)
                {
                    if (map[j] >= 20 - i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Triangle(8);

            //SinGraph(100);
            int[] map = GenMap();
            DrawMountain(map);
            Console.ReadKey();
        }
    }
}
