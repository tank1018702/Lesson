using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    public class GameObject:ICloneable
    {
        //在地图上的坐标
        public int x;
        public int y;

        public LogicType logic_type;
        public ConsoleColor color;

        //显示默认两个空格,因为汉字占用两个字节。
        string Icon = "  ";

        public GameObject(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            logic_type = LogicType.Null;
        }

        public bool HasLogic(LogicType logic)
        {
            return (logic_type & logic) != 0;
        }
        
        public object Clone()
        {
            return MemberwiseClone() as GameObject;
        }
    }


    [Flags]
    public enum LogicType
    {
        //没有附加任何逻辑,只是显示在游戏界面里
        Null = 1,
        You = 1 << 1,
        Stop = 1 << 2,
        Push = 1 << 3,
        Kill = 1 << 4,
        Sink = 1 << 5,
        AI = 1 << 6,
        //组成规则的逻辑字符,除了推不能附加其他任何规则
        Subject = 1 << 7

    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
