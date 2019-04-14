using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private AutoPilotModel model;
        public AutoPilotViewModel(AutoPilotModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }

        public string VM_Instructions
        {
            get { return model.singleInstruction; }
            set
            {
                model.singleInstruction = value;
                NotifyPropertyChanged("Instructions");
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnClickOk()));
            }
        }
        private void OnClickOk()
        {
            model.Send();
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClickClear()));
            }
        }
        private void OnClickClear()
        {
            model.Clear();
        }

        private ICommand _enterCommand;
        public ICommand EnterCommand
        {
            get
            {
                return _enterCommand ?? (_enterCommand = new CommandHandler(() => OnEnter()));
            }
        }
        private void OnEnter()
        {
            Console.WriteLine("enter was pressed");
            model.Instructions.Add(VM_Instructions);
        }

    }
}
