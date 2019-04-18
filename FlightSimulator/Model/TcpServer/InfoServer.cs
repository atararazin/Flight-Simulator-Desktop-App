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
    
        public InfoServer(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
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
