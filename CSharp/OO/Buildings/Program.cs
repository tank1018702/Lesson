using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Building[] city = new Building[100];

            for (int i=0; i<10; ++i)
            {
                int[] pos = new int[] { i * 100, i * 100 };
                Building building = new Building(pos, rand.Next(3,20), rand.Next(5,25));
                building.name = "B" + i;
                city[i] = building;
            }

            int[] pos2 = new int[] { 0, 88 };
            city[20] = new HighBuilding(pos2, 20, 30, 100);
            city[20].name = "高建筑A";

            // 测试这些建筑
            foreach (Building building in city)
            {
                if (building == null)
                {
                    continue;
                }
                Console.WriteLine("Name:{0}   坐标:{1}_{2} {3}_{4} {5}_{6} {7}_{8}    面积: {9}"
                    , building.name
                    , building.GetSouthWest()[0], building.GetSouthWest()[1]
                    , building.GetNorthWest()[0], building.GetNorthWest()[1]
                    , building.GetNorthEast()[0], building.GetNorthEast()[1]
                    , building.GetSouthEast()[0], building.GetSouthEast()[1]
                    , building.GetSquare());

                if (building is HighBuilding)
                {
                    HighBuilding hi = building as HighBuilding;
                    Console.WriteLine("\t 高度:" + hi.height + "  高度100的飞机能否通过:" + hi.CanPlanePass(100));
                }
            }

            Console.ReadKey();
        }
    }
}
