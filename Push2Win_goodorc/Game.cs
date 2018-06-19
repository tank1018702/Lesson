using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Push2Win
{
    public class Game
    {
        const int width = 100;
        const int height = 28;

        public const int map_width = 18;
        public const int map_height = 18;
        public const int offsetX = 1;
        public const int offsetY = 1;

        static ConsoleCanvas canvas = null;
        static char[,] buffer = null;
        static ConsoleColor[,] color_buffer = null;

        public static Random random = new Random();

        static List<Box> allBoxes = new List<Box>();

        // X、Y坐标变换
        static bool _ChangeXY(ref int x, ref int y, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (x == 0) { return false; }
                    x -= 1;
                    break;
                case Direction.Right:
                    if (x == map_width - 1) { return false; }
                    x += 1;
                    break;
                case Direction.Up:
                    if (y == 0) { return false; }
                    y -= 1;
                    break;
                case Direction.Down:
                    if (y == map_height - 1) { return false; }
                    y += 1;
                    break;
            }
            return true;
        }

        static bool _OverBorder(int x, int y, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (x == 0) { return true; }
                    break;
                case Direction.Right:
                    if (x == map_width - 1) { return true; }
                    break;
                case Direction.Up:
                    if (y == 0) { return true; }
                    break;
                case Direction.Down:
                    if (y == map_height - 1) { return true; }
                    break;
            }
            return false;
        }

        // 画边界
        static void DrawBorder()
        {
            // 上边
            for (int i=0; i< map_width+2; ++i)
            {
                buffer[offsetY-1,i+offsetX-1] = '#';
            }

            // 左边
            for (int i = 0; i < map_height+2; ++i)
            {
                buffer[i+offsetY-1, offsetX-1] = '#';
            }
            
            // 下边
            for (int i = 0; i < map_width+2; ++i)
            {
                buffer[map_height+offsetY, i+offsetX-1] = '#';
            }
            // 右边
            for (int i = 1; i < map_height+2; ++i)
            {
                buffer[i+offsetY-1, map_width+offsetX] = '#';
            }
        }

        // 画Box
        static void DrawBoxes()
        {
            foreach (var box in allBoxes)
            {
                buffer[box.y+offsetY, box.x+offsetX] = box.content.name[0];
                color_buffer[box.y + offsetY, box.x + offsetX] = box.content.color;
            }
        }

        static void DrawAll()
        {
            DrawBorder();
            DrawBoxes();
        }

        static List<Box> FindAllPlayers()
        {
            var players = new List<Box>();
            foreach (var box in allBoxes)
            {
                if (box.HasFlag(BehaviourType.You))
                {
                    players.Add(box);
                }
            }
            return players;
        }

        static void SortPlayers(List<Box> players, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    players.Sort( (a, b) => a.x.CompareTo(b.x) );
                    break;
                case Direction.Right:
                    players.Sort( (a, b) => b.x.CompareTo(a.x) );
                    break;
                case Direction.Up:
                    players.Sort( (a, b) => a.y.CompareTo(b.y) );
                    break;
                case Direction.Down:
                    players.Sort( (a, b) => b.y.CompareTo(a.y) );
                    break;
            }
            return;
        }

        static List<Box> GetBoxesByPos(int x, int y)
        {
            List<Box> ret = new List<Box>();
            foreach (var box in allBoxes)
            {
                if (box.x == x && box.y == y)
                {
                    ret.Add(box);
                }
            }
            return ret;
        }


        static bool CanBePushed(int x, int y, Direction dir, List<Box> allMoves)
        {
            var boxes = GetBoxesByPos(x, y);
            if (boxes.Count == 0)
            {
                return true;
            }

            bool needRecur = false;
            foreach (var box in boxes)
            {
                if (!box.HasFlag(BehaviourType.Push | BehaviourType.Stop))
                {
                    // 可以重叠
                    continue;
                }
                if (_OverBorder(x, y, dir))
                {
                    return false;
                }
                if (box.HasFlag(BehaviourType.Stop))
                {
                    return false;
                }
                if (box.HasFlag(BehaviourType.Push))
                {
                    allMoves.Add(box);
                    needRecur = true;
                }
            }

            if (needRecur)
            {
                if (!_ChangeXY(ref x, ref y, dir))
                {
                    return false;
                }
                return CanBePushed(x, y, dir, allMoves);
            }
            return true;

        }


        static bool CanMovePlayer(int x, int y, Direction dir, List<Box> allMoves)
        {
            if (!_ChangeXY(ref x, ref y, dir))
            {
                return false;
            }
            if (!CanBePushed(x, y, dir, allMoves))
            {
                return false;
            }
            return true;
        }


        // 返回值： 是否需要刷新
        static int Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Backspace)
            {
                return -1;
            }

            List<Box> players = FindAllPlayers();
            if (players.Count == 0)
            {
                return 0;
            }
            Direction dir;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        dir = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        dir = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        dir = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        dir = Direction.Right;
                    }
                    break;
                default:
                    return 0;
            }

            Dictionary<Box, bool> container = new Dictionary<Box, bool>();
            foreach (var player in players)
            {
                List<Box> allMoves = new List<Box>();
                if (!CanMovePlayer(player.x, player.y, dir, allMoves))
                {
                    continue;
                }
                container[player] = true;
                foreach(var box in allMoves)
                {
                    container[box] = true;
                }
            }

            if (container.Count == 0)
            {
                return 0;
            }

            foreach (var box in container.Keys)
            {
                _ChangeXY(ref box.x, ref box.y, dir);
            }

            return 1;
        }


        delegate void _SearchAndChangeRules(Box _is, Direction dir, Direction dir2);
        static void RefreshRules()
        {
            Rule.Reset();
            List<Box> allIs = new List<Box>();
            foreach (var box in allBoxes)
            {
                if (box.content.type == ContentType.Is)
                {
                    allIs.Add(box);
                }
            }

            _SearchAndChangeRules func = (Box _is, Direction dir1, Direction dir2) =>
            {
                int x = _is.x; int y = _is.y;

                if (_ChangeXY(ref x, ref y, dir1))
                {
                    var boxes = GetBoxesByPos(x, y);
                    if (boxes.Count == 1 && boxes[0].content.type == ContentType.Subject)
                    {
                        x = _is.x; y = _is.y;
                        if (_ChangeXY(ref x, ref y, dir2))
                        {
                            var boxes2 = GetBoxesByPos(x, y);
                            if (boxes2.Count == 1 && boxes2[0].content.type == ContentType.Behaviour)
                            {
                                // 找到主体代表的Content附加此行为
                                int subjectIndex = boxes[0].content.subjectIndex;
                                Rule.contents[subjectIndex].behaviour |= boxes2[0].content.effect;
                            }
                        }
                    }
                }
            };

            foreach (var _is in allIs)
            {
                func(_is, Direction.Up, Direction.Down);
                func(_is, Direction.Left, Direction.Right);
            }
        }

        static List<string> ReadMapFile(string path)
        {
            List<string> lines = new List<string>();
            StreamReader reader = File.OpenText(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                lines.Add(line);
            }
            return lines;
        }

        delegate void _AddBox(int x, int y, int index);
        static List<Box> TranslateMap(List<string> lines)
        {
            List<Box> boxes = new List<Box>();
            _AddBox addBox = (int x, int y, int index) =>
            {
                Box box = new Box(x, y);
                box.content = Rule.contents[index];
                boxes.Add(box);
            };
            lines.RemoveAt(0);
            for (int i=0; i<map_height; i++)
            {
                int k = 0;
                for (int j = 0; j < map_width*2 && j<lines[i].Length; j += 2)
                {
                    char k1 = lines[i][k];
                    char k2 = lines[i][k + 1];
                    if (k1 == '■') { addBox(j / 2, i, 0); }
                    else if (k1 == '●') { addBox(j/2, i, 1); }
                    else if (k1 == '♀') { addBox(j/2, i, 2); }
                    else if (k1 == '★') { addBox(j/2, i, 3); }
                    else if (k1 == '*' && k2=='*') { addBox(j/2, i, 4); }
                    else if (k1 == '《') { addBox(j/2, i, 5); }
                    else if (k1 == '》') { addBox(j/2, i, 6); }
                    else if (k1 == '♂') { addBox(j/2, i, 7); }

                    else if (k1 == '墙') { addBox(j / 2, i, 8); }
                    else if (k1 == '球') { addBox(j / 2, i, 9); }
                    else if (k1 == '女') { addBox(j / 2, i, 10); }
                    else if (k1 == '星') { addBox(j / 2, i, 11); }
                    else if (k1 == '草') { addBox(j / 2, i, 12); }
                    else if (k1 == '水') { addBox(j / 2, i, 13); }
                    else if (k1 == '火') { addBox(j / 2, i, 14); }
                    else if (k1 == '男') { addBox(j / 2, i, 15); }

                    else if (k1 == '赢') { addBox(j/2, i, 16); }
                    else if (k1 == '你') { addBox(j/2, i, 17); }
                    else if (k1 == '停') { addBox(j/2, i, 18); }
                    else if (k1 == '推') { addBox(j/2, i, 19); }
                    else if (k1 == '死') { addBox(j/2, i, 20); }
                    else if (k1 == 'A' && k2=='I') { addBox(j/2, i, 21); }
                    else if (k1 == '沉') { addBox(j/2, i, 22); }
                    else if (k1 == 'i' && k2=='s') { addBox(j/2, i, 23); }

                    if (k1 < 127) { k += 2; }
                    else { k++; }
                }
            }
            return boxes;
        }


        static void StageLogic()
        {
            // test~~
            var lines = ReadMapFile("../../level0.txt");
            var boxes = TranslateMap(lines);
            allBoxes.AddRange(boxes);
            RefreshRules();

            // 初始化图像
            canvas.ClearBuffer_DoubleBuffer();
            DrawAll();
            canvas.Refresh_DoubleBuffer();

            int step = 0;
            Dictionary<int, List<Box>> history = new Dictionary<int, List<Box>>();

            while (true)
            {
                int run = Input();
                if (run == 1)
                {
                    history[step] = new List<Box>();
                    foreach (var box in allBoxes)
                    {
                        history[step].Add(box.Copy());
                    }
                    step++;
                }
                else if (run == -1)
                {
                    if (step >= 1)
                    {
                        step--;
                        allBoxes.Clear();
                        allBoxes.AddRange(history[step]);
                    }
                }

                if (run != 0)
                {
                    canvas.ClearBuffer_DoubleBuffer();
                    DrawAll();
                    canvas.Refresh_DoubleBuffer();
                    RefreshRules();
                }
            }
            canvas.ClearBuffer_DoubleBuffer();
            DrawAll();
            canvas.Refresh_DoubleBuffer();

            return;
        }


        static void Main(string[] args)
        {
            canvas = new ConsoleCanvas(width, height);
            buffer = canvas.GetBuffer();
            color_buffer = canvas.GetColorBuffer();
            Rule.Init();

            int level = 1;
            if (args.Length > 1)
            {
                level = int.Parse(args[1]);
            }
            bool game_ok = true;

            while (game_ok)
            {
                // 关卡
                StageLogic();

                canvas.ClearBuffer_DoubleBuffer();
                DrawAll();
                canvas.Refresh_DoubleBuffer();

                Console.ReadLine();
            }
        }
    }
}
