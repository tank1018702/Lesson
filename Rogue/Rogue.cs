using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


// Rogue类是实现整个游戏基本流程的。一开始自定义关卡时，不要修改Rogue类的实现
// 建议熟悉以后再修改
namespace Rogue
{
    public class Rogue
    {
        const int width = 100;
        const int height = 28;

        public const int map_width = 30;
        public const int map_height = 15;

        static ConsoleCanvas canvas = null;
        static char[,] buffer = null;
        static ConsoleColor[,] color_buffer = null;

        public static Random random = new Random();

        public static Player player;
        public static Dictionary<int, Monster> monsters = new Dictionary<int, Monster>();
        public static Dictionary<int, Money> moneys = new Dictionary<int, Money>();
        public static Dictionary<int, NPC> npcs = new Dictionary<int, NPC>();

        public static string below_text = "";
        public static string level_target = "";

        public static bool game_over;
        public static bool victory;

        // 委托，用于扩展关卡用。自定义关卡初始化函数
        public delegate void InitStage();
        static List<InitStage> stages = new List<InitStage>();
        // 委托，用于自定义怪物死亡时处理
        public delegate bool OnMonsterDead(Monster monster);
        public static OnMonsterDead onMonsterDead = null;

        // X、Y坐标转成唯一ID
        public static int MapPos(int map_x, int map_y)
        {
            return map_y * map_width + map_x;
        }

        public static void MapXY(int pos, out int map_x, out int map_y)
        {
            map_y = pos / map_width;
            map_x = pos % map_width;
        }

        // 画边界
        static void DrawBorder()
        {
            // 上边
            for (int i=0; i< map_width+2; ++i)
            {
                buffer[1,i] = '#';
            }

            // 左边
            for (int i = 1; i < map_height+2; ++i)
            {
                buffer[i, 0] = '#';
            }
            
            // 下边
            for (int i = 0; i < map_width+2; ++i)
            {
                buffer[map_height+2, i] = '#';
            }
            // 右边
            for (int i = 1; i < map_height+2; ++i)
            {
                buffer[i, map_width+1] = '#';
            }
        }

        // 画NPC和其他东西
        static void DrawOther()
        {
            color_buffer[player.y + 2, player.x + 1] = ConsoleColor.Blue;
            buffer[player.y+2, player.x+1] = 'o';

            foreach (var pair in monsters)
            {
                char ch;
                if (pair.Value.level <= 9)
                {
                    ch = pair.Value.level.ToString()[0];
                }
                else
                {
                    ch = '!';
                }
                var monster = pair.Value;
                color_buffer[monster.y + 2, monster.x + 1] = ConsoleColor.Red;
                buffer[monster.y+2, monster.x+1] = ch;
            }
            foreach (var pair in moneys)
            {
                var money = pair.Value;
                color_buffer[money.y + 2, money.x + 1] = ConsoleColor.Yellow;
                buffer[money.y+2, money.x+1] = '$';
            }
            foreach (var pair in npcs)
            {
                var npc = pair.Value;
                color_buffer[npc.y + 2, npc.x + 1] = ConsoleColor.Green;
                buffer[npc.y+2, npc.x+1] = 'N';
            }
        }

        // 画第一行信息
        static void DrawInfo()
        {
            string s = string.Format("HP:{0}  LEVEL:{1}  ATK:{2}  $:{3}", player.hp, player.level, player.attack, player.money);
            for (int i=0; i<s.Length; ++i)
            {
                buffer[0, i] = s[i];
            }
        }

        // 画最下面一行的信息
        static void DrawBelowInfo()
        {
            for (int i=0;  i<below_text.Length; ++i)
            {
                buffer[map_height+3, i] = below_text[i];
            }
            for (int i=0;  i<level_target.Length; ++i)
            {
                buffer[map_height+4, i] = level_target[i];
            }
        }

        static void DrawAll()
        {
            DrawBorder();
            DrawOther();
            DrawInfo();
            DrawBelowInfo();
        }

        public static void GameOver()
        {
            game_over = true;
            victory = false;
        }

        public static void OnStageClear()
        {
            game_over = true;
            victory = true;
        }

        // 返回值： 是否需要刷新
        static bool MovePlayer()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            int next_x = player.x;
            int next_y = player.y;
            if (key.Key == ConsoleKey.UpArrow)
            {
                next_y -= 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                next_y += 1;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                next_x -= 1;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                next_x += 1;
            }
            else
            {
                return true;
            }

            if (next_x<0 || next_x>=map_width || next_y<0 || next_y>=map_height)
            {
                return true;
            }
            int next_pos = MapPos(next_x, next_y);

            if (moneys.ContainsKey(next_pos))
            {
                Money money = moneys[next_pos];
                below_text = "捡到 " + money.money + " 颗金币。";
                player.money += money.money;
                moneys.Remove(next_pos);
            }
            else if (monsters.ContainsKey(next_pos))
            {
                Monster monster = monsters[next_pos];
                string info;
                int result = player.Attack(monster, out info);
                below_text = info;
                if (result == -1)
                {
                    GameOver();
                    return true;
                }
                else if (result == 1)
                {
                    bool ret = onMonsterDead(monster);
                    if (ret)
                    {
                        below_text += "怪物死亡。";
                        player.AddExp(monster.level);
                        monsters.Remove(next_pos);
                    }
                }

            }
            else if (npcs.ContainsKey(next_pos))
            {
                NPC npc = npcs[next_pos];
                string s;
                if (npc.OnTalk(player, out s))
                {
                    npcs.Remove(next_pos);
                    object o = npc.AfterDisappear();
                    if (o is Monster)
                    {
                        Monster m = o as Monster;
                        monsters[MapPos(m.x, m.y)] = m;
                    }
                }
                below_text = s;
            }
            else
            {
                int a, b;
                MapXY(next_pos, out a, out b);
                player.x = a;
                player.y = b;
            }

            return true;
        }

        public static int RandPos()
        {
            while (true)
            {
                int map_pos = random.Next(0, map_width * map_height);
                int x, y;
                MapXY(map_pos, out x, out y);
                if (buffer[y, x] == ' ')
                {
                    return map_pos;
                }
            }
        }

        static bool IsPosEmpty(int pos)
        {
            if (pos < 0 || pos >= map_width * map_height)
            {
                return false;
            }
            if (monsters.ContainsKey(pos))
            {
                return false;
            }
            if (moneys.ContainsKey(pos))
            {
                return false;
            }
            if (npcs.ContainsKey(pos))
            {
                return false;
            }
            if (MapPos(player.x, player.y) == pos)
            {
                return false;
            }
            return true;
        }

        public static Monster AddMonster(int x, int y, int _level, int money = 0)
        {
            if (!IsPosEmpty(MapPos(x,y)))
            {
                Debug.WriteLine("AddMonster错误");
                return null;
            }
            Monster m = new Monster(_level);
            m.SetPos(x, y);
            monsters[MapPos(x,y)] = m;
            m.drop_money = money;
            return m;
        }


        static void ClearStage()
        {
            // 公用变量每关重置
            game_over = false;
            victory = false;
            player.Reset();
            player.x = 5;
            player.y = 5;

            level_target = "";
            below_text = "";

        }

        static bool StageLogic()
        {
            // 初始化图像
            canvas.ClearBuffer();
            //Console.WriteLine();
            DrawAll();
            canvas.Refresh();

            while (!game_over)
            {
                int old_level = player.level;
                bool need_refresh_move = MovePlayer();
                if (player.level > old_level)
                {
                    below_text += "升了" + (player.level - old_level) + "级";
                }

                canvas.ClearBuffer();
                //Console.WriteLine();
                DrawAll();
                canvas.Refresh();
            }

            level_target = "";
            bool ret;
            if (victory)
            {
                below_text += "\n胜利！恭喜你。";
                ret = true;
            }
            else
            {
                below_text += "\n游戏结束。";
                ret = false;
            }

            canvas.ClearBuffer();
            DrawAll();
            canvas.Refresh();

            return ret;
        }


        public static void AddLevel(InitStage init_func)
        {
            stages.Add(init_func);
        }

        static void Main(string[] args)
        {
            CustomLevels.AddAllLevels();
            canvas = new ConsoleCanvas(width, height);
            buffer = canvas.GetBuffer();
            color_buffer = canvas.GetColorBuffer();

            player = new Player();

            int level = 1;
            if (args.Length > 1)
            {
                level = int.Parse(args[1]);
            }
            bool game_ok = true;

            while (game_ok)
            {
                ClearStage();
                if (level-1 < stages.Count)
                {
                    stages[level-1]();
                    game_ok = StageLogic();
                }
                else
                {
                    game_ok = false;
                    below_text += "已完成全部关卡。";
                }

                if (game_ok)
                {
                    below_text += "按回车键进入下一关";
                    level += 1;
                }
                else
                {
                    below_text += "按回车键结束游戏";
                }

                canvas.ClearBuffer();
                DrawAll();
                canvas.Refresh();

                Console.ReadLine();
            }
        }
    }
}
