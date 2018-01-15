using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{   
    class Program
    {
        static void Pojiect1 ()
        {
            Console.WriteLine("Hello World!");
        }
        static void project2()
        {
            string s = Console.ReadLine();
            Console.WriteLine("Hello" + " " + s + "!");
        }
        static void project3()
        {
            Console.WriteLine("请输入a的值后输入回车:");
            string a = Console.ReadLine();
            Console.WriteLine("请输入b的值后输入回车:");
            string b = Console.ReadLine();
            Console.WriteLine("交换a与b的值");
            string c = b;b = a;a = c;
            Console.WriteLine("现在a的值为" + a + "," + "b的值为" + b);
        }
        static void project4()
        {
            Console.WriteLine("请输入你的名字:");
            string s = Console.ReadLine();

            if (s == "Alice" || s == "Bob")
            {
                Console.WriteLine("Hello" + " " + s + "!");
            }
            else
            {
                Console.WriteLine("Hi");
            }
        }
        static void project5()
        {
            Console.WriteLine("请输入一个整数n,然后回车:");
            string s = Console.ReadLine();
            int n;
            while (!int.TryParse(s,out n))
            {
                Console.WriteLine(" 输入错误!请输入一个整数!");
                s = Console.ReadLine();
            }
            int y=0;
            for(int x=1; x<=n; x++)
            {
                Console.Write(x + " ");
                 y = y+x;
                if (x==n)
                {
                    Console.WriteLine();
                    Console.WriteLine("从1到n的值的总和为" + y);
                }
            }
                
        }
        static void project6()
        {
            Console.WriteLine("请输入一个整数n,然后回车:");
            string s = Console.ReadLine();
            int n;
            while (!int.TryParse(s, out n))
            {
                Console.WriteLine(" 输入错误!请输入一个整数!");
                s = Console.ReadLine();
            }
            int y = 0;
            for (int x = 1; x <= n; x++)
            {
                Console.Write(x + " ");
                if (x % 3 == 0 || x % 5 == 0)
                {
                    y = y + x;
                }
                if (x == n)
                {
                    Console.WriteLine();
                    Console.WriteLine("从1到n的所有3或5的倍数的值的总和为" + y);
                }
            }
        }
        static void project7()
        {
            Console.WriteLine("请输入一个整数n,然后回车:");
            string s = Console.ReadLine();
            int n;
            Random random = new Random();
            int r = random.Next(0, 2);
            while (!int.TryParse(s, out n))
            {
                Console.WriteLine(" 输入错误!请输入一个整数!");
                s = Console.ReadLine();
            }
            if (r == 0)
            {
                int y = 1;
                for (int x = 1; x <= n; x++)
                {
                    Console.Write(x + " ");
                    y = y * x;
                    if (x == n)
                    {
                        Console.WriteLine();
                        Console.WriteLine("从1到n的值的积为" + y);
                    }
                }
            }
            else
            {
                int y = 0;
                for (int x = 1; x <= n; x++)
                {
                    Console.Write(x + " ");
                    y = y + x;
                    if (x == n)
                    {
                        Console.WriteLine();
                        Console.WriteLine("从1到n的值的总和为" + y);
                    }
                }
            }
        }     
        static void Main(string[] args)
        {

            project7();

            Console.ReadKey();
        }
    }
}
 