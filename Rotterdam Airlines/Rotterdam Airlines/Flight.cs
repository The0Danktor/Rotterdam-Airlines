using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Rotterdam_Airlines
{
    class Flight
    {
        public string FlightCode { set; get; }
        public string FlightNumber { set; get; }
        public string PlaneType { set; get; }
        public string Airline { set; get; }
        public string Destination { set; get; }
        public DateTime Departure { set; get; }
        public string Gate { set; get; }

        public bool Cancelled = false;

        public static List<Flight> Flights = new List<Flight>();

        public Flight(string flightNumber, string planeType, string airline, string destination, DateTime departure, string gate, bool cancelled)
        {
            this.FlightCode = "todo";
            this.FlightNumber = flightNumber;
            this.PlaneType = planeType;
            this.Airline = airline;
            this.Destination = destination;
            this.Departure = departure;
            this.Gate = gate;
            this.Cancelled = cancelled;
            Flights.Add(this);
        }

        public static List<Flight> GetFlights()
        {
            return Flights;
        }

        //GENERATES A SCHEDULE FOR A SPECIFIED DAY
        private static void GenerateFlights(DateTime date)
        {
            List<Hashtable> jsonScheme = JSON.LoadFlightschemeJSON();
            Flights = JSON.LoadFlightsJSON();

            foreach (Hashtable table in jsonScheme)
            {
                double extraHour = (double) Convert.ToInt32(table["Departure"]);
                DateTime newDeparture = date.AddHours(extraHour);
                Flight flight = new Flight((string) table["FlightNumber"], (string) table["PlaneType"], (string) table["Airline"], (string) table["Destination"], newDeparture, (string) table["Gate"], false);
              
            }
            JSON.SaveFlightsJSON(Flights);
            JSON.SaveFlightschemeJSON(jsonScheme);
        }

        //GENERATES SCHEDULE FOR THE UPCOMMING 2 WEEKS
        public static void GenerateFlightWeeks()
        {
            Flights = JSON.LoadFlightsJSON();

            Flight last = Flights[Flights.Count - 1];
            DateTime changeDate = last.Departure.Date;
            DateTime finalDate = DateTime.Today.AddDays(13);
            while (changeDate < finalDate)
            {
                changeDate = changeDate.AddDays(1);
                GenerateFlights(changeDate);
            };
        }
    }
}
