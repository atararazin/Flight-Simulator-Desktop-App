using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.TcpServer;

namespace FlightSimulator.Model
{
    public class FlightBoardModel
    {
        private double _lon;
        private double _lat;
        //private InformationServer srv;
        private InfoServer srv;

        public FlightBoardModel()
        {
            //this.srv = new InformationServer();
            IClientHandler ch = new ClientHandler(this);
            this.srv = new InfoServer(5008, ch);
            this.srv.Start();
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
