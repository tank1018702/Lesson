using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_15
{
    class Program
    {
        static int Sequence(int a_n)                                                                                                                                                                   
        {
            if(a_n==0||a_n==1)
            {
                return 1;
            }
            return Sequence(a_n - 2) + Sequence(a_n - 1);

        }
        static void Main(string[] args)
        {
            
            Sequence(7);

        }
    }
}
