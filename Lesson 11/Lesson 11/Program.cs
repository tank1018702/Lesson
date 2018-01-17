using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
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
            PrintDictionary(MergeDictionary(dictA, dictB));
            Console.ReadKey();
        }
    }
}
