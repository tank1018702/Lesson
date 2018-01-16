using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 农民伯伯锄大地
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
        static void Bubble(List<int> list)
        {
            int n = 1;
            int mid=0;
            for(int i=0;i<list.Count-1;i++)
            {
                for (int j = 0; j <list.Count-n; j++)
                {
                    if(list[j]>list[j+1])
                    {
                        mid = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = mid;
                    }
                }
                n++;
            }
        }
        static void Main(string[] args)
        {
            List<int> list = GetList();
            PrintList(list);
            Console.WriteLine("-----------------------------------");
            Bubble(list);
            PrintList(list);
            Console.WriteLine("-----------------------------------");
            Console.ReadKey();


        }
    }
}
