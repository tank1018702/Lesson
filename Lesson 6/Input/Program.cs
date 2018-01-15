using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    class Program
    {
        static void OutPutArray(char[] array)
        {
            int[] Result = new int[28];
            int v1 = 65;
            int v2 = 97;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 65 && array[i] <= 90)
                {
                    Result[array[i] - v1]++;
                }
                else if (array[i] >= 97 && array[i] <= 122)
                {
                    Result[array[i] - v2]++;
                }
                else if (array[i] == 32)
                {
                    Result[26]++;
                }
                else
                {
                    Result[27]++;
                }
            }
            for (int k = 0; k < 26; k++)
            {
                Console.Write(" |{0}的个数:<{1}>| " +
                    "", Convert.ToChar(k + 65), Result[k]);
            }
            Console.WriteLine();
            Console.WriteLine("空格的个数:<{0}>", Result[26]);
            Console.WriteLine("其他字符的个数:<{0}>", Result[27]);
        }
        static void OutPutArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("<" + i + ">:" + array[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] Transform(char[] array)
        {
            int[] IntArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                IntArray[i] = Convert.ToInt32(array[i]);
            }
            return IntArray;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] InputArray = input.ToCharArray();
            OutPutArray(InputArray);
            Console.ReadKey();


        }
    }
}
