using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Player
    {
        int hp;
        int money;
    }

    class Monster
    {
        public int x;
        public int y;
        public string name;

        public Monster(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }

    class Program
    {
        static int playerX = 0;
        static int playerY = 0;

        const int mapWidth = 20;
        const int mapHeight = 10;

        static List<Monster> monsters = new List<Monster>();

        static void ScreenToLogicXY(int x, int y, out int lx, out int ly)
        {
            lx = x - 1;
            ly = y - 1;
        }

        static void LogicToScreenXY(int x, int y, out int sx, out int sy)
        {
            sx = x + 1;
            sy = y + 1;
        }

        static void DrawBorder()
        {
            int playerSX, playerSY;
            LogicToScreenXY(playerX, playerY, out playerSX, out playerSY);

            for (int i=0; i<mapWidth; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            for (int y=1; y<mapHeight-1; y++)
            {
                Console.Write("#");
                for (int x=1; x<mapWidth-1; x++)
                {
                    if (x==playerSX && y==playerSY)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        bool hasMonster = false;
                        foreach (Monster m in monsters)
                        {
                            int sx, sy;
                            LogicToScreenXY(m.x, m.y, out sx, out sy);
                            if (sx == x && sy == y)
                            {
                                hasMonster = true;
                                Console.Write(m.name);
                                break;
                            }
                        }
                        if (!hasMonster)
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.Write("#");
                Console.WriteLine();
            }

            for (int i=0; i<mapWidth; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

        }

        static void Logic()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                playerY--;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                playerY++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                playerX--;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                playerX++;
            }
        }

        static void Init()
        {
            monsters.Add(new Monster(2,2,"A"));
            monsters.Add(new Monster(3,3,"B"));
            monsters.Add(new Monster(mapWidth-3, mapHeight-3,"C"));
            DrawBorder();
        }

        static void Main(string[] args)
        {
            Init();
            while (true)
            {
                Logic();

                Console.Clear();
                DrawBorder();
            }
            Console.ReadKey();
        }
    }
}
