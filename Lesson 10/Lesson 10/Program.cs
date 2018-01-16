using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_10
{
    class Program
    {
        static Random random = new Random();
        static void SingleDogMustDie(List<int> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int trigger = -1;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        trigger++;
                    }
                }
                if (trigger == 0)
                {
                    list.RemoveAt(i);
                }
            }
        }
        static void LookforSingleDog(List<int> list)
        {
            
            for (int i = 0; i <list.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int trigger = -1;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        trigger++;
                    }
                }
                if (trigger == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", list[i]);
                }
                else
                {
                    Console.Write("{0} ", list[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        static List<int> GetList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                list.Add(random.Next(9));
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
        static void Main(string[] args)
        {
            List<int> list = GetList();
            PrintList(list);
            Console.WriteLine("-----------------------------------------------------------");
            LookforSingleDog(list);
            Console.WriteLine("-----------------------------------------------------------");
            SingleDogMustDie(list);
            PrintList(list);
            Console.WriteLine("-----------------------------------------------------------");
            Console.ReadKey();

        }
    }
}
