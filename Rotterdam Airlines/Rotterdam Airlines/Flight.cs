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
        // VARIABLES
        public string FlightCode { set; get; }
        public string FlightNumber { set; get; }
        public string PlaneType { set; get; }
        public string Airline { set; get; }
        public string Destination { set; get; }
        public string DestinationAbbreviation { set; get; }
        public string DestinationAirport { set; get; }
        public DateTime Departure { set; get; }
        public DateTime Arrival { set; get; }
        public string Gate { set; get; }

        public bool Cancelled = false;

        // LIST OF FLIGHTS
        public static List<Flight> Flights = new List<Flight>();

        // CONSTRUCTOR
        public Flight(string flightCode, string flightNumber, string planeType, string airline, string destination, DateTime departure, string gate, bool cancelled , string destinationAbbreviation, string destinationAirport,DateTime arrival)
        {
            this.FlightCode = flightCode;
            this.FlightNumber = flightNumber;
            this.PlaneType = planeType;
            this.Airline = airline;
            this.Destination = destination;
            this.Departure = departure;
            this.Gate = gate;
            this.Cancelled = cancelled;
            this.DestinationAbbreviation = destinationAbbreviation;
            this.DestinationAirport = destinationAirport;
            this.Arrival = arrival;
            Flights.Add(this);
        }

        // RETURNS THE LIST OF FLIGHTS WHICH
        // CONTAINS ALL FLIGHT OBJECTS
        public static List<Flight> GetFlights()
        {
            return Flights;
        }

        // CHECKS IF A FLIGHT EXISTS WITH A SPECIFIC FLIGHTCODE
        public static bool FlightExists(string flightCode)
        {
            bool found = false;
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].FlightCode == flightCode)
                {
                    found = true;
                }
            }
            return found;
        }

        // GETS FLIGHT INDEX FOR A SPECFIC FLIGHTCODE
        public static int GetFlightIndex(string flightCode)
        {
            int index = 0;
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].FlightCode == flightCode)
                {
                    index = i;
                }
            }
            return index;
        }

        public static List<string> GetFlightDestinations()
        {
            List<string> destinations = new List<string>();

            for(int i = 0; i < Flights.Count; i++)
            {
                if (!destinations.Contains(Flights[i].Destination))
                {
                    destinations.Add(Flights[i].Destination);
                }
            }

            return destinations;
        }

        //GENERATES A SCHEDULE FOR A SPECIFIED DAY
        private static void GenerateFlights(DateTime date)
        {
            List<Hashtable> jsonScheme = JSON.LoadFlightschemeJSON();
            Flights = JSON.LoadFlightsJSON();

            int flightCode;

            try
            {
                flightCode = Int32.Parse(Flights[^1].FlightCode);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                flightCode = 0;
            }

            for(int i = 0; i < jsonScheme.Count; i++)
            {
                flightCode++;
                string flightCodeString = flightCode.ToString();

                while(flightCodeString.Length < 6)
                {
                    flightCodeString = "0" + flightCodeString;
                }

                double extraHour = (double)Convert.ToInt32(jsonScheme[i]["Departure"]);
                double extraArrival = (double)Convert.ToDouble(jsonScheme[i]["Arrival"]); 
                DateTime newDeparture = date.AddHours(extraHour);
                DateTime newArrival = date.AddHours(extraArrival);
                Flight flight = new Flight(flightCodeString, (string)jsonScheme[i]["FlightNumber"], (string)jsonScheme[i]["PlaneType"], (string)jsonScheme[i]["Airline"], (string)jsonScheme[i]["Destination"], newDeparture, (string)jsonScheme[i]["Gate"], false, (string)jsonScheme[i]["DestinationAbbreviation"], (string)jsonScheme[i]["DestinationAirport"], newArrival);
            }

            JSON.SaveFlightsJSON(Flights);
        }

        //GENERATES SCHEDULE FOR THE UPCOMMING 2 WEEKS
        public static void GenerateFlightWeeks()
        {
            Flights = JSON.LoadFlightsJSON();
            Flight last;
            DateTime changeDate;

            try
            {
                last = Flights[Flights.Count - 1];
                changeDate = last.Departure.Date;
            } 
            catch (System.ArgumentOutOfRangeException)
            {
                changeDate = DateTime.Today;
            }

            DateTime finalDate = DateTime.Today.AddDays(14);
            while (changeDate < finalDate)
            {
                changeDate = changeDate.AddDays(1);
                GenerateFlights(changeDate);
            };
        }
    }
}
