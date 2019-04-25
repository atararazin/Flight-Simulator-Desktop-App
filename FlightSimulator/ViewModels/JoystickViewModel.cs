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
            get { return Math.Round(model.ThrottleValue, 2); }
            set
            {
                model.ThrottleValue = value;
                NotifyPropertyChanged("ThrottleVal");
            }
        }

        public double RudderVal
        {
            get { return Math.Round(model.RudderValue, 2); }
            set
            {
                model.RudderValue = value;
                NotifyPropertyChanged("RudderVal");
            }
        }

        public double AileronVal
        {
            get { return Math.Round(model.AileronValue, 2); }
            set
            {
                double normalized = value / 124;
                model.AileronValue = normalized;
                NotifyPropertyChanged("AileronVal");
            }
        }

        public double ElevatorVal
        {
            get { return Math.Round(model.ElevatorValue, 2); }
            set
            {
                double normalized = value / 124;
                model.ElevatorValue = normalized;
                NotifyPropertyChanged("ElevatorVal");
            }
        }


    }
}
