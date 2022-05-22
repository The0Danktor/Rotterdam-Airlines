using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Rotterdam_Airlines
{
    class JSON
    {
        // CUSTOMER JSON
        static string CustomersJSON = @"..\..\..\json\customers.json";
        public static List<Customer> LoadCustomersJSON()
        {
            string JsonString = File.ReadAllText(CustomersJSON);
            List<Customer> objects = JsonConvert.DeserializeObject<List<Customer>>(JsonString);
            return objects;
        }
        public static void SaveCustomersJSON(List<Customer> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(CustomersJSON, jsonString);
        }

        // ID JSON
        static string IdJSON = @"..\..\..\json\id.json";
        public static Dictionary<string, List<int>> LoadIdJSON()
        {
            string JsonString = File.ReadAllText(IdJSON);
            Dictionary<string, List<int>> objects = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(JsonString);
            return objects;
        }
        public static void SaveIdJSON(Dictionary<string, List<int>> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(IdJSON, jsonString);
        }

        // FLIGHTSCHEME JSON
        static string FlightschemeJSON = @"..\..\..\json\flightscheme.json";
        public static List<Hashtable> LoadFlightschemeJSON()
        {
            string JsonString = File.ReadAllText(FlightschemeJSON);
            List<Hashtable> objects = JsonConvert.DeserializeObject<List<Hashtable>>(JsonString);
            return objects;
        }
        public static void SaveFlightschemeJSON(List<Hashtable> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FlightschemeJSON, jsonString);
        }

        // FLIGHTS JSON
        static string FlightsJSON = @"..\..\..\json\flights.json";
        public static List<Flight> LoadFlightsJSON()
        {
            string JsonString = File.ReadAllText(FlightsJSON);
            List<Flight> objects = JsonConvert.DeserializeObject<List<Flight>>(JsonString);
            return objects;
        }
        public static void SaveFlightsJSON(List<Flight> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FlightsJSON, jsonString);
        }
        // SEATS JSON
        static string SeatsJSON = @"..\..\..\json\seats.json";
        public static Dictionary<string, List<Seat>> LoadSeatsJSON()
        {
            string JsonString = File.ReadAllText(SeatsJSON);
            Dictionary<string, List<Seat>> objects = JsonConvert.DeserializeObject<Dictionary<string, List<Seat>>>(JsonString);

            List<Flight> flights = LoadFlightsJSON();
            List<string> keys = new List<string>(objects.Keys);
            // ADD MISSING FLIGHTS
            foreach (Flight flight in flights)
            {
                if (!keys.Contains(flight.FlightCode))
                {
                    objects.Add(flight.FlightCode, PlaneLayouts.CreateSeatList(flight));
                }
            }
            // REMOVING LOST FLIGHTS
            foreach (string key in keys)
            {
                bool remove = true;
                foreach (Flight flight in flights)
                {
                    if (key == flight.FlightCode) { remove = false; }
                }
                if (remove)
                {
                    objects.Remove(key);
                }
            }
            return objects;
        }
        public static void SaveSeatsJSON(Dictionary<string, List<Seat>> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SeatsJSON, jsonString);
        }
        // BOOKINGS JSON
        static string BookingsJSON = @"..\..\..\json\bookings.json";
        public static List<Booking> LoadBookingsJSON()
        {
            string JsonString = File.ReadAllText(BookingsJSON);
            List<Booking> objects = JsonConvert.DeserializeObject<List<Booking>>(JsonString);
            return objects;
        }
        public static void SaveBookingsJSON(List<Booking> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(BookingsJSON, jsonString);
        }
    }
}