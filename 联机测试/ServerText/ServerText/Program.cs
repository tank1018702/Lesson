using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerText
{
    class Program
    {
        private static Socket ServerSocket;



        static void Receive()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("192.168.2.138");
            IPEndPoint iPEndPoint=
        }
        static void Main(string[] args)
        {
        }
    }
}
