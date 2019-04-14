using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IAutoPilotModel : INotifyPropertyChanged
    {
        List<string> Instructions { get; set; }
        void Send();
        void Clear();

    }
}
