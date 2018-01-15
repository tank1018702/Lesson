using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("输入回车开始抽卡:");
                Console.ReadLine();
                Random random = new Random();
                int r = random.Next(0, 99);
                if(r<10)
                {
                    Console.WriteLine("你抽到了关羽!"+"["+ r+"]");
                    continue;
                }
                else if(r<30)
                {
                    Console.WriteLine("你抽到了张飞!"+"["+ r+"]");
                    continue;
                }
                else if(r<60)
                {
                    Console.WriteLine("你抽到了赵云!"+"["+ r+"]");
                    continue;
                }
                else
                {
                    Console.WriteLine("你抽到了黄忠!"+"["+ r+"]");
                }

            }
        }
    }
}
