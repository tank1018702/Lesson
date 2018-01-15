using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3
{
    class Program
    {
        static void MultiplicationTable()
        {
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= a; b++)
                {
                    if (a == 3 && b == 3 || a == 4 && b == 3)
                    {
                        Console.Write(" " + a + "x" + b + "=" + a * b + " ");
                    }
                    else
                    {
                        Console.Write(a + "x" + b + "=" + a * b + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Triangle1(int n)
        {
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= a; b++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void Triangle2(int n)
        {
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    if (b <= (n - a))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Triangle3(int n)
        {
            for (int a = 0; a < n; a++)
            {
                for (int b = n - 1; Math.Abs(b) <= n - 1; b--)
                {
                    if (Math.Abs(b) <= a)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Triangle4(int n)
        {
            for (int a = 1; a <= n; a++)
            {
                if (a <= (n + 1) / 2)
                {
                    for (int b = 1; b <= a; b++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int b = 1; b <= ((n + 1) - a); b++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Input()
        {
            while (true)
            {
                Console.WriteLine("选择输出的三角形的形状,输入1-4进行选择,输入5退出:");      
                int n1=0;
                while ( n1 < 1 || n1 > 5)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    int.TryParse(key.KeyChar.ToString(), out n1);
                    Console.WriteLine("---");
                }
                if (n1 == 5)
                {
                    return;
                }
                Console.WriteLine("输入三角形的高度:");
                string s2 = Console.ReadLine();
                int n2;
                while (!int.TryParse(s2, out n2))
                {
                    Console.WriteLine("请输入一个整数!");
                    s2 = Console.ReadLine();
                }
                switch (n1)
                {
                    case 1:
                        Triangle1(n2);
                        break;
                    case 2:
                        Triangle2(n2);
                        break;
                    case 3:
                        Triangle3(n2);
                        break;
                    case 4:
                        Triangle4(n2);
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Input();
            Console.WriteLine("按任意键结束");
            Console.ReadKey();
        }
    }
}
