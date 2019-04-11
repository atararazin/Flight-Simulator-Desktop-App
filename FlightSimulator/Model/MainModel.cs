using System;
using System.Collections.Generic;
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
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
                TcpClient client = new TcpClient();
                client.Connect(ep);
                Console.WriteLine("You are connected");
                client.Close();
            });

            taskClient.Start();
        }
    }
}
