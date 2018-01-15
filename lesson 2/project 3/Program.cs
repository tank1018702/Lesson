using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    class Program
    {
        static void Main(string[] args)

        {
            //设置数组
            int[] array = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };
            int low = 0;
            int high = array.Length - 1;
            int midle;
            bool q = false;
            //获取输入值     
            Console.WriteLine("输入你要查找的整数,范围在11-99之间");
            string s = Console.ReadLine();
            int n;
            while (!int.TryParse(s, out n) || n < 11 || n > 99)
            {
                Console.WriteLine("输入错误,请输入11-99之间的整数");
                s = Console.ReadLine();
            }
            while (low <= high)
            {
                midle = (low + high) / 2;
                if (n > array[midle])
                {
                    low = midle + 1;
                }
                else if (n < array[midle])
                {
                    high = midle - 1;
                }
                else
                {
                    Console.WriteLine("输入的数字在数组中的下标为{0}", midle);
                    q = true;
                    Console.ReadKey();
                    break;
                }
            }
            if (q == false)
            {
                Console.WriteLine("输入的数不在数组之中");
            }
            Console.ReadKey();

        }
    }
}
