﻿using System;
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
        public static TcpClient Client;

        public static void SendCommands(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command + "\r\n");
            NetworkStream stream = Client?.GetStream();
            try
            {
                stream?.Write(data, 0, data.Length);
            }
            catch
            {
                Console.WriteLine("Problem with sending: " +  command);
            }

        }

        public static void AssignSocket()
        {
            int port = Properties.Settings.Default.FlightCommandPort;
            string ip = Properties.Settings.Default.FlightServerIP;
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipAddr, port);
            Client = new TcpClient();
            Client.Connect(ep);
            Console.WriteLine("You are connected as a client");
        }

        public static void Close()
        {
            Client.Close();
        }
    }
}
