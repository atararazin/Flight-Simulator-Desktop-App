using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel model;
        private double _lon;
        private double _lat;

        /// <summary>
        /// Constructor
        /// </summary>
        public FlightBoardViewModel()
        {
            this.model = new FlightBoardModel();
            this.model.PropertyChanged += Model_PropertyChanged;
        }

        public double Lon
        {
            get
            {
                return this.model.Lon;
            }
            set
            {
                this._lon = value;
                NotifyPropertyChanged("Lon");
            }

        }

        public double Lat
        {
            get
            {
                return this.model.Lat;
            }
            set
            {
                this._lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat"))
            {
                Lat = model.Lat;
            }
            if (e.PropertyName.Equals("Lon"))
            {
                Lon = model.Lon;
            }
        }
    }
}
