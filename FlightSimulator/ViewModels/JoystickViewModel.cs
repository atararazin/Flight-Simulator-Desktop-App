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
        //private double _throttleVal;
        //private double _rudderVal;

        public JoystickViewModel()
        {
            this.model = new ManualFlightModel();
        }

        public double ThrottleVal
        {
            //get { return this._throttleVal; }
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
            //get { return this._rudderVal; }
            get { return model.RudderValue; }
            set
            {
                //this._rudderVal = value;
                model.RudderValue = value;
                Console.WriteLine(value);
            }
        }




    }
}
