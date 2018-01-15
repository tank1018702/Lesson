using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Threading.Tasks;
using System.Diagnostics;

namespace OrderAndAccountBook
{
    public class OrderForm
    {
        public int id = 0;
        public string name;
        public int num;
        public double price;

        public OrderForm(string _name, double _price, int _num)
        {
            name = _name;
            num = _num;
            price = _price;
        }

        public double GetPrice()
        {
            return price * num;
        }

        public override string ToString()
        {
            return "Order:" + " " + id + ":" + name + " " + num + " " + price;
        }

        public string Seriallize()
        {
            return string.Format("{0}|{1}|{2}|{3}", id, name, num, price);
        }

        public bool Deseriallize(string s)
        {
            string[] l = s.Split("|".ToCharArray());
            if (l.Length != 4)
            {
                return false;
            }
            id = int.Parse(l[0]);
            name = l[1];
            num = int.Parse(l[2]);
            price = double.Parse(l[3]);
            return true;
        }

        public bool Seriallize_Stream(BinaryWriter writer)
        {
            writer.Write(id);
            writer.Write(name);
            writer.Write(num);
            writer.Write(price);
            return true;
        }

        public bool Deseriallize_Stream(BinaryReader reader)
        {
            id = reader.ReadInt32();
            name = reader.ReadString();
            num = reader.ReadInt32();
            price = reader.ReadDouble();
            return true;
        }
    }

    public class AccountBook
    {
        protected Dictionary<int, OrderForm> dict = new Dictionary<int, OrderForm>();
        protected Dictionary<string, List<OrderForm>> dict_name = new Dictionary<string, List<OrderForm>>();
        
        int id_counter = 1;

        public void AddOrder(OrderForm order)
        {
            dict[id_counter] = order;
            order.id = id_counter;

            if (!dict_name.ContainsKey(order.name))
            {
                dict_name.Add(order.name, new List<OrderForm>());
            }
            List<OrderForm> l = dict_name[order.name];
            l.Add(order);

            //dict.Add(id_counter, order);
            id_counter += 1;
        }

        public OrderForm GetOrder(int id)
        {
            OrderForm temp = null;
            dict.TryGetValue(id, out temp);
            return temp;
        }

        public List<OrderForm> GetOrder(string name)
        {
            if (!dict_name.ContainsKey(name))
            {
                return null;
            }
            return dict_name[name];
        }

        public double GetTotal()
        {
            double total = 0.0;
            foreach (var pair in dict)
            {
                total += pair.Value.GetPrice();
            }
            return total;
        }

        public void PrintAll()
        {
            Console.WriteLine("账本内容：");
            foreach (var pair in dict)
            {
                Console.WriteLine(pair.Value);
            }
            Console.WriteLine("======END======");
        }

        public bool SaveToFile()
        {
            string s = "";
            foreach (var pair in dict)
            {
                s += pair.Value.Seriallize();
                s += "\n";
            }

            FileStream file = new FileStream("E:\\test.txt", FileMode.Create);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            file.Write(bytes, 0, bytes.Length);
            file.Close();
            return true;
        }

        public bool SaveToFile_Stream()
        {
            FileStream file = new FileStream("E:\\test.txt", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(file);
            foreach (var pair in dict)
            {
                pair.Value.Seriallize_Stream(writer);
            }
            file.Close();
            return true;
        }

        public int LoadFromFile()
        {
            int len = 0;
            FileStream file = null;
            byte[] bytes = new byte[10240];
            try
            {
                file = new FileStream("E:\\test.txt", FileMode.Open);
                len = file.Read(bytes, 0, 10240);
            }
            catch(FileNotFoundException e)
            {
                Debug.WriteLine("FileNotFoundException " + e.FileName);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
            string source = Encoding.UTF8.GetString(bytes);
            Debug.WriteLine("Load File:" + source);

            string[] l = source.Split("\n".ToCharArray());
            for (int i=0; i<l.Length; ++i)
            {
                OrderForm order = new OrderForm("", 0, 0);
                bool success = order.Deseriallize(l[i]);
                if (!success)
                {
                    Console.WriteLine("反序列化错误" + l[i] + ".");
                    continue;
                }
                AddOrder(order);
            }

            return len;
        }

        public bool LoadFromFile_Stream()
        {
            FileStream file = null;
            try
            {
                file = new FileStream("E:\\test.txt", FileMode.Open);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("FileNotFoundException " + e.FileName);
            }

            if (file == null)
            {
                return false;
            }

            BinaryReader reader = new BinaryReader(file);
            while (file.Position < file.Length)
            {
                OrderForm order = new OrderForm("", 0, 0);
                if (!order.Deseriallize_Stream(reader))
                {
                    return false;
                }
                AddOrder(order);
            }
            file.Close();
            return true;
        }
    }

    class Program
    {

        static void ShowOrder(AccountBook book, int id)
        {
            OrderForm order = book.GetOrder(id);
            if (order != null)
            {
                Console.WriteLine(order);
            }
            else
            {
                Console.WriteLine("没有找到订单ID " + id);
            }
        }

        static void ShowOrder(AccountBook book, string name)
        {
            List<OrderForm> l = book.GetOrder(name);
            if (l == null || l.Count == 0)
            {
                Console.WriteLine("没有找到订单Name " + name);
                return;
            }

            for (int i=0; i<l.Count; ++i)
            {
                Console.Write(l[i]);
                Console.Write("   ");
            }
            Console.WriteLine();
        }

        static void TestSave()
        {
            OrderForm order1 = new OrderForm("冰激凌", 10.0, 1);
            OrderForm order2 = new OrderForm("苹果", 1.0, 2);
            OrderForm order3 = new OrderForm("香蕉", 0.8, 5);
            OrderForm order4 = new OrderForm("香蕉", 0.8, 3);
            OrderForm order5 = new OrderForm("冰激凌", 10.0, 3);

            AccountBook book = new AccountBook();
            book.AddOrder(order1);
            book.AddOrder(order2);
            book.AddOrder(order3);
            book.AddOrder(order4);
            book.AddOrder(order5);

            ShowOrder(book, "冰激凌");
            ShowOrder(book, "香蕉");
            ShowOrder(book, "芝麻");

            //book.SaveToFile();
            book.SaveToFile_Stream();
        }

        static void TestLoad()
        {
            AccountBook book = new AccountBook();
            //book.LoadFromFile();
            book.LoadFromFile_Stream();

            book.PrintAll();
        }

        static void Main(string[] args)
        {
            TestSave();
            //TestLoad();

            Console.ReadKey();
        }
    }
}
