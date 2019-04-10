using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        #region Singleton
        private static ISettingsModel m_Instance = null;
        public static ISettingsModel Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = new ApplicationSettingsModel();
                }
                return m_Instance;
            }
        }
        #endregion
        public string FlightServerIP
        {
            get { return Properties.Settings.Default.FlightServerIP; }
            set { Properties.Settings.Default.FlightServerIP = value; }
        }
        public int FlightCommandPort
        {
            get { return Properties.Settings.Default.FlightCommandPort; }
            set { Properties.Settings.Default.FlightCommandPort = value; }
        }

        private int _flightInfoPort = Properties.Settings.Default.FlightInfoPort;
        public int FlightInfoPort
        {
            get { return _flightInfoPort; }
            set { _flightInfoPort = value; }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.FlightInfoPort = _flightInfoPort; 
            Properties.Settings.Default.Save();
        }

        public void ReloadSettings()
        {
            Properties.Settings.Default.Reload();
        }
    }
}
