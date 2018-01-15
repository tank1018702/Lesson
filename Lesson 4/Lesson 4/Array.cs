using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class Array
    {
        static Random random = new Random();
        static int BinaryChop(int[] array, int n)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == n)
                {
                    return mid;
                }
                else if (array[mid] > n)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        static bool HasElement(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == n)
                {
                    return true;
                }
            }
            return false;
        }
        static int CountElement(int[] array, int n)
        {
            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == n)
                {
                    x++;
                }
            }
            return x;
        }
        static int MaxElement(int[] array)
        {
            int x = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (x <= array[i])
                {
                    x = array[i];
                }
            }
            return x;
        }
        static int MinElement(int[] array)
        {
            int x = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (x >= array[i])
                {
                    x = array[i];
                }
            }
            return x;
        }
        static int SumArray(int[] array)
        {
            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                x += array[i];
            }
            return x;
        }
        static float AverageArray(int[] array)
        {
            float x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                x += array[i];
            }
            return x / array.Length;
        }
        static int[] DoubleEvenNum(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    array[i] *= 2;
                }
            }
            return array;
        }
        static void OutPutArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " + array[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] RandomArray(int x, int y)
        {
            int[] array = new int[random.Next(1, x)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(y);
            }
            return array;
        }
        static int[] BubbleSort(int[] array)
        {
            int mid = 0;
            int count = array.Length;
            for (int j = 0; j <= array.Length; j++)
            {
                for (int i = array.Length; i >= 2; i--)
                {
                    if (array[i - 1] < array[i - 2])
                    {
                        mid = array[i - 2];
                        array[i - 2] = array[i - 1];
                        array[i - 1] = mid;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            int x = 20; int y = 100;
            int[] array = RandomArray(x, y);
            int n = 4;
            bool b = HasElement(array, n);
            int count = CountElement(array, n);
            int max = MaxElement(array);
            int min = MinElement(array);
            int sum = SumArray(array);
            float ave = AverageArray(array);
            Console.WriteLine("是否存在元素{0}" + b, n);
            Console.WriteLine("数组中存在{0}个{1}元素", count, n);
            Console.WriteLine("数组中所有元素的最大值为" + max);
            Console.WriteLine("数组内的最小值是" + min);
            Console.WriteLine("数组内所有数字的和是" + sum);
            Console.WriteLine("数组内所有数字的平均数是" + ave);
            Console.WriteLine("数组中的所有元素为:");
            OutPutArray(array);
            Console.WriteLine("-------------------");
            BubbleSort(array);
            Console.WriteLine("数组排序以后的所有元素为");
            OutPutArray(array);
            Console.WriteLine("-------------------");
            DoubleEvenNum(array);
            Console.WriteLine("数组中所有偶数乘以2后数组中的所有元素为:");
            OutPutArray(array);
            Console.WriteLine("-------------------");
            Console.ReadKey();
        }
    }
}
