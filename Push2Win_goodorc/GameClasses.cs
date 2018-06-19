using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 内部规则：
// 1、地图上看到的方块，都是Box
// 2、每一个Box的背后，都有一个Content，Content是逻辑概念，比如：不可推动的石块，可以推动的主语，可以推动的行为等等
// 3、Content是事先定义的，数量也是事先确定的。但是实体类物体（"■", "●", "♀", "★", "**", "■", "■", "♂"等）的参数可以被修改，这就形成了这个游戏最有特色的规则

// 推动和重叠的规则
// 1、不具有Push和Stop的物体，可以任意重叠
// 2、一旦物体被标记为可推动（Push）或者停止（Stop）其中之一或二者兼有，则它不可重叠
// 3、物体全部重叠在一起的情况主要发生在，“你”有多个的时候，通过操作大量重叠在一起。如果这时是“停止”的，则不会增加重叠

namespace Push2Win
{
    // 地图上的物体
    public class Box
    {
        public int x;
        public int y;

        // 每个Box的背后，都关联了一种Content
        public Content content;

        public Box(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool HasFlag(BehaviourType mask)
        {
            return (content.behaviour & mask) != 0;
        }

        public Box Copy()
        {
            var b = new Box(x, y);
            b.content = content;
            return b;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    public enum ContentType
    {
        Obj,            // 实体方块
        Subject,        // 逻辑主语
        Behaviour,      // 逻辑行为
        Is,
    }

    [Flags]     // 启用位运算功能
    public enum BehaviourType
    {
        Win = 1,
        You = 1 << 1,
        Stop = 1 << 2,
        Push = 1 << 3,
        Die = 1 << 4,
        AI = 1 << 5,
        Sink = 1 << 6,
    }

    // Content是有限多的，被Rule所管理
    public class Content
    {
        public ContentType type;

        public string name;
        public ConsoleColor color;

        // 行为。实体方块的行为可能被改变，逻辑方块的行为是固定的
        public BehaviourType behaviour = 0;

        // 逻辑方块关联的Content下标
        public int subjectIndex = -1;

        // 逻辑方块关联的行为，即产生的效果
        public BehaviourType effect;
    }
    
    // 游戏规则，单例对象
    public class Rule
    {
        public static List<Content> contents;
        
        public static void Init()
        {
            contents = new List<Content>();
            // 所有实体方块的Content
            for (int i=0; i<DesignData.subjectChars.Length; i++)
            {
                Content c = new Content();
                c.type = ContentType.Obj;
                c.name = DesignData.subjectChars[i];
                c.color = DesignData.subjectColors[i];
                contents.Add(c);
            }

            // 逻辑Content，主体类型
            for (int i = 0; i < DesignData.subjectNames.Length; i++)
            {
                Content c = new Content();
                c.type = ContentType.Subject;
                c.name = DesignData.subjectNames[i];
                c.color = DesignData.subjectColors[i];
                c.behaviour = BehaviourType.Push;
                c.subjectIndex = i;
                contents.Add(c);
            }

            // 逻辑Content，行为类型
            for (int i = 0; i < DesignData.behaviourNames.Length; i++)
            {
                Content c = new Content();
                c.type = ContentType.Behaviour;
                c.name = DesignData.behaviourNames[i];
                c.color = DesignData.behaviourColors[i];
                c.behaviour = BehaviourType.Push;
                c.effect = (BehaviourType)(1<<i);
                contents.Add(c);
            }

            Content c_is = new Content();
            c_is.type = ContentType.Is;
            c_is.name = DesignData.nameIs;
            c_is.color = DesignData.colorIs;
            c_is.behaviour = BehaviourType.Push;
            contents.Add(c_is);

            Reset();
        }

        public static void Reset()
        {
            for (int i = 0; i < DesignData.subjectChars.Length; i++)
            {
                var c = contents[i];
                c.behaviour = 0;
            }
            // 逻辑主体的behaviour不会变化，不需要Reset
            // 逻辑行为的behaviour也不会变化
        }
    }

    public static class DesignData
    {
        public static string[] subjectChars = { "■", "●", "♀", "★", "**", "■", "■", "♂" };       // 0~7
        public static string[] subjectNames = { "墙", "球", "女", "星", "草", "水", "火", "男" };       // 0~7, +8
        public static ConsoleColor[] subjectColors = { ConsoleColor.DarkYellow, ConsoleColor.DarkRed, ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.DarkRed, ConsoleColor.Gray };

        public static string[] behaviourNames = { "赢", "你", "停", "推", "死", "AI", "沉" };    // 16, 17~23
        public static ConsoleColor[] behaviourColors = { ConsoleColor.Yellow, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkGray, ConsoleColor.White, ConsoleColor.Gray };

        public static string nameIs = "is";
        public static ConsoleColor colorIs = ConsoleColor.White;

    }
}
