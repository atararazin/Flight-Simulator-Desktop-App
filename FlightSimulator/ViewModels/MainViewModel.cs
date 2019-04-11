using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class MainViewModel
    {
        MainModel model;
        public MainViewModel(MainModel Model)
        {
            this.model = Model;
        }
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            this.model.Connect();
            //IsDisconnected = false; // Setting that the server is connected
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClickSettings()));
            }
        }
        private void OnClickSettings()
        {
            Window settingsWin = new SettingsWindow();
            settingsWin.Show();
        }
    }
}
