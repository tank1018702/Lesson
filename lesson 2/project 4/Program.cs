using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace project_4
{
    class Program
    {
        static void Main(string[] args)
        {   
            while(true)
            {
                WriteLine("请输入一个整数:");
                string s = ReadLine();
                int n;
                if (s == "end")
                {
                    break;
                }
                else if(int.TryParse(s, out n))
                {
                    WriteLine(n * 2);
                    WriteLine("--------");
                }
                else
                {
                    WriteLine("输入错误!");
                    continue;
                }
            }    
        }
    }
}
