using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_13
{
    class Program
    {
        //static string Seriallize()
        //{

        //}
        static void TestSave(FileDictionary fileDictionary)
        {
            fileDictionary.SaveToFile_Stream();

        }
        static void TestLoad()
        {
            FileDictionary file = new FileDictionary();
            file.LoadFromFile_Stream();
            file.PrintLoad();
        }
        static void GetInput(FileDictionary fileDictionary)
        {
            if (fileDictionary._Dict.ContainsKey(fileDictionary.Serial))
                fileDictionary.Serial++;

            Console.WriteLine("输入一组字符串:");
            string s = Console.ReadLine();
            Console.WriteLine("输入一个整数:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("输入一个小数:");
            double d = double.Parse(Console.ReadLine());
            var input1 = new Input_and_Load(s, n, d);
            input1.ID = fileDictionary.Serial;
            fileDictionary._Dict.Add(fileDictionary.Serial, input1);
        }
        static void Main(string[] args)
        {
            var filedict = new FileDictionary();
            GetInput(filedict);
            TestSave(filedict);
            TestLoad();
            Console.ReadKey();
        }


    }

    class Input_and_Load
    {
        public string s;
        public int n;
        public double d;
        public int ID = 0;
        public Input_and_Load(string s, int n, double d)
        {
            this.s = s;
            this.n = n;
            this.d = d;
        }
        public void SerialLize_Stream(BinaryWriter writer)
        {
            writer.Write(s);
            writer.Write(n);
            writer.Write(d);
        }
        public void Deseriallize_Stream(BinaryReader reader)
        {
            
            s = reader.ReadString();
            n = reader.ReadInt32();
            d = reader.ReadDouble();
        }

    }
    class FileDictionary
    {
        public int Serial = 0;
        public Dictionary<int, Input_and_Load> _Dict = new Dictionary<int, Input_and_Load>();
        public List<Input_and_Load> LoadList = new List<Input_and_Load>();
        public void AddInPut_Load(Input_and_Load input_And_Load)
        {
            _Dict[Serial] = input_And_Load;
            input_And_Load.ID = Serial;
            LoadList.Add(input_And_Load);

        }
        public void SaveToFile_Stream()
        {
            FileStream file = new FileStream("E:\\test.txt", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(file);
            foreach (var pair in _Dict)
            {
                pair.Value.SerialLize_Stream(writer);
            }
            file.Close();
        }
        public void LoadFromFile_Stream()
        {
            FileStream file = new FileStream("E:\\test.txt", FileMode.Open);
            BinaryReader reader = new BinaryReader(file);
            while (file.Position < file.Length)
            {
                Input_and_Load load = new Input_and_Load("",0,0.00);
                load.Deseriallize_Stream(reader);
                

                
                
                AddInPut_Load(load);
            }
            file.Close();
        }
        public void PrintLoad()
        {
            Console.WriteLine("输入的内容");
            foreach(var list in LoadList)
            {
                
                Console.WriteLine(list.s);
                Console.WriteLine(list.n);
                Console.WriteLine(list.d);
            }
            Console.WriteLine("======END======");
        }
    }
}


