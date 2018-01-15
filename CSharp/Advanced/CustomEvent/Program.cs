using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace CustomEvent
{
    public delegate void MessageHandler(string messageText);

    public class Connection
    {
        public event MessageHandler MessageArrived;
        private Timer pollTimer;

        public Connection()
        {
            pollTimer = new Timer(1000);
            pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
        }

        public void Connect() { pollTimer.Start(); }

        public void Disconnect() { pollTimer.Stop(); }

        private static Random random = new Random();

        private void CheckForMessage(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            if (MessageArrived != null)
            {
                MessageArrived("Hello Mum!");
            }
        }
    }

    public class Display
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine("Message arrived: {0}", message);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Connection myConnection = new Connection();
            Display myDisplay = new Display();
            myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
            myConnection.Connect();
            Console.ReadKey();
        }
    }
}
