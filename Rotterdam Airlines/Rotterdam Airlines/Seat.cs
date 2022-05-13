using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class Seat
    {
        public string Id { set; get; }
        public string SeatClass { set; get; }
        public string Occupant { set; get; }
        public string Description { set; get; }
        public string Special { set; get; }
        public double Price { set; get; }
        public string FlightCode { get; set; }

        Dictionary<string, Dictionary<int, double>> priceList = new Dictionary<string, Dictionary<int, double>>()
        {
            { "Porto", new Dictionary<int, double>(){ { 1, 79.0 }, { 2, 61.0 }, { 3, 109.0 }, { 4, 215.0 }, { 5, 58.0 }, { 6, 64.0 }, { 7, 88.0 }, { 8, 122.0 }, { 9, 92.0 }, { 10, 85.0 }, { 11, 72.0 }, { 12, 57.0 } } },
            { "Valencia", new Dictionary<int, double>(){ { 1, 84.0 }, { 2, 90.0 }, { 3, 98.0 }, { 4, 93.0 }, { 5, 78.0 }, { 6, 48.0 }, { 7, 125.0 }, { 8, 92.0 }, { 9, 77.0 }, { 10, 82.0 }, { 11, 57.0 }, { 12, 44.0 } } },
            { "Sevilla", new Dictionary<int, double>(){ { 1, 106.0 }, { 2, 112.0 }, { 3, 114.0 }, { 4, 129.0 }, { 5, 142.0 }, { 6, 66.0 }, { 7, 114.0 }, { 8, 148.0 }, { 9, 96.0 }, { 10, 85.0 }, { 11, 82.0 }, { 12, 88.0 } } },
            { "Barcelona", new Dictionary<int, double>(){ { 1, 67.0 }, { 2, 72.0 }, { 3, 74.0 }, { 4, 97.0 }, { 5, 58.0 }, { 6, 47.0 }, { 7, 84.0 }, { 8, 72.0 }, { 9, 60.0 }, { 10, 62.0 }, { 11, 67.0 }, { 12, 91.0 } } },
            { "Dusseldorf", new Dictionary<int, double>(){ { 1, 128.0 }, { 2, 130.0 }, { 3, 163.0 }, { 4, 128.0 }, { 5, 128.0 }, { 6, 104.0 }, { 7, 106.0 }, { 8, 123.0 }, { 9, 129.0 }, { 10, 128.0 }, { 11, 130.0 }, { 12, 128.0 } } },
            { "Oslo", new Dictionary<int, double>(){ { 1, 104.0 }, { 2, 156.0 }, { 3, 111.0 }, { 4, 155.0 }, { 5, 48.0 }, { 6, 87.0 }, { 7, 52.0 }, { 8, 71.0 }, { 9, 114.0 }, { 10, 89.0 }, { 11, 115.0 }, { 12, 131.0 } } },
            { "Malaga", new Dictionary<int, double>(){ { 1, 91.0 }, { 2, 115.0 }, { 3, 94.0 }, { 4, 101.0 }, { 5, 50.0 }, { 6, 54.0 }, { 7, 141.0 }, { 8, 89.0 }, { 9, 107.0 }, { 10, 79.0 }, { 11, 59.0 }, { 12, 52.0 } } },
            { "Brussel", new Dictionary<int, double>(){ { 1, 143.0 }, { 2, 140.0 }, { 3, 138.0 }, { 4, 142.0 }, { 5, 50.0 }, { 6, 127.0 }, { 7, 98.0 }, { 8, 124.0 }, { 9, 125.0 }, { 10, 93.0 }, { 11, 127.0 }, { 12, 172.0 } } },
            { "Zurich", new Dictionary<int, double>(){ { 1, 170.0 }, { 2, 151.0 }, { 3, 148.0 }, { 4, 141.0 }, { 5, 149.0 }, { 6, 140.0 }, { 7, 143.0 }, { 8, 107.0 }, { 9, 139.0 }, { 10, 143.0 }, { 11, 143.0 }, { 12, 142.0 } } },
            { "Rome", new Dictionary<int, double>(){ { 1, 90.0 }, { 2, 82.0 }, { 3, 74.0 }, { 4, 139.0 }, { 5, 34.0 }, { 6, 35.0 }, { 7, 61.0 }, { 8, 52.0 }, { 9, 59.0 }, { 10, 81.0 }, { 11, 87.0 }, { 12, 71.0 } } },
            { "Wenen", new Dictionary<int, double>(){ { 1, 94.0 }, { 2, 101.0 }, { 3, 150.0 }, { 4, 139.0 }, { 5, 116.0 }, { 6, 34.0 }, { 7, 97.0 }, { 8, 89.0 }, { 9, 83.0 }, { 10, 82.0 }, { 11, 94.0 }, { 12, 83.0 } } },
            { "Madrid", new Dictionary<int, double>(){ { 1, 69.0 }, { 2, 76.0 }, { 3, 79.0 }, { 4, 98.0 }, { 5, 60.0 }, { 6, 70.0 }, { 7, 103.0 }, { 8, 74.0 }, { 9, 74.0 }, { 10, 74.0 }, { 11, 50.0 }, { 12, 70.0 } } },
            { "Praag", new Dictionary<int, double>(){ { 1, 61.0 }, { 2, 116.0 }, { 3, 143.0 }, { 4, 144.0 }, { 5, 87.0 }, { 6, 61.0 }, { 7, 66.0 }, { 8, 72.0 }, { 9, 53.0 }, { 10, 85.0 }, { 11, 90.0 }, { 12, 90.0 } } },
            { "Dublin", new Dictionary<int, double>(){ { 1, 47.0 }, { 2, 100.0 }, { 3, 103.0 }, { 4, 153.0 }, { 5, 28.0 }, { 6, 19.0 }, { 7, 45.0 }, { 8, 32.0 }, { 9, 37.0 }, { 10, 35.0 }, { 11, 45.0 }, { 12, 45.0 } } },
            { "Lyon", new Dictionary<int, double>(){ { 1, 118.0 }, { 2, 120.0 }, { 3, 165.0 }, { 4, 130.0 }, { 5, 113.0 }, { 6, 96.0 }, { 7, 82.0 }, { 8, 96.0 }, { 9, 96.0 }, { 10, 98.0 }, { 11, 96.0 }, { 12, 119.0 } } },
            { "Munchen", new Dictionary<int, double>(){ { 1, 115.0 }, { 2, 116.0 }, { 3, 117.0 }, { 4, 116.0 }, { 5, 110.0 }, { 6, 115.0 }, { 7, 80.0 }, { 8, 114.0 }, { 9, 115.0 }, { 10, 116.0 }, { 11, 115.0 }, { 12, 116.0 } } },
            { "Kopenhagen", new Dictionary<int, double>(){ { 1, 95.0 }, { 2, 101.0 }, { 3, 105.0 }, { 4, 128.0 }, { 5, 56.0 }, { 6, 57.0 }, { 7, 75.0 }, { 8, 69.0 }, { 9, 80.0 }, { 10, 59.0 }, { 11, 98.0 }, { 12, 64.0 } } },
            { "Londen", new Dictionary<int, double>(){ { 1, 80.0 }, { 2, 85.0 }, { 3, 53.0 }, { 4, 108.0 }, { 5, 35.0 }, { 6, 31.0 }, { 7, 42.0 }, { 8, 29.0 }, { 9, 51.0 }, { 10, 34.0 }, { 11, 63.0 }, { 12, 41.0 } } }
        };

        public Seat(string id, string seatclass, string special, Flight flight, double price = 0.0)
        {
            this.Id = id;
            this.SeatClass = seatclass;
            this.Occupant = null;
            this.Special = special;
            this.Price = price;

            //LOADING SCREEN
            int s = DateTime.Now.Second;
            int amount = s % 4;
            Console.WriteLine("\n    Loading" + new String('.', amount) + "   ");
            Console.SetCursorPosition(0, 0);
            
            if (price == 0.0)
            {
                this.Price = priceList[flight.Destination][flight.Departure.Month] / 2;
                switch (seatclass)
                {
                    case "first":
                        this.Description = " First class zitplekken bevinden zich aan de voorkant van het vliegtuig. De ultime luxe met de beste service en de grootste stoelen met de meeste been ruimte.";
                        this.Price *= 5;
                        break;
                    case "business":
                        this.Description = " Business class zitplekken liggen ergens tussen economy en first-class. Het zijn altijd wat grotere en meer comfortabele plekken dan economy.";
                        this.Price *= 2.5;
                        break;
                    case "economy":
                        this.Description = " Economy class zitplekken zijn de standaard meest goedkope zitplekken.";
                        this.Price *= 1;
                        break;
                    default:
                        this.Description = " Unspecified, Deze klasse heeft geen beschrijving.";
                        break;
                }

                if (this.Special.Contains("limited") || this.Special.Contains("missing"))
                {
                    this.Price *= 0.9;
                }
                else if (this.Special.Contains("increased"))
                {
                    this.Price *= 1.1;
                }

                this.Price = Math.Round(this.Price, 2);
            }
        }
    }
}
