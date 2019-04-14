using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class FlightCommands
    {
        public static readonly Dictionary<string, string> mapper;

        static FlightCommands()
        {
            mapper = new Dictionary<string, string>
            {
                {"rudder", "/controls/flight/rudder" },
                {"throttle", "/controls/engines/current-engine/throttle" },
                {"aileron" ,"/controls/flight/aileron" },
                {"elevator", "/controls/flight/elevator" }
            };
        }
    }
}
