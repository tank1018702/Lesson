using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    public class Building
    {
        public string name;
        public int[] south_west = { 0, 0 };
        public int width_we;
        public int width_sn;

        public Building(int[] _south_west, int _width_we, int _width_sn)
        {
            south_west[0] = _south_west[0];
            south_west[1] = _south_west[1];
            width_we = _width_we;
            width_sn = _width_sn;
        }

        public int[] GetSouthWest()
        {
            int[] ret = new int[] { 0, 0 };
            south_west.CopyTo(ret, 0);
            return ret;
        }

        public int[] GetNorthWest()
        {
            int[] ret = new int[] { south_west[0], south_west[1]+width_sn };
            return ret;
        }

        public int[] GetSouthEast()
        {
            int[] ret = new int[] { south_west[0]+width_we, south_west[1] };
            return ret;
        }

        public int[] GetNorthEast()
        {
            int[] ret = new int[] { south_west[0] + width_we, south_west[1] + width_sn };
            return ret;
        }

        public int GetSquare()
        {
            return width_sn * width_we;
        }
    }

    public class HighBuilding : Building
    {
        public int height = 0;

        public HighBuilding(int[] _south_west, int _width_we, int _width_sn, int _height)
            : base(_south_west, _width_we, _width_sn)
        {
            height = _height;
        }

        public bool CanPlanePass(int h)
        {
            return height < h;
        }
    }
}
