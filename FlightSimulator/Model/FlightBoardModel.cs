using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.TcpServer;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : INotifyPropertyChanged
    {
        private double _lon;
        private double _lat;
        //private InformationServer srv;
        private InfoServer srv;

        public FlightBoardModel()
        {
            Console.WriteLine("flightbaord trying to connect");
            
            IClientHandler ch = new ClientHandler(this);
            this.srv = new InfoServer(Properties.Settings.Default.FlightInfoPort, Properties.Settings.Default.FlightServerIP , ch);
            this.srv.Start();
            Console.WriteLine("flightboard connected as client");
        }


        public double Lon
        {
            get { return this._lon; }
            set
            {
                this._lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        
        public double Lat
        {
            get { return this._lat; }
            set
            {
                this._lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
