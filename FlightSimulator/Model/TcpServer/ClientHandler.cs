using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;


namespace FlightSimulator.Model.TcpServer
{
    public class ClientHandler : IClientHandler
    {
        private FlightBoardModel model; // The model object for updating its properties

        public ClientHandler(FlightBoardModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Handles single client connection
        /// </summary>
        /// <param name="client"></param>
        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    while (client.Connected)
                    {
                        byte[] msg = new byte[500];
                        try
                        {
                            stream.Read(msg, 0, msg.Length);
                        }
                        catch
                        {
                            break;
                        }
                        string raw = Encoding.ASCII.GetString(msg);
                        string[] values = raw.Split(',');
                        double lon = Convert.ToDouble(values[0]);
                        double lat = Convert.ToDouble(values[1]);
                        Console.WriteLine(lon);
                        Console.WriteLine(lat);
                        this.model.Lat = lat;
                        this.model.Lon = lon;
                    }
                }
                client.Close();
            }).Start();

        }

    }
}
