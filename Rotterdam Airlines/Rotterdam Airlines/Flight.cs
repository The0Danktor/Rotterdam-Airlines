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
        private string DepartureHour { set; get; }
        private string Gate { set; get; }

        private bool Cancelled = false;

        public static List<Flight> Flights = new List<Flight>();

        public Flight(string flightNumber, string planeType, string airline, string destination, string departure, string gate)
        {
            this.FlightCode = "todo";
            this.FlightNumber = flightNumber;
            this.PlaneType = planeType;
            this.Airline = airline;
            this.Destination = destination;
            this.Departure = departure;
            this.Gate = gate;
            Flights.Add(this);
        }

        public static List<Flight> GetFlights()
        {
            return Flights;
        }

        DateTime DepartureTest = new DateTime();
    }
}
