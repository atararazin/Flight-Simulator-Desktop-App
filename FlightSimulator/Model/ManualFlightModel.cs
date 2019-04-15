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
        private double _aileronVal;
        private double _elevatorVal;

        /// <summary>
        /// Constructor. Connect to the simulator sever port.
        /// TODO: change to application settings: port, address.
        /// </summary>
        public ManualFlightModel()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5402);
            }
            catch
            {
                client = null;
            }

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

        public double AileronValue
        {
            get { return _aileronVal; }
            set
            {
                _aileronVal = value;
                string message = BuildMessage("aileron", value);
                SendMessage(message);

            }
        }

        public double ElevatorValue
        {
            get { return _elevatorVal; }
            set
            {
                _elevatorVal = value;
                string message = BuildMessage("elevator", value);
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
            message = "set " + FlightCommands.mapper[propertyName] + " " + value + "\r\n";
            
            //Console.WriteLine(message);
            return message;
        }

        /// <summary>
        /// The function sends the message
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client?.GetStream();
            stream?.Write(data, 0, data.Length);
        }

    }
}
