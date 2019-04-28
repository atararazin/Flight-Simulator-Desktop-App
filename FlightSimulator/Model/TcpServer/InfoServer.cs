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
    public static class InfoServer
    {
        private static int port;
        //private static TcpListener listener;
        private static IClientHandler ch;
        private static string ipAddr;

        //public InfoServer(int port, string ipAddr, IClientHandler ch)
        //public InfoServer(int port, string ipAddr)
        static InfoServer()
        {

        }

        /// <summary>
        /// Set server's settings
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ipAddr"></param>
        //public static void SetServer(int port, string ipAddr)
          public static void SetServer()
        {
            port = Properties.Settings.Default.FlightInfoPort;
            ipAddr = Properties.Settings.Default.FlightServerIP;
        }

        /// <summary>
        /// Register client handler
        /// </summary>
        /// <param name="ch"></param>
        public static void RegisterClientHandler(IClientHandler cHandler)
        {
            ch = cHandler;
        }

        public static void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for connections...");
          
            try
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Got new connection");
                ch.HandleClient(client);
                listener.Stop();
            }
            catch (SocketException)
            {
                Console.WriteLine("Could not handle client connection");
            }
        }

   

    }
}
