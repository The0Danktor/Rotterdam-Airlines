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
