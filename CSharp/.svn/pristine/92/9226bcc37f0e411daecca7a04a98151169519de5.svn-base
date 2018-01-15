using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiArray
{
    class Program
    {
        static void PrintMultiArray(int[][] a)
        {
            for (int i = 0; i<a.Length; ++i)
            {
                if (a[i] == null)
                {
                    Console.WriteLine("null");
                    continue;
                }
                for (int j=0; j<a[i].Length; ++j)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintMultiArray(int[,] a, int width)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                Console.Write(a[i/width, i%width] + " ");
            }
        }

        static void Main(string[] args)
        {
            int[][] a = new int[5][];
            a[0] = new int[3];
            a[1] = new int[5];
            a[2] = new int[10];
            PrintMultiArray(a);

            int[,] b = new int[2, 5] { { 1,1,1,1,1}, { 2, 2, 2, 2, 2 } };
            PrintMultiArray(b, 5);
            Console.ReadKey();
        }
    }
}
