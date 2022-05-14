using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Rotterdam_Airlines
{
    class JSON
    {
        // DEFINE JSON PATHS
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