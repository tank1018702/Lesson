using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vec2
    {
        public float x;
        public float y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2 Add(Vec2 v)
        {
            return new Vec2(x+v.x, y+v.y);
        }

        public static Vec2 operator+ (Vec2 v1, Vec2 v2)
        {
            return v1.Add(v2);
        }

    }

    class Player
    {
        int id = 0;
        Vec2 pos = new Vec2(0,0);

        public Vec2 Pos
        {
            get
            {
                return pos;
            }
            set
            {
                Console.WriteLine("调用了Pos.set方法");
                pos = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 测试访问器
            Player p = new Player();
            p.Pos.x = 1;
            p.Pos = new Vec2(3, 4);

            // 测试重载+号
            Vec2 v1 = new Vec2(3,4);
            Vec2 v2 = new Vec2(5,6);
            v1 += v2;

            Console.ReadKey();
        }
    }
}
