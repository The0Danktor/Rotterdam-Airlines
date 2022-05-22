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
        public static List<Flight> filterList(List<Flight> flights, Hashtable filters, string sortingMethod, Dictionary<string, List<Seat>>  seatDict)
        {
            List<Flight> ReturnList = new List<Flight>();

            for(int i = 0; i < flights.Count; i++)
            {
                ReturnList.Add(flights[i]);
            }
            //GET CHEAPEST SEAT
            double getCheapPrice(string code)
            {
                List<Seat> seats = seatDict[code];
                double price = 99999999;
                foreach (Seat seat in seats)
                {
                    if (seat.Price < price)
                    {
                        price = seat.Price;
                    }
                }
                return price;
            }

            //GET EXPENSIVE SEAT
            double getExpensivePrice(string code)
            {
                List<Seat> seats = seatDict[code];
                double price = 0;
                foreach (Seat seat in seats)
                {
                    if (seat.Price > price)
                    {
                        price = seat.Price;
                    }
                }
                return price;
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

                List<Seat> seats = seatDict[flight.FlightCode];
                //REMOVE FLIGHTS WITH TOO FEW SEATS
                if ((int)filters["Aantal Personen"] != 0)
                {
                    int available = 0;
                    foreach (Seat seat in seats)
                    {
                        if (seat.Occupant == null)
                        {
                            available += 1;
                        }
                    }
                    if ((int)filters["Aantal Personen"] > available)
                    {
                        ReturnList.Remove(flight);
                    }
                }

                //REMOVE FLIGHTS THAT ARE TOO EXPENSIVE
                if ((int)filters["Maximum Prijs"] != 0)
                {
                    double price = 99999999;
                    foreach (Seat seat in seats)
                    {
                        if (seat.Price < price)
                        {
                            price = seat.Price;
                        }
                    }
                    if ((int)filters["Maximum Prijs"] < price)
                    {
                        ReturnList.Remove(flight);
                    }
                }
            }
            // SORTING
            // oldest date:   date-
            // newest date:   date+
            // lowest price:  price-
            // highest price: price+
            switch (sortingMethod)
            {
                case "date-":
                    ReturnList.Sort((x, y) => -(x.Departure.CompareTo(y.Departure)));
                    break;
                case "date+":
                    ReturnList.Sort((x, y) => x.Departure.CompareTo(y.Departure));
                    break;
                case "price-":
                    ReturnList.Sort((x, y) => getCheapPrice(x.FlightCode).CompareTo(getCheapPrice(y.FlightCode)));
                    break;
                case "price+":
                    ReturnList.Sort((x, y) => -(getExpensivePrice(x.FlightCode).CompareTo(getExpensivePrice(y.FlightCode))));
                    break;
            }

            return ReturnList;
        }
    }
}
