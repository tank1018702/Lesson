using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Leg : ComponentBase
    {
        public override void Update()
        {
            Console.WriteLine("Kick");
        }
    }
}
