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

        private string _isTyping;
        public string IsTyping
        {
            get { return _isTyping; }
            set
            {
                _isTyping = value;
                NotifyPropertyChanged("IsTyping");
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
            IsTyping = "White";
        }

        public void Clear()
        {
            InstructionsString = "";
            IsTyping = "White";
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}