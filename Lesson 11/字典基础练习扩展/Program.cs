using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字典基础练习扩展
{
    class Program
    {
        static Random random = new Random();

        static Dictionary<string, int> GetDictionary()
        {
            var dictionary = new Dictionary<string, int>();
            for (int i = 97; i <= 122; i++)
            {
                dictionary[Convert.ToString(Convert.ToChar(i))] = random.Next(1, 11);
            }
            return dictionary;
        }
        static void PrintDictionary(Dictionary<string, int> dictionary)
        {
            foreach (var dict in dictionary)
            {
                Console.Write(" |{0}:{1}| ", dict.Key, dict.Value);
            }
            Console.WriteLine();
            Console.WriteLine("__________________________________");
        }
        static List<string> GetEvenNumberKey(Dictionary<string, int> dictionary)
        {
            var list = new List<string>();
            foreach (var dict in dictionary)
            {
                if (dict.Value % 2 == 0)
                {
                    list.Add(dict.Key);
                }
            }
            return list;
        }
        static void Remove_EvenNumberInDictionary(Dictionary<string, int> dictionary, List<string> list)
        {
            foreach (string key in list)
            {
                dictionary.Remove(key);
            }
        }
        static Dictionary<string, int> MergeDictionary(Dictionary<string, int> dictionary_A, Dictionary<string, int> dictionary_B)
        {
            foreach (var dict in dictionary_B)
            {
                if (!dictionary_A.ContainsKey(dict.Key))
                {
                    dictionary_A.Add(dict.Key, dict.Value);
                }
            }
            return dictionary_A;
        }
        static Dictionary<string, List<int>> MeregeDictionary_plus(Dictionary<string, int> dictionary_A, Dictionary<string, int> dictionary_B)
        {
            var dict_c = new Dictionary<string, List<int>>();
            foreach (var dict_a in dictionary_A)
            {
                dict_c[dict_a.Key] = new List<int>();
                dict_c[dict_a.Key].Add(dict_a.Value);
            }
            foreach (var dict_b in dictionary_B)
            {
                if (!dict_c.ContainsKey(dict_b.Key))
                {
                    dict_c[dict_b.Key] = new List<int>();                   
                }
                dict_c[dict_b.Key].Add(dict_b.Value);
            }
            return dict_c;
        }
        static void PrintContainer(List<int> list)
        {
            int i = 0;
            Console.Write("{");
            foreach (var v in list)
            {
                
                Console.Write(" {0}:{1} ", i, v); 
                i++;
            }
            Console.Write("}");

        }
        static void PrintDictionary(Dictionary<string, List<int>> dictionary)
        {
            Console.Write(" ||");
            foreach (var dict in dictionary)
            {
                Console.Write("{0}:", dict.Key);
                PrintContainer(dict.Value);
                Console.Write("|| ");
            }          
        }
        

        static void Main(string[] args)
        {
            var dictA = GetDictionary();
            var dictB = GetDictionary();
            PrintDictionary(dictA);
            PrintDictionary(dictB);
            var KeyList_A = GetEvenNumberKey(dictA);
            var Keylist_B = GetEvenNumberKey(dictB);
            Remove_EvenNumberInDictionary(dictA, KeyList_A);
            Remove_EvenNumberInDictionary(dictB, Keylist_B);
            PrintDictionary(dictA);
            PrintDictionary(dictB);
            Console.WriteLine("合并两个数组后:");
            var dict_c = MeregeDictionary_plus(dictA, dictB);
            PrintDictionary(dict_c);
            Console.ReadKey();
        }
    }
}
