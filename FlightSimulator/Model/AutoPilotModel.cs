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

        public string singleInstruction;

        private List<string> _instructions = new List<string>();
        public List<string> Instructions
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
            foreach (string i in Instructions)
            {
                CommandsChannel.SendCommands(i);
            }
        }

        public void Clear()
        {
            _instructions.Clear();
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}