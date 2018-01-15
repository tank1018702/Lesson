using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Arm arm = new Arm();
            Leg leg = new Leg();
            robot.AddComponent(arm);
            robot.AddComponent(leg);

            Arm arm2 = robot.GetComponent<Arm>();
            arm2.Update();

            robot.Update();
            Console.ReadKey();

            robot.RemoveComponent("Leg");
            robot.Update();
            Console.ReadKey();
        }
    }
}
