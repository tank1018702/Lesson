using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 递归求LIST的和
{
    class Program
    {
        static int Sum(List<int> list)
        {
            int n = 0;
            if (list.Count < 1)
            {
                return 0;
            }
             n = list[0];
            list.RemoveAt(0);
            n += Sum(list);            
            return n;         
        }
        static int Sum2(List<int> list, int indext)
        {
            
            if(indext<0)
            {
                return 0;
            } 
            return list[indext]+Sum2(list,indext-1);
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for(int i=1;i<21;i++)
            {
                list.Add(i);
            }
            int a = Sum2(list,list.Count-1);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
