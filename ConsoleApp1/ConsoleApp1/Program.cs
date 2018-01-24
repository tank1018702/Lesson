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
            Console.CursorVisible = false; 
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━┓");
            Console.Write("┃");
            Console.SetCursorPosition(21, 1);

            Console.Write("┃");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━┫");
            Console.Write("┃");
            Console.SetCursorPosition(21, 3);
            Console.Write("┃");
            Console.SetCursorPosition(0, 4);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━┛");
            Console.SetCursorPosition(1, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃");
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃┃");
            Console.ReadKey(true);
            CleanHP();
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("┃┃┃┃┃┃┃┃┃┃┃┃┃┃");
            Console.ReadKey(true);
            CleanHP();
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("┃┃┃┃┃┃");
            
            Console.ReadKey();
        }
        static void CleanHP()
        {
            Console.SetCursorPosition(1, 1);
            for(int i=0; i<20; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
        }
        public static int GetLength(string text)
        {
            byte[] bytes;
            int len = 0;
            for (int i = 0; i < text.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(text.Substring(i, 1));
                len += bytes.Length > 1 ? 2 : 1;
            }
            return len;
        }
    }
}
