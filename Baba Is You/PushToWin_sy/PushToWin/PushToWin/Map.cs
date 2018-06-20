using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    public class Map
    {
        public int _height;
        public int _width;
        string empty = "  ";

        string[,] Buffer;

        string[,] BackGroundBuffer;

        ConsoleColor[,] ColorBuffer;

        public static List<GameObject> all_object = new List<GameObject>();


        public Map(int h, int w, string _empty)
        {
            _height = h;
            _width = w;
            empty = _empty;
            Buffer = new string[_height, _width];
            BackGroundBuffer = new string[_height, _width];
            ColorBuffer = new ConsoleColor[_height, _width];
            Console.CursorVisible = false;
        }

        void CopyBuffer(string[,] source, string[,] replica)
        {

        }
         




        public static void TestDraw(List<GameObject> list)
        {
            foreach (var i in list)
            {

                Console.SetCursorPosition((i.x+1) * 2, i.y+1);
                Console.Write(i.Icon);
            }
        }
    }
}
