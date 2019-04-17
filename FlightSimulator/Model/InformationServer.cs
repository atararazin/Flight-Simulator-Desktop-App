using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace FlightSimulator.Model
{
    /// <summary>
    /// The class implements TCP server for the info channel.
    /// Uses thread in order to not blocking the Command channel while getting
    /// the information from the simulator
    /// </summary>
    class InformationServer
    {
        private TcpListener srv;
        
        public InformationServer()
        {

            srv = new TcpListener(IPAddress.Parse("127.0.0.1"), 5008);
            srv.Start();

            TcpClient client = srv.AcceptTcpClient();
            Thread clientThread = new Thread(new ParameterizedThreadStart(ClientHandler));
            clientThread.Start(client);
        }


        /// <summary>
        /// Handle the communication with the simulator
        /// </summary>
        /// <param name="obj"></param>
        public void ClientHandler(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client?.GetStream();

            while (client.Connected)
            {
                byte[] msg = new byte[1024];
                stream.Read(msg, 0, msg.Length);
                Console.WriteLine(Encoding.ASCII.GetString(msg));


            }

            client.Close();

        }
    }
}
