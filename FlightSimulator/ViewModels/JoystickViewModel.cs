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
                model.ThrottleValue = value;
                NotifyPropertyChanged("ThrottleVal");
            }
        }

        public double RudderVal
        {
            get { return model.RudderValue; }
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
                double normalized = value / 100;
                model.AileronValue = normalized;
                NotifyPropertyChanged("AileronVal");
            }
        }

        public double ElevatorVal
        {
            get { return Math.Round(model.ElevatorValue, 2); }
            set
            {
                double normalized = value / 100;
                model.ElevatorValue = normalized;
                NotifyPropertyChanged("ElevatorVal");
            }
        }


    }
}
