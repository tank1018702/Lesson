using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    class TestDict
    {
        // 初始化Dictionary
        public static void InitDict(Dictionary<string, int> dict)
        {
            if (dict == null)
            {
                Console.WriteLine("====初始化错误 : dict参数为空 ====");
                return;
            }
            // 清空内容
            dict.Clear();
            // 添加10个元素
            for (int i = 0; i < 10; ++i)
            {
                dict.Add("K"+i, i);
            }
            Console.WriteLine("====已重新初始化 dict ====");
            return;
        }

        public static void PrintDict(Dictionary<string, int> d)
        {
            foreach (var pair in d)
            {
                Console.Write("{0}:{1} ", pair.Key, pair.Value);
            }
            Console.WriteLine();
            return;
        }

        public static void TestDict1()
        {
            var dict = new Dictionary<string, int>();
            InitDict(dict);
            dict["K1"] = 8;
            PrintDict(dict);

            Console.WriteLine("--------------------------------");
            dict.Add("Hello", 333);
            dict.Remove("K1");
            PrintDict(dict);

            Console.WriteLine("--------------------------------");
            // 几种可能产生异常的情况
            //Console.WriteLine(dict["KKKKK"]);        // 异常：Key不存在
            //dict.Add("K3", 22323);                   // 异常：Key已经存在

            Console.WriteLine("-----试着获取不确定的Key------------------------");
            InitDict(dict);
            int v = 0;
            if (dict.TryGetValue("Hello", out v))
            {
                Console.WriteLine("Hello有值 {0}", v);
            }
            else
            {
                Console.WriteLine("Hello不存在");
            }
            dict.Add("Hello", 444);
            if (dict.TryGetValue("Hello", out v))
            {
                Console.WriteLine("Hello有值 {0}", v);
            }
            else
            {
                Console.WriteLine("Hello不存在");
            }
            return;
        }

        public static void TestDict_Copy()
        {
            var dict = new Dictionary<string, int>();
            InitDict(dict);

            // 方法一
            var dict2 = new Dictionary<string, int>();
            foreach(var pair in dict)
            {
                dict2[pair.Key] = pair.Value;
                // 或者是
                // dict2.Add(pair.Key, pair.Value);
            }

            // 方法二
            var dict3 = new Dictionary<string, int>(dict);

            Console.WriteLine("Dictionary的拷贝问题，与List类似，具体看代码");
        }

        public static void TestDict_Loop1()
        {
            // 循环中改写字典
            var dict = new Dictionary<string, int>();
            InitDict(dict);

            foreach (var pair in dict)
            {
                // 会导致编译不过
                //pair.Value = 333;
            }
            PrintDict(dict);
        }

        public static void TestDict_Loop2()
        {
            var dict = new Dictionary<string, int>();
            InitDict(dict);

            Console.WriteLine("-------------循环删除------------");
            // 循环中删除元素
            foreach (var k in dict.Keys)
            {
                dict.Remove(k);
            }
            PrintDict(dict);
        }


        public static void TestDict_Loop3()
        {
            var dict = new Dictionary<string, int>();
            InitDict(dict);

            Console.WriteLine("-------------修改字典正确做法举例------------");
            PrintDict(dict);
            Console.WriteLine("删除K2、K4、K8等偶数Key");
            var l = new List<string>();
            foreach (var pair in dict)
            {
                string s = pair.Key;
                if ( s[0] == 'K' && Int32.Parse(s.Substring(1))%2 == 0 )
                {
                    l.Add(pair.Key);
                }
            }

            foreach (var key in l)
            {
                dict.Remove(key);
            }

            PrintDict(dict);
            return;
        }

    }
}
