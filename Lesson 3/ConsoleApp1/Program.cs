using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    class Program
    {
        static int times = 1;
        static bool Trigger=true;
        static int input()
        {
            int n;
            string s=Console.ReadLine();           
            while (!int.TryParse(s, out n) || n < 0 || n > 100)
            {               
                Console.WriteLine("输入错误,请输入一个0-100之间的整数!");
                s = Console.ReadLine();
            }
            return n;
        }
        static int Guess(int n,int r)
        { 
             if (n < r)
             {
                Console.WriteLine("太小了");
                times++;
                return times;
             }
            else if (n > r)
            {
                Console.WriteLine("太大了");
                times++;
                return times;
            }
             else
             {
                Trigger = false;
                return times;        
             }         
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int r = random.Next(0, 101);
            Console.WriteLine("输入一个0-100整数:");
            while(Trigger)
            {
                int n = input();
                Guess(n, r);
            } 
            Console.WriteLine("你猜对了 一共猜了{0}次,还不错", times);
            Console.ReadKey();
        }
    }
}
