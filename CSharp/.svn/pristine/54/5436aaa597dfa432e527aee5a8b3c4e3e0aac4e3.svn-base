using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkDirectory
{
    class Program
    {
        public static List<string> WalkDirRecursive(string sSourcePath, List<String> list = null)
        {
            if (list == null)
            {
                list = new List<string>();
            }
            //在指定目录及子目录下查找文件,在list中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(sSourcePath);
            DirectoryInfo[] DirSub = Dir.GetDirectories();

            foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
            {
                list.Add(Dir + @"\" + f.ToString());
            }

            foreach (DirectoryInfo d in DirSub)//查找子目录 
            {
                list.Add(Dir + @"\" + d.ToString());
                WalkDirRecursive(Dir + @"\" + d.ToString(), list);
            }

            return list;
        }


        public static List<string> WalkDir_FilesOnly(string sSourcePath)
        {
            List<String> list = new List<string>();
            DirectoryInfo Dir = new DirectoryInfo(@"..\..");

            foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.AllDirectories)) //查找文件
            {
                list.Add(Dir + @"\" + f.FullName);
            }

            return list;
        }


        static void Main(string[] args)
        {
            List<string> l = WalkDir_FilesOnly(@"..\..");
            foreach (string s in l)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("--------------------------");

            l = WalkDirRecursive(@"..\..");
            foreach (string s in l)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
