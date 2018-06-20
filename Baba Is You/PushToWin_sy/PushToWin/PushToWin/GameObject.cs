using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    public class GameObject : ICloneable
    {
        //在地图上的坐标
        public int x;
     
        public int y;

        

        public LogicType logic_type;
        public ConsoleColor color;
        public ObjectType object_type;

        //显示默认两个空格,因为汉字占用两个字节。
        public string Icon = "  ";
        public string contect_Icon;

        public LogicType effect_logic;

        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;
            logic_type = LogicType.Null;
        }

        public bool HasLogic(LogicType logic)
        {
            return (logic_type & logic) != 0;
        }
        
        //除String外所有字段都是值类型,因此可以直接使用浅表拷贝
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
        //其他逻辑
        Win=1<<1,
        You = 1 << 2,
        Stop = 1 << 3,
        Push = 1 << 4,
        Kill = 1 << 5,
        Sink = 1 << 6,
        AI = 1 << 7,
        //组成规则的逻辑字符,除了推不能附加其他任何规则,此处逻辑表示可以作为主体,只有名词能作为主体
        Subject = 1 << 7,
        //逻辑字符,表示可以作为客体,名词和动词都能作为客体
        Object =1<<8
    }

    public enum ObjectType
    {
        eneity,
        verb,
        noun
    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public struct Pos
    {
        int x;
        int y;
        public Pos(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }

}
