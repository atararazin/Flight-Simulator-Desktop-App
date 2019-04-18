using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel model;

        /// <summary>
        /// Constructor
        /// </summary>
        public FlightBoardViewModel()
        {
            //this.model = new FlightBoardModel();
        }

        public double Lon
        {
            get
            {
                return this.model.Lon;
            }
        }

        public double Lat
        {
            get
            {
                return this.model.Lat;
            }
        }
    }
}
