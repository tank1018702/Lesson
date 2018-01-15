using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 合并排序
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
        static void OutPutArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" <{0}>:{1}",i,array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
        }
        static int[] MergeSort(int []array_a,int []array_b)
        {
            int[] ArraySum = new int[array_a.Length + array_b.Length];
            int a_index = 0;
            int b_index = 0;
            for(int i=0;i<ArraySum.Length;i++)
            {
                if (array_a[a_index]>=array_b[b_index])
                {
                    ArraySum[i] = array_b[b_index];
                    if(b_index<array_b.Length-1)
                    {
                        b_index++;
                    }
                }
                else
                {
                    ArraySum[i] = array_a[a_index];
                    if(a_index<array_a.Length-1)
                    {
                        a_index++;
                    }
                }   
            }
            return ArraySum;

        }
        static void Main(string[] args)
        {
            int[] Array_A = RandomArray(20, 100);
            int[] Array_B = RandomArray(20, 100);
            Console.WriteLine("数组A的所有元素:");
            OutPutArray(Array_A);
            Console.WriteLine("数组B的所有元素:");
            OutPutArray(Array_B);
            BubbleSort(Array_A);
            BubbleSort(Array_B);
            Console.WriteLine("数组A排序后的所有元素:");
            OutPutArray(Array_A);
            Console.WriteLine("数组B排序后的所有元素:");
            OutPutArray(Array_B);
            Console.WriteLine("数组A和B合并后的所有元素:");
            OutPutArray(MergeSort(Array_A, Array_B));
            Console.ReadKey();


        }
    }
}
