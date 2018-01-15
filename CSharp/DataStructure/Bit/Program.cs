using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit
{
    class Program
    {
        static void WriteBit(string s, uint n)
        {
            Console.WriteLine(s + ":  " + Convert.ToString(n, 2));
        }

        // 0. 基本位运算操作符举例
        static void Test()
        {
            uint n;

            n = 1 << 4;
            WriteBit("1<<4", n);

            n = 0b11111111;
            n = 0xFF;
            WriteBit("n", n);
            n &= 0b10101010;
            WriteBit("&", n);
            n &= 0b01010101;
            WriteBit("&", n);

            n = 1 << 4;
            WriteBit("n", n);
            n = n | 0b0011;
            WriteBit("|", n);

            n = 0b00001111;
            WriteBit("n", n);
            n = n ^ 0b1001;
            WriteBit("^", n);
            n = n ^ 0b1001;
            WriteBit("^", n);

            n = 0b00001111;
            WriteBit("n", n);
            n = ~n;
            WriteBit("~", n);
        }

        // 1. 判断是否是偶数
        static bool IsEven(uint n)
        {
            return (n & 1) == 0;
        }

        // 2. 利用Mask查看某一位
        static bool CheckBit(uint n, int i)
        {
            return (n & (1u << i)) != 0;
        }

        // 3. 设置某一个bit为1
        static uint SetBit(uint n, int i)
        {
            return n | (1u << i);
        }

        // 4. 设置某一个bit为0
        static uint ClearBit(uint n, int i)
        {
            uint mask = 0xffffffff;
            mask = mask ^ (1u << i);
            return n & mask;
        }


        // 5. 实际问题：IP普通形式与Uint的互转
        static string UInt2IP(uint ip)
        {
            string IP = "";
            uint n;

            n = ip >> 3*8;
            IP += n + ".";
            n = (ip >> 2*8) & 0x000000FF;
            IP += n + ".";
            n = ip >> 1*8 & 0x000000FF;
            IP += n + ".";
            n = ip & 0x000000FF;
            IP += n;

            return IP;
        }
        static uint IP2Uint(string IP)
        {
            string[] array_ip = IP.Split('.');
            uint ip = 0;
            for (int i=0; i<array_ip.Length; ++i)
            {
                uint n = uint.Parse(array_ip[i]);
                n <<= (3 - i) * 8;

                ip += n;        // 这里也可以写 ip |= n;
            }

            return ip;
        }


        // 有难度的问题：一个整数的二进制表示里包含多少个1
        static uint Count1(uint n)
        {
            uint count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------基础例子开始----------");
            Test();
            Console.WriteLine("=======基础例子结束==========");

            uint n = 3;
            Console.WriteLine(n << 2);

            Console.WriteLine(IsEven(n));
            Console.WriteLine(Count1(65535));

            Console.WriteLine(CheckBit(65536, 15));

            Console.WriteLine(SetBit(8, 2));
            Console.WriteLine(ClearBit(65536, 16));

            string IP = UInt2IP(0x7F80FFFe);
            Console.WriteLine(IP);
            uint ip = IP2Uint(IP);
            Console.WriteLine("IP转换回uint: " + Convert.ToString(ip, 16));

            Console.ReadKey();
        }
    }
}
