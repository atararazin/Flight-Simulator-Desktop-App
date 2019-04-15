using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    static class CommandsChannel
    {
        public static TcpClient client;
        public static void SendCommands(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command + "\r\n");
            NetworkStream stream = client?.GetStream();
            stream?.Write(data, 0, data.Length);
        }

        public static void AssignSocket()
        {
            int port = Properties.Settings.Default.FlightCommandPort;
            string ip = Properties.Settings.Default.FlightServerIP;
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipAddr, port);
            client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
        }

        public static void Close()
        {
            client.Close();
        }
    }
}
