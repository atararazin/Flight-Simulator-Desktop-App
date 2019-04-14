using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MainModel
    {
        public MainModel()
        {

        }
        public void Connect()
        {
            Task taskClient = new Task(() => {
            int port = Properties.Settings.Default.FlightCommandPort;
            string ip = Properties.Settings.Default.FlightServerIP;
                //CHANGE THIS!
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 5402);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            string s = Console.ReadLine();
            writer.Write("set controls/flight/rudder -1\r\n");
            Console.WriteLine("sent command to the server");
            client.Close();
            });

            taskClient.Start();
        }
    }
}
