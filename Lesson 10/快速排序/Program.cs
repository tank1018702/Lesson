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
        static void QuickSort()
        {


        }
        static void Main(string[] args)
        {
        }
    }
}
