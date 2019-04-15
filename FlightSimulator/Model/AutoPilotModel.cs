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
        private List<string> _instructionsList;

        private string _instructionsString;
        public string InstructionsString
        {
            get { return this._instructionsString; }
            set
            {
                this._instructionsString = value;
                NotifyPropertyChanged("Instructions");
            }
        }

        private List<string> turnStringintoList(string s)
        {
            string[] result = s.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return new List<string>(result);
        }


        public void Send()
        {
            this._instructionsList = turnStringintoList(this._instructionsString);
            foreach (string i in this._instructionsList)
            {
                CommandsChannel.SendCommands(i);
                Console.WriteLine(i);
            }
        }

        public void Clear()
        {
            this._instructionsString = "";
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}