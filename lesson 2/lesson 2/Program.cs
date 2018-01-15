using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int r = random.Next(0, 101);
            int n;
            int times = 1;
            while (true)
            {
                Console.WriteLine("输入一个0-100整数:");
                string s = Console.ReadLine();
                
                while (!int.TryParse(s, out n) || n < 0 || n > 100)
                {
                    Console.WriteLine("输入错误,请输入一个0-100之间的整数!");
                    s = Console.ReadLine();
                }
                if (n < r)
                {
                    Console.WriteLine("太小了");
                    times++;
                    continue;

                }
                else if (n > r)
                {
                    Console.WriteLine("太大了");
                    times++;
                    continue;
                }
                else
                {
                    Console.WriteLine("你猜对了 一共猜了{0}次,还不错", times);
                    break;
                }
                
            }
            Console.ReadKey();
            
        }
    }
}
