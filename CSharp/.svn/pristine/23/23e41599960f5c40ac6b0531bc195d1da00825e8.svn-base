using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent
{
    class GameNode
    {
        // 父节点
        public GameNode parent = null;
        // 子节点（多个）
        public List<GameNode> children = new List<GameNode>();

        public int id;

        public GameNode(int _id)
        {
            id = _id;
        }

        public void AddChild(GameNode node)
        {
            children.Add(node);
            node.parent = this;
        }

        public void RemoveChildAt(int i)
        {
            children.RemoveAt(i);
        }
    }

    class Program
    {
        static GameNode root = null;
        static void InitNodes()
        {
            root = new GameNode(0);
            for (int i=0; i<8; ++i)
            {
                root.children.Add(new GameNode(i+1));
            }

            GameNode node1 = root.children[1];
            for (int i=0; i<3; ++i)
            {
                node1.AddChild(new GameNode(11+i));
            }

            GameNode node2 = root.children[2];
            for (int i=0; i<3; ++i)
            {
                node2.AddChild(new GameNode(21+i));
            }

            GameNode node3 = node1.children[2];
            for (int i=0; i<1; ++i)
            {
                node3.AddChild(new GameNode(101+i));
            }

        }

        static void Main(string[] args)
        {
            InitNodes();
            Console.ReadKey();
        }
    }
}
