using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Arm : ComponentBase
    {
        public override void Update()
        {
            Console.WriteLine("Swing");
        }
    }
}
