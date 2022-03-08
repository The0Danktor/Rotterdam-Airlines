using Newtonsoft.Json;
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
            string jsonString = File.ReadAllText(CustomersJSON);
            List<Customer> objects = JsonConvert.DeserializeObject<List<Customer>>(CustomersJSON);
            return objects;
        }
        public static void SaveCustomersJSON(List<Customer> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(CustomersJSON, jsonString);
        }
    }
}