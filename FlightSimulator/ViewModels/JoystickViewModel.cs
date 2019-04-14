using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        private ManualFlightModel model;
        

        public JoystickViewModel()
        {
            this.model = new ManualFlightModel();
        }

        public double ThrottleVal
        {
            get { return model.ThrottleValue; }
            set
            {
                //this._throttleVal = value;
                model.ThrottleValue = value;
                Console.WriteLine(value);
            }
        }

        public double RudderVal
        {
            get { return model.RudderValue; }
            set
            {
                model.RudderValue = value;
                Console.WriteLine(value);
            }
        }

        public double AileronVal
        {
            get { return model.AileronValue; }
            set
            {
                model.AileronValue = value;
                Console.WriteLine(value);
            }
        }

        public double ElevatorVal
        {
            get { return model.ElevatorValue; }
            set
            {
                model.ElevatorValue = value;
                Console.WriteLine(value);
            }
        }


    }
}
