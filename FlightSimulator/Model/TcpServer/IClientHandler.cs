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
    public interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}
