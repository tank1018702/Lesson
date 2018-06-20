using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取文件
            List<string> file = FileManager.ReadMapFile("../../TEST.txt");
            Map.TestDraw(GameLogic.GameObjectInit(file));


            //生成示例化物体
            //生成逻辑
            //导入地图
            Console.ReadKey();
        }
    }

    public class GameLogic
    {
        public const int map_width = 18;
        public const int map_height = 18;

        public static List<GameObject> GameObjectInit(List<string> file)
        {
            var object_list = new List<GameObject>();
            for (int i = 0; i < file.Count; i++)
            {
                char[] line = file[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    GameObject obj = new GameObject(j, i);
                    GameObjectAssign(obj, line[j]);
                    object_list.Add(obj);
                }

            }
            return object_list;
        }

        static void GameObjectAssign(GameObject obj, char tag)
        {
            // "■", "●", "♀", "★", "**", "∷", "☀", "♂" ,"  "
            // "墙", "球", "女", "星", "草", "水", "火", "男" ,"空"
            //"赢", "你", "停", "推", "死", "AI", "沉" ,"is"
            int n;
            //实体
            if (tag == '■')
            {
                n = 0;
            }
            else if (tag == '●')
            {
                n = 1;
            }
            else if (tag == '♀')
            {
                n = 2;
            }
            else if (tag == '★')
            {
                n = 3;
            }
            else if (tag == '*')
            {
                n = 4;
            }
            else if (tag == '∷')
            {
                n = 5;
            }
            else if (tag == '☀')
            {
                n = 6;
            }
            else if (tag == '♂')
            {
                n = 7;
            }
            else if (tag == ' ')
            {
                n = 8;
            }
            //名词
            else if (tag == '墙')
            {
                n = 10;
            }
            else if (tag == '球')
            {
                n = 11;
            }
            else if (tag == '女')
            {
                n = 12;
            }
            else if (tag == '星')
            {
                n = 13;
            }
            else if (tag == '草')
            {
                n = 14;
            }
            else if (tag == '水')
            {
                n = 15;
            }
            else if (tag == '火')
            {
                n = 16;
            }
            else if (tag == '男')
            {
                n = 17;
            }
            else if (tag == '空')
            {
                n = 18;
            }
            //动词
            else if (tag == '赢')
            {
                n = 20;
                obj.effect_logic = LogicType.Win;
            }
            else if (tag == '你')
            {
                n = 21;
                obj.effect_logic = LogicType.You;
            }
            else if (tag == '停')
            {
                n = 22;
                obj.effect_logic = LogicType.Stop;
            }
            else if (tag == '推')
            {
                n = 23;
                obj.effect_logic = LogicType.Push;
            }
            else if (tag == '死')
            {
                n = 24;
                obj.effect_logic = LogicType.Kill;
            }
            else if (tag == '智')
            {
                n = 25;
                obj.effect_logic = LogicType.AI;
            }
            else if (tag == '沉')
            {
                n = 26;
                obj.effect_logic = LogicType.Sink;
            }
            else if (tag == '是')
            {
                n = 27;
            }
            else
            {
                n = 30;
            }

            if (n < 10)
            {
                obj.Icon = Data.GameObjectIcon[n];
                obj.color = Data.GameObjectColors[n];
                obj.object_type = ObjectType.eneity;
            }
            else if (n < 20)
            {
                obj.Icon = Data.GameObjectChar[n - 10];
                obj.color = Data.GameObjectColors[n - 10];
                obj.contect_Icon = Data.GameObjectIcon[n - 10];
                obj.logic_type = LogicType.Null | LogicType.Push;
                obj.object_type = ObjectType.noun;
            }
            else if (n < 30)
            {
                obj.Icon = Data.behaviourNames[n - 20];
                obj.color = Data.behaviourColors[n - 20];
                obj.logic_type = LogicType.Null | LogicType.Push;
                obj.object_type = ObjectType.verb;

            }
            else
            {
                Console.WriteLine("地图读取异常字符");
            }
        }

        public static void LogicInit(List<GameObject> objs)
        {
            foreach (var obj in objs)
            {
                if (obj.object_type == ObjectType.eneity)
                {
                    obj.logic_type = LogicType.Null;
                }
            }
        }

        public static void SetLogic(List<GameObject> objs)
        {
            List<GameObject> eneity_list = new List<GameObject>();
            List<GameObject> noun_list = new List<GameObject>();
            List<GameObject> verb_list = new List<GameObject>();
            Dictionary<Pos, GameObject> dic = new Dictionary<Pos, GameObject>();
            foreach (var obj in objs)
            {
                if (obj.object_type == ObjectType.eneity)
                {
                    eneity_list.Add(obj);
                }
                else if (obj.object_type == ObjectType.noun)
                {
                    noun_list.Add(obj);
                }
                else
                {
                    verb_list.Add(obj);
                }
                Pos p = new Pos(obj.x, obj.y);
                dic.Add(p, obj);
            }
            //先名词
            foreach (var n in noun_list)
            {
                //下方
                GameObject temp = dic[new Pos(n.x, n.y + 1)];
                string icon_change = n.contect_Icon;
                if (temp.Icon == "is")
                {
                    temp = dic[new Pos(n.x, n.y + 2)];
                    if (temp.object_type == ObjectType.noun)
                    {
                        icon_change = temp.contect_Icon;
                    }
                }
                //右方
                temp = dic[new Pos(n.x + 1, n.y)];
                if (temp.Icon == "is")
                {
                    temp = dic[new Pos(n.x = 2, n.y)];
                    if (temp.object_type == ObjectType.noun)
                    {
                        icon_change = temp.contect_Icon;
                    }
                }
                foreach (var e in eneity_list)
                {
                    if (e.Icon == n.contect_Icon)
                    {
                        e.Icon = icon_change;
                    }
                }
            }
            //动词
            foreach (var n in noun_list)
            {
                GameObject temp = dic[new Pos(n.x, n.y + 1)];
                LogicType type = LogicType.Null;
                if (temp.Icon == "is")
                {
                    temp = dic[new Pos(n.x, n.y + 2)];
                    if (temp.object_type == ObjectType.verb)
                    {
                        type = LogicType.Null | temp.logic_type;
                    }
                }
                temp = dic[new Pos(n.x + 1, n.y)];
                if (temp.Icon == "is")
                {
                    temp = dic[new Pos(n.x + 2, n.y)];
                    if (temp.object_type == ObjectType.verb)
                    {
                        type = LogicType.Null | temp.logic_type;
                    }
                }
                foreach (var e in eneity_list)
                {
                    if (e.Icon == n.contect_Icon)
                    {
                        e.logic_type = type;
                    }
                }
            }
        }

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
    }

    public class FileManager
    {
        public static List<string> ReadMapFile(string path)
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


    }
}
