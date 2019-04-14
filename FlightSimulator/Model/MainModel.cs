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
                CommandsChannel.AssignSocket();
            });

            taskClient.Start();
        }
    }
}
