using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushToWin
{
    public class Map
    {
        int height;
        int width;
        string empty = "  ";

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        string[,] Buffer;

        string[,] BackGroundBuffer;

        ConsoleColor[,] ColorBuffer;

        public Map(int h,int w,string _empty)
        {
            height = h;
            width = w;
            empty = _empty;
            Buffer = new string[height, width];
            BackGroundBuffer = new string[height, width];
            ColorBuffer = new ConsoleColor[height, width];
            Console.CursorVisible = false;
        }
        
        void CopyBuffer(string [,] source,string [,] replica)
        {

        }
    }
}
