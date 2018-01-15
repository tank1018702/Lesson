using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    class Manager
    {
        List<int> datas = new List<int>();

        public void AddData(int n)
        {
            datas.Add(n);
        }

        public void Print()
        {
            foreach (var n in datas)
            {
                Console.Write(n+" ");
            }
            Console.WriteLine();
        }

        // 以下是整体修改数据的接口

        public delegate int ProcessData(int n);

        public void ChangeDatas(ProcessData process)
        {
            for (int i=0; i<datas.Count; ++i)
            {
                datas[i] = process(datas[i]);
            }
        }

    }
}
