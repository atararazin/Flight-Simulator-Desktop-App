using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel
    {
        private double _lon;
        private double _lat;
        private InformationServer srv;

        public FlightBoardModel()
        {
            //this.srv = new InformationServer();
        }


        public double Lon
        {
            get { return this._lon; }
            set { }
        }
        
        public double Lat
        {
            get { return this._lat; }
            set { }
        }


    }
}
