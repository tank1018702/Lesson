using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光标控制实验
{
   
    class Program
    {
        public static List<int> poslist=new List<int>();

       
        static List<string> StringList()
        {
            var list = new List<string>();
            string s1 = "吃饭";
            string s2 = "洗澡";
            string s3 = "刷牙";
            string s4 = "看电视";
            string s5 = "我就是想写一个字多一点的选项好实验一下程序写的对不对";
            string s6 = "再来个短点的跟前面对比";
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);
            list.Add(s5);
            list.Add(s6);
            return list;
        }
        static void DrawChoiceText(int indext, string name, int position)
        {
            Console.SetCursorPosition(position, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((1 + indext) + "." + name + " ");
            Console.SetCursorPosition(0, 0);
        }
        static void DrawChoicedText(int indext, string name, int position)
        {
            Console.BackgroundColor = (ConsoleColor)(15 - (int)ConsoleColor.Black);
            Console.ForegroundColor = (ConsoleColor)(15 - (int)ConsoleColor.Red);
            Console.SetCursorPosition(position, 10);
            Console.Write((1 + indext) + "." + name + " ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }
     
        static void DrawAllText(List<string> list)
        {
            for(int i=0;i<list.Count;i++)
            {
                DrawChoiceText(i,list[i],poslist[i]);
            }
        }
        static void GetChoice(List<string> list)
        {
            int index = 0;
            DrawChoicedText(index, list[index], poslist[index]);
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key==ConsoleKey.LeftArrow)
                {
                    if(index>0)
                    {
                        DrawChoiceText(index, list[index], poslist[index]);
                        index--;
                        DrawChoicedText(index, list[index], poslist[index]);
                    }
                }
                else if(key.Key==ConsoleKey.RightArrow)
                {
                    if(index<list.Count-1)
                    {
                        DrawChoiceText(index, list[index], poslist[index]);
                        index++;
                        DrawChoicedText(index, list[index], poslist[index]);
                    }

                }

            }
            
        }
        static int GetTextLength(string text)
        {
            byte[] bytes;
            int length = 0;
            for(int i=0;i<text.Length;i++)
            {
                bytes = Encoding.Default.GetBytes(text.Substring(i, 1));
                if(bytes.Length>1)
                {
                    length += 2;
                }
                else
                {
                    length += 1;
                }
            }
            return length;
        }
      
        static void AddTextPosition(List<string> list)
        {
            poslist.Clear();
            int length = 0;
            for(int i=0;i<list.Count;i++)
            {
                poslist.Add(length);
                length += GetTextLength(1 + "." + list[i] + " ");
            }

        }
        static void Main(string[] args)
        {
            var list = StringList();
            AddTextPosition(list);
            DrawAllText(list);
            GetChoice(list);
            Console.ReadKey(true);
        }
    }
}
