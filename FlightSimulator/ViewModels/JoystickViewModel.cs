using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        /// <summary>
        /// Rudder value property
        /// </summary>
        public double RudderValue
        {
            get;
            set;
        }

        /// <summary>
        /// Throttle value property
        /// </summary>
        public double ThrottleValue
        {
            get;
            set;
        }
    }
}
