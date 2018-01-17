using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生管理器
{
    class Tool
    {
        public static Random random = new Random();
    }

    class Program
    {
        static Dictionary<int, Student> GetStudentDictionary()
        {
            var dict = new Dictionary<int, Student>();
            Student student1 = new Student("大狗", 001);
            dict.Add(student1.ID, student1);
            Student student2 = new Student("小王", 002);
            dict.Add(student2.ID, student2);
            Student student3 = new Student("如花", 003);
            dict.Add(student3.ID, student3);
            Student student4 = new Student("阿强", 004);
            dict.Add(student4.ID, student4);
            Student student5 = new Student("大锤", 005);
            dict.Add(student5.ID, student5);
            Student student6 = new Student("狗蛋", 006);
            dict.Add(student6.ID, student6);
            Student student7 = new Student("小明", 007);
            dict.Add(student7.ID, student7);
            Student student8 = new Student("老高", 008);
            dict.Add(student8.ID, student8);
            Student student9 = new Student("大壮", 009);
            dict.Add(student9.ID, student9);
            Student student10 = new Student("翠花", 010);
            dict.Add(student10.ID, student10);
            return dict;

        }
        static void PrintDictionary(Dictionary<int, Student> dictionary)
        {
            foreach(var stu in dictionary)
            {
                Console.WriteLine("姓名:{0}  年龄:{1}岁  身高:{2}CM  体重:{3}公斤", stu.Value.Name, stu.Value.Age, stu.Value.High, stu.Value.Weight);
            }
        }
        static void Main(string[] args)
        {
            var StudentList = GetStudentDictionary();
            PrintDictionary(StudentList);
            Console.WriteLine("------------------------------------------------------");
            StudentList =  StudentList.OrderBy(p => p.Value.Name).ToDictionary(p => p.Key, o => o.Value);
            //List<KeyValuePair<int,Student>> list = StudentList.ToList();
            // var xx = StudentList.GetEnumerator();
            //while (xx.MoveNext())
            //{
            //    xx.Current.ke
            //}

            PrintDictionary(StudentList);
            Console.ReadKey();
        }
    }
    class Student
    {
        public string Name;
        public int Age;
        public int Weight;
        public int High;
        public int ID;
        public Student(string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
            Age = Tool.random.Next(15, 31);
            Weight = Tool.random.Next(50, 121);
            High = Tool.random.Next(150, 210);
        }
    }
}
