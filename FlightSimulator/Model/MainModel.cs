using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.TcpServer;

namespace FlightSimulator.Model
{
    class MainModel
    {
        public MainModel()
        {

        }
        public void Connect()
        {

            // Set the server
            Task taskSever = new Task(() => {
                InfoServer.SetServer();
                InfoServer.Start();
            });

            Task taskClient = new Task(() => {
                CommandsChannel.AssignSocket();
            });


            Task connectionFlow = new Task(() => {
                taskSever.Start();
                taskSever.Wait();

                Console.WriteLine("Finished waiting as server");

                taskClient.Start();
                taskClient.Wait();
            });


            connectionFlow.Start();

        }
    }
}
