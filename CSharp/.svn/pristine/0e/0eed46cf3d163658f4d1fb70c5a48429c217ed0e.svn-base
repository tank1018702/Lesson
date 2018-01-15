using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace TimerEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimer1;
            //timer.Elapsed += OnTimer2;
            timer.Start();

            Console.ReadKey();
        }

        static int timer_counter = 0;
        static void OnTimer1(object o, ElapsedEventArgs args)
        {
            Console.WriteLine("OnTimer1 " + o + "," + args);
            timer_counter += 1;
            if (timer_counter == 3)
            {
                Timer timer = o as Timer;
                timer.Stop();
                Console.WriteLine("---- Timer stopped. ---- ");
            }
        }

        static void OnTimer2(object o, ElapsedEventArgs args)
        {
            Console.WriteLine("OnTimer2 " + o + "," + args);
        }
    }
}
