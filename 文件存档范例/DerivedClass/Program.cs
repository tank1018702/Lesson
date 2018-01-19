using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedClass
{
    class Monster
    {
        public virtual void BeHit()
        {
        }
    }

    class Slam : Monster
    {
        public override void BeHit()
        {
            Console.WriteLine("史莱姆逃跑了...");
        }
    }

    class Mario : Monster
    {
        public override void BeHit()
        {
            Console.WriteLine("不要打我~~");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Monster m;
            m = new Slam();
            m.BeHit();
            m = new Mario();
            m.BeHit();

            Console.ReadKey();
        }
    }
}
