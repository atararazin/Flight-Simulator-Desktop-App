using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulator.Model
{
    class ManualFlightModel
    {
        private TcpClient client;
        private double _throttleVal;
        private double _rudderVal;

        /// <summary>
        /// Constructor. Connect to the simulator sever port.
        /// TODO: change to application settings: port, address.
        /// </summary>
        public ManualFlightModel()
        {
            client = new TcpClient("127.0.0.1", 5402);
        }


        public double ThrottleValue
        {
            get { return _throttleVal; }
            set
            {
                _throttleVal = value;
                string message = BuildMessage("throttle", value);
                SendMessage(message);

            }
        }
        public double RudderValue
        {
            get { return _rudderVal; }
            set
            {
                _rudderVal = value;
                string message = BuildMessage("rudder", value);
                SendMessage(message);

            }
        }


        /// <summary>
        /// The function builds the message to send
        /// </summary>
        /// <param name="propertyName"></param>
        /// /// <param name="value"></param>
        /// <returns></returns>
        private string BuildMessage(string propertyName, double value)
        {
            string message = "";
            if (propertyName == "rudder")
                message =  "set " + "/controls/flight/rudder " + value + value + "\r\n";

            if (propertyName == "throttle")
                message =  "set " + "/controls/engines/engine/throttle" + value + value + "\r\n";
            Console.WriteLine(message);
            return message;
        }

        /// <summary>
        /// The function sends the message
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }

    }
}
