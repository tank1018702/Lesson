using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Program
    {
        static Random random = new Random();
        static int[] RandomArray(int x, int y)
        {
            int[] array = new int[random.Next(1, x)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(y);
            }
            return array;
        }
        static void OutPutArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" <" + i + ">:" + array[i] + " ");
            }
            Console.WriteLine();
        }
        static void Change(int[] array)
        {
            int mid = array[0];
            int min_index = 0;
            int max_index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (mid >= array[i])
                {
                    min_index = i;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (mid <= array[i])
                {
                    mid = array[i];
                    max_index = i;
                }
            }
            array[max_index] = array[min_index];
            array[min_index] = mid;
        }

        static void Main(string[] args)
        {
            int[] array = RandomArray(20, 100);
            OutPutArray(array);
            Change(array);
            OutPutArray(array);
            Console.ReadKey();
        }
    }
}
