using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 快速排序
{
    class Program
    {
        static Random random = new Random();
        static List<int> GetList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.Next(1, 101));
            }
            return list;
        }
        static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
        static void QuickSort(List<int> list ,int _left,int _right)
        {
            int left;
            int right;
            int middle=0;
            int temp;
            if (_left > _right)
                return;
            left = _left;
            right = _right;
            temp = list[left];
            while(left!=right)
            {
                while(list[right]>=temp&&left<right)
                {
                    right--;
                }
                while (list[left]<=temp&&left<right)
                {
                    left++;
                }
                //if(left<right)
                {
                    middle = list[left];
                    list[left] = list[right];
                    list[right] = middle;
                }
            
              
                
            }
            list[_left] = list[left];
            list[left] = temp;
            QuickSort(list, _left, left - 1);
            QuickSort(list, left + 1, _right);
        }
        static void Main(string[] args)
        {
            var list = GetList();
            PrintList(list);
            QuickSort(list, 0, list.Count - 1);
            PrintList(list);

            Console.ReadKey();
        }
    }
}
