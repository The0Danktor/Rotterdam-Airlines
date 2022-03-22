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
        private string FlightCode { set; get; }
        private string FlightNumber { set; get; }
        private string PlaneType { set; get; }
        private string Airline { set; get; }
        private string Destination { set; get; }
        private DateTime Departure { set; get; }
        private string Gate { set; get; }

        private bool Cancelled = false;

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

        public static void GenerateFlights(DateTime date)
        {
            List<Hashtable> jsonScheme = JSON.LoadFlightschemeJSON();
            List<Flight> jsonFlights = JSON.LoadFlightsJSON();

            foreach (Hashtable table in jsonScheme)
            {
                int extraHour = Convert.ToInt32(table["Departure"]);
                DateTime newDeparture = date;
                newDeparture.AddHours(extraHour);
                Flight flight = new Flight((string) table["FlightNumber"], (string) table["PlaneType"], (string) table["Airline"], (string) table["Destination"], newDeparture, (string) table["Gate"], false);
                Flights.Add(flight);
              
            }
            Console.WriteLine(Flights[1].FlightCode);
            JSON.SaveFlightsJSON(Flights);
            JSON.SaveFlightschemeJSON(jsonScheme);
         
        }
    }
}
