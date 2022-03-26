using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class FilterHandler
    {
        public static List<Flight> filterList(List<Flight> flights, Hashtable filters, string sortingMethod)
        {
            List<Flight> ReturnList = new List<Flight>();

            for(int i = 0; i < flights.Count; i++)
            {
                ReturnList.Add(flights[i]);
            }

            foreach (Flight flight in ReturnList.ToList())
            {
                //REMOVE FLIGHT WITH UNWANTED DESTINATION
                if ((string) filters["Bestemming"] != "")
                {
                    string destination = flight.Destination;
                    string wantedDestination = (string)filters["Bestemming"];
                    if (wantedDestination != destination)
                    {
                        ReturnList.Remove(flight);
                    }
                }

                //REMOVE FLIGHTS ON UNWANTED DATE
                if ((string) filters["Datum"] != "")
                {
                    DateTime date = flight.Departure.Date;
                    string wantedDateString = (string)filters["Datum"]; 
                    DateTime wantedDate;
                    //commented out because TryParseExact() didn't work so im using TryParse() instead. This change works fine but leaving this code here just incase
                    //var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
                    //bool validDate = DateTime.TryParseExact(wantedDateString, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out wantedDate);
                    bool validDate = DateTime.TryParse(wantedDateString, out wantedDate);
                    if (validDate && date != wantedDate)
                    {
                        ReturnList.Remove(flight);
                    }
                }

                //REMOVE FLIGHTS WITH TOO FEW SEATS
                //wip

                //REMOVE FLIGHTS THAT ARE TOO EXPENSIVE
                //wip
            }
            return ReturnList;
        }
    }
}
