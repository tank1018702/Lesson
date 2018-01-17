using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字典和列表转换
{
    class Program
    {
        static Random random = new Random();
        static List<string> GetString_List()
        {
            var list = new List<string>();
            int randomcount;
            while (true)
            {
                 randomcount = random.Next(10, 21);
                if (randomcount % 2 == 0)
                {
                    break;
                }
            }
           
            for(int i=0;i<randomcount;i++)
            {
                list.Add(Convert.ToString(Convert.ToChar(random.Next(65,122)))+ Convert.ToString(Convert.ToChar(random.Next(65,122)))+ Convert.ToString(Convert.ToChar(random.Next(65,122))));
            }
            return list;
        }
        static void PrintContainer(List<string> list)
        {
            int i = 0;
            foreach (var v in list)
            {
                
                Console.Write(" |{0}:[{1}]| ", i, v);
                i++;
            }
            Console.WriteLine();

        }
        static void PrintContainer(Dictionary<string,string> dictionary)
        {
            
            foreach (var v in dictionary)
            {

                Console.Write(" |[{0}]:[{1}]| ", v.Key, v.Value);
                
            }
            Console.WriteLine();
        }
        static void Transform(List<string> list, Dictionary<string, string> dictionary)
        {
            for (int i=0;i<list.Count; i+=2)
            {
                dictionary[list[i]] = list[i + 1];     
            }
        }
        static void Transform(Dictionary<string, string> dictionary, List<string> list)
        {
            foreach(var dict in dictionary)
            {
                list.Add(dict.Key);
                list.Add(dict.Value);
            }
        }
        static void Main(string[] args)
        {
            var list = GetString_List();
            PrintContainer(list);
            Console.WriteLine("-----------------------------------------");
            var dict = new Dictionary<string, string>();
            Transform(list, dict);
            PrintContainer(dict);
            Console.WriteLine("------------------------------------------");
            var New_list = new List<string>();
            Transform(dict, New_list);
            PrintContainer(New_list);
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
        }
    }
}
