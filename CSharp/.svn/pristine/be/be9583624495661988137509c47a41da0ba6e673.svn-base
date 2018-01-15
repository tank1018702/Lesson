using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    class Program
    {
        delegate void Level();

        delegate int Test(int a , int b, int c);

        static void LevelA()
        {
            Console.WriteLine("盖伦");
        }

        static void LevelB()
        {
            Console.WriteLine("寒冰射手");
        }

        static void LevelC()
        {
            Console.WriteLine("瑞兹");
        }

        static void LevelD()
        {
            Console.WriteLine("光辉女郎");
        }

        static int Double(int n)
        {
            return n * 2;
        }

        static int Filter(int n)
        {
            if (n < 3)
            {
                return 0;
            }
            return n;
        }

        static void Main(string[] args)
        {
            //List<Level> levels = new List<Level> { LevelA, LevelB, LevelC, LevelD };
            //levels.RemoveAt(2);
            ///*
            //List <Level> levels = new List<Level>();
            //levels.Add(LevelA);
            //levels.Add(LevelB);
            //levels.Add(LevelC);
            //levels.Add(LevelD);
            //*/
            //int level = 1;
            //for (level = 1; level<=4; level++)
            //{
            //    Level l = levels[level - 1];
            //    l();
            //}

            //Level level;
            //level = new Level(LevelA);
            //level();
            //level = LevelD;
            //level();

            Manager m = new Manager();
            m.AddData(1);
            m.AddData(2);
            m.AddData(3);
            m.AddData(4);
            m.AddData(5);
            m.Print();

            m.ChangeDatas(Filter);
            m.Print();

            
            Console.ReadKey();
        }
    }
}
