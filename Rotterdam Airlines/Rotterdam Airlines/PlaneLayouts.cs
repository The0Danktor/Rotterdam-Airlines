using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines.JSON
{
    internal class PlaneLayouts
    {
        public string[] PlaneLayout(Flight flight)
        {
            string[] list = new string[5];
            if (flight.PlaneType == "Boeing 737")
            {

            }
            if (flight.PlaneType == "Airbus 330")
            {

            }
            if (flight.PlaneType == "Boeing 787")
            {

            }
            return list;
        }
    }
}
