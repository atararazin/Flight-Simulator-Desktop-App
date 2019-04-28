using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace FlightSimulator.Model.TcpServer
{
    public class InfoServer
    {
        private int port;
        private TcpListener listener;
        private IClientHandler ch;
        private string ipAddr;
    
        public InfoServer(int port, string ipAddr, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
            this.ipAddr = ipAddr;
        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for connections...");
            Thread thread = new Thread(() => {
                //while (true)
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Got new connection");
                    ch.HandleClient(client);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Could not handle client connection");
                }
                Console.WriteLine("Server stopped");
            });
            thread.Start();
        }

        public void Stop()
        {
            listener.Stop();
        }

    }
}
