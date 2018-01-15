using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    class TestList
    {
        public static List<int> l = null;
        // 初始化List
        public static void InitList()
        {
            if (l == null)
            {
                // 新建
                l = new List<int>();
            }
            else
            {
                // 清空内容
                l.Clear();
            }
            // 添加10个元素
            for (int i = 0; i < 10; ++i)
            {
                l.Add(i);
            }
            Console.WriteLine("====已重新初始化 l ====");
            return;
        }

        public static void PrintList(List<int> l)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                Console.Write("{0} ", l[i]);
            }
            Console.WriteLine();
            return;
        }

        // List演示
        public static void TestList1()
        {
            // 添加完毕，现在l里面是[0,1,2,3,4,5,6,7,8,9]
            InitList();
            Console.WriteLine("List演示开始, 内容：");
            PrintList(l);

            // 用下标读写
            Console.WriteLine("------------------------------------");
            Console.WriteLine("下标:{0}, 内容:{1}", 4, l[4]);
            Console.WriteLine("修改下标4的内容...");
            l[4] = 444;
            Console.WriteLine("下标:{0}, 内容:{1}", 4, l[4]);

            // 试试下标越界
            //Console.WriteLine("下标:{0}, 内容:{1}", 10, l[10]);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("删除前");
            PrintList(l);

            // 删除元素
            //     1. 按值删除
            l.Remove(444);
            Console.WriteLine("删除值444后");
            PrintList(l);

            //     2. 按下标删除
            l.RemoveAt(4);

            Console.WriteLine("删除下标4后");
            PrintList(l);

            Console.WriteLine("------------------------------------");

            // 用Insert函数恢复删除之前的样子
            l.Insert(4, 5);
            l.Insert(4, 4);

            Console.WriteLine("Insert后");
            PrintList(l);
        }
        
        // 演示List复制
        public static void TestList_Copy()
        {
            InitList();
            // 新建一个List，直接=号赋值
            //List<int> l2 = null;
            List<int> l2 = new List<int>();
            l2 = l;

            Console.WriteLine("l:");
            PrintList(l);
            Console.WriteLine("l2:");
            PrintList(l2);

            l.Insert(0, 999);

            Console.WriteLine("修改l之后：");
            Console.WriteLine("l:");
            PrintList(l);
            Console.WriteLine("l2:");
            PrintList(l2);

            Console.WriteLine("--------正确的拷贝方法-----------");
            InitList();
            // 1. 利用构造函数
            List<int> l3 = new List<int>(l);

            // 2. for循环, 通用性强
            List<int> l4 = new List<int> { 1,2,3,4,54,56,6,7,7,8,98,9,9,99};
            if (l4.Count > l.Count)
            {
                l4.RemoveRange(l.Count - 1, l4.Count - l.Count);
            }
            for (int i=0; i<l.Count; ++i)
            {
                if (i<l4.Count)
                {
                    l4[i] = l[i];
                }
                else
                {
                    l4.Add( l[i] );
                }
            }

            l.Insert(0, 888);
            Console.WriteLine("修改l之后：");
            Console.WriteLine("l:");
            PrintList(l);
            Console.WriteLine("l3:");
            PrintList(l3);
            Console.WriteLine("l4:");
            PrintList(l4);
            return;
        }

        public static void TestList_Remove()
        {
            InitList();

            for (int i=0; i<l.Count; ++i)
            {
                l.RemoveAt(i);
            }

            Console.WriteLine("------------删除后, l:-----------");
            PrintList(l);

            InitList();
            while (l.Count>0)
            {
                l.RemoveAt(0);
            }
            Console.WriteLine("------------删除后, l:-----------");
            PrintList(l);

            InitList();
            Console.WriteLine("------------只删除偶数，开始------");
            int ii = 0;
            while (ii < l.Count)
            {
                if (l[ii] % 2 == 0)
                {
                    l.RemoveAt(ii);
                }
                else
                {
                    ++ii;
                }
            }
            PrintList(l);
            
            return;
        }
    }
}
