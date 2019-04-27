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
            get { return _instructionsString; }
            set
            {
                _instructionsString = value;
                NotifyPropertyChanged("Instructions");
            }
        }

        private bool _isUserDone;
        public bool IsUserDone
        {
            get { return _isUserDone; }
            set
            {
                _isUserDone = value;
                NotifyPropertyChanged("IsUserDone");
            }
        }

        private List<string> turnStringintoList(string s)
        {
            string[] result = s.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return new List<string>(result);
        }


        public async void Send()
        {
            this._instructionsList = turnStringintoList(this._instructionsString);
            foreach (string i in this._instructionsList)
            {
                CommandsChannel.SendCommands(i);
                await Task.Delay(2000);
                Console.WriteLine(i);
            }
            IsUserDone = true;
        }

        public void Clear()
        {
            InstructionsString = "";
            IsUserDone = true;
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}