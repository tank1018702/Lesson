using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 杨辉三角
{
    class Program
    {
        static void Triangle(int n)
        {
            int[] array = new int[n + 1];
            array[1] = 1;
            int x = 0;
            int y = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    Console.Write("{0}", array[j]);
                    if (j > 0)
                    {
                        x = array[j] + array[j - 1];
                      
                    }
                }
                if( y<n)
                {
                    y++;
                    array[y] = x;

                }
                
                Console.WriteLine();

            }
        }
        static void Main(string[] args)
        {
            Triangle(6);
            Console.ReadKey();
        }
    }
}
