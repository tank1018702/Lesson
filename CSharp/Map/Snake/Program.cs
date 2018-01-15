using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Snake
{
    enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }
    class Program
    {
        static int width = 20;
        static int height = 14;
        static char[,] buffer;
        static Snake snake;

        class Vec2
        {
            public int x = 0;
            public int y = 0;

            public Vec2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        // 演示一种经典的循环链表，代表蛇
        class Snake
        {
            List<Vec2> list = new List<Vec2>();
            int head = 0;
            public Direction direction;

            public Snake(int x, int y, int len)
            {
                for (int i=0; i<len; ++i)
                {
                    Vec2 vec2 = new Vec2(x, y);
                    list.Add(vec2);
                    x += 1;
                    y += 0;
                }
                direction = Direction.Left;
            }


            // 确定第几节身体，在list中的下标
            // 注意处理负数
            int Loop(int i)
            {
                int ret = (head + i + list.Count()) % list.Count();
                Debug.WriteLine("Loop " + head +" " + i + "=" + ret);
                return ret;
            }

            public int Len
            {
                get
                {
                    return list.Count();
                }
            }

            public Vec2 GetBody(int i)
            {
                return list[Loop(i)];
            }

            public void SetDirection(Direction dir)
            {
                if (dir == Direction.None)
                {
                    return;
                }
                switch(direction)
                {
                    case Direction.Up:
                        if (dir == Direction.Down)
                        {
                            return;
                        }
                        break;
                    case Direction.Down:
                        if (dir == Direction.Up)
                        {
                            return;
                        }
                        break;
                    case Direction.Left:
                        if (dir == Direction.Right)
                        {
                            return;
                        }
                        break;
                    case Direction.Right:
                        if (dir == Direction.Left)
                        {
                            return;
                        }
                        break;
                }
                direction = dir;
            }

            public void DebugLog()
            {
                Debug.Write(""+head+":");
                for (int i=0; i<list.Count(); ++i)
                {
                    Debug.Write("" + list[i].x + "-" + list[i].y + "  ");
                }
                Debug.WriteLine("");
            }

            public void Move()
            {
                DebugLog();
                Vec2 last_pos = list[head];
                head = Loop(-1);        // -1 代表尾巴位置
                switch(direction)
                {
                    case Direction.Up:
                        list[head] = new Vec2(last_pos.x, last_pos.y-1);
                        break;
                    case Direction.Down:
                        list[head] = new Vec2(last_pos.x, last_pos.y+1);
                        break;
                    case Direction.Left:
                        list[head] = new Vec2(last_pos.x-1, last_pos.y);
                        break;
                    case Direction.Right:
                        list[head] = new Vec2(last_pos.x+1, last_pos.y);
                        break;
                }
            }
        }

        // 画边界
        static void DrawBorder()
        {
            // 上边
            for (int i = 0; i < width + 2; ++i)
            {
                buffer[1, i] = '#';
            }

            // 左边
            for (int i = 1; i < height + 2; ++i)
            {
                buffer[i, 0] = '#';
            }

            // 下边
            for (int i = 0; i < width + 2; ++i)
            {
                buffer[height + 1, i] = '#';
            }
            // 右边
            for (int i = 1; i < height + 2; ++i)
            {
                buffer[i, width + 1] = '#';
            }
        }

        static void DrawAll()
        {
            DrawBorder();
            for (int i=0; i<snake.Len; ++i)
            {
                Vec2 v = snake.GetBody(i);
                buffer[v.y+1, v.x+1] = 'o';
            }
        }

        static Direction Input()
        {
            var key = Console.ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
            }
            return Direction.None;
        }
        
        static bool CheckDead()
        {
            Vec2 head = snake.GetBody(0);
            if (head.x<0 || head.x>=width)
            {
                return true;
            }
            if (head.y<0 || head.y>=height)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            ConsoleCanvas canvas = new ConsoleCanvas(width+2, height+2);
            buffer = canvas.GetBuffer();

            // 逻辑初始化
            snake = new Snake(5, 5, 8);

            // 初始化图像
            canvas.ClearBuffer();
            DrawAll();
            canvas.Refresh();

            while (true)
            {
                Direction dir = Direction.None;
                // 用while循环，不断吃掉用户输入，防止一帧内频繁按键
                while (Console.KeyAvailable)
                {
                    dir = Input();
                }
                snake.SetDirection(dir);
                snake.Move();
                if (CheckDead())
                {
                    break;
                }
                canvas.ClearBuffer();
                DrawAll();
                canvas.Refresh();
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
