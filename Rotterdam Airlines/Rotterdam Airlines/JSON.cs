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
        public static Hashtable LoadIdJSON()
        {
            string JsonString = File.ReadAllText(IdJSON);
            Dictionary<string,Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string,List<int>>>>>> objects = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,Dictionary<string, Dictionary<string,Dictionary<string,List<int>>>>>>>(JsonString);
            Hashtable ret = new Hashtable(objects);
            return ret;
        }
        public static void SaveIdJSON(Hashtable data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(IdJSON, jsonString);
        }
    }
}