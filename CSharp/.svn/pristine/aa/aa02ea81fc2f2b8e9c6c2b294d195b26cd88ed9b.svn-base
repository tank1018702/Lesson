using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 完全图示参考：
// http://blog.csdn.net/u011068702/article/details/52712634

namespace MinHeap
{
    class MinHeap
    {
        List<int> heap;

        int layers = -1;

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        public void TestInit()
        {
            heap = new List<int> { 9, 3, 7, 6, 5, 1, 10, 2 };
            layers = CalcLayers();
        }

        public int CalcLayers()
        {
            int layers = 0;
            int n = heap.Count;
            while (n > 0)
            {
                n >>= 1;
                layers++;
            }
            return layers;
        }


        public void AdjustDown(int index)
        {
            if (index *2 + 1 >= heap.Count)
            {
                return;
            }
            int min_index = index;
            int min = heap[index];

            if (min > heap[index * 2 + 1])
            {
                min_index = index * 2 + 1;
                min = heap[min_index];
            }
            if (index * 2 + 2 < heap.Count && min > heap[index * 2 + 2])
            {
                min_index = index * 2 + 2;
                min = heap[min_index];
            }

            if (min_index != index)
            {
                int temp = heap[index];
                heap[index] = heap[min_index];
                heap[min_index] = temp;

                AdjustDown(min_index);
            }
            return;
        }

        public void AdjustUp(int index)
        {
            if (index * 2 + 1 >= heap.Count)
            {
                AdjustUp((index - 1) / 2);
                return;
            }
            int min_index = index;
            int min = heap[index];

            if (min > heap[index * 2 + 1])
            {
                min_index = index * 2 + 1;
                min = heap[min_index];
            }
            if (index * 2 + 2 < heap.Count && min > heap[index * 2 + 2])
            {
                min_index = index * 2 + 2;
                min = heap[min_index];
            }

            if (min_index != index)
            {
                int temp = heap[index];
                heap[index] = heap[min_index];
                heap[min_index] = temp;

                AdjustUp((index-1)/2);
            }
        }

        public void Add(int n)
        {
            heap.Add(n);
            AdjustUp(heap.Count - 1);
        }

        public int GetTop()
        {
            return heap[0];
        }

        public void RemoveTop()
        {
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            AdjustDown(0);
        }

        public void Init()
        {
            int index = (heap.Count - 1) / 2;
            while (index >= 0)
            {
                AdjustDown(index);
                index -= 1;
            }
        }

        int Pow2(int n)
        {
            return 1 << n;
        }
        public void Print()
        {
            int counter = 0;

            for (int i=0; i<layers; ++i)
            {
                int n_row = Pow2(i);
                Console.Write(new string(' ', Pow2(layers-i-1) * 3 / 2));
                for (int j=0; j<n_row && counter<heap.Count; ++j)
                {
                    Console.Write(string.Format("{0:D2}", heap[counter]));
                    if (i != layers - 1)
                    {
                        Console.Write(new string(' ', Pow2(layers-i-1) * 3 - 2));
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MinHeap heap = new MinHeap();
            heap.TestInit();
            heap.Print();

            Console.WriteLine("-----------------------------------");
            heap.Init();
            heap.Print();

            Console.WriteLine("-----------------------------------");
            heap.Add(0);
            heap.Print();

            Console.WriteLine("-----------------------------------");
            heap.RemoveTop();
            heap.Print();

            Console.ReadKey();
        }
    }
}
