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
    }
}