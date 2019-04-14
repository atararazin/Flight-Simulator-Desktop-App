using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class AutoPilotModel : IAutoPilotModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _instructions;
        public string Instructions
        {
            get { return this._instructions; }
            set
            {
                this._instructions = value;
                NotifyPropertyChanged("Instructions");
            }
        }


        public void Send()
        {
            CommandsChannel.SendCommands(Instructions);
        }
        public void Clear()
        {
            Instructions = "";
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}