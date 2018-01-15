using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuluo
{
    
    class Program
    {
        static void text()
        {
            Console.WriteLine("什么参数都没传进去");
        }
        static void text(int a)
        {
            Console.WriteLine("传了一个整数{0}进去",a);
        }
        static void text(int a,string s)
        {
            Console.WriteLine("传了一个整数{0}和一个字符串{1}进去",a,s);
        }
        static void Main(string[] args)
        {
            int a = 5;string s = "尼玛";
            text();
            text(a);
            text(a, s);
            Console.ReadKey();
        }
    }
}
