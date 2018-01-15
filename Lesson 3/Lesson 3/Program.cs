using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    class Program
    {
        static int Add(int a,int b)
        {
            return a + b;
        }
        static int Sub(int a,int b)
        {
            return a - b;
        }
        static int Multip(int a,int b)
        {
            return a * b;
        }
        static int Division(int a,int b)
        {
            return a / b;
        }
        static int Transform(int a)
        {
            if (a%2==0)
            {
                return a;
            }
            else
            {
                return a * 2;
            }
        }
    
    

        static void Main(string[] args)
        {
        }
    }
}
