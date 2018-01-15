using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recrsive2
{
    class Program
    {
        // 获得某个数列中下标为 i 的数
        static int GetNum(int i)
        {
            if (i==0)
            {
                return 1;
            }
            return GetNum(i - 1) + 2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetNum(100));
            Console.ReadKey();
        }
    }
}
