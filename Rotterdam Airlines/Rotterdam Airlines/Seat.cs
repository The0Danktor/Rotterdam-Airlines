using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class Seat
    {
        public int Id { set; get; }
        public string SeatClass { set; get; }
        public string Occupant { set; get; }
        public string Description { set; get; }
        public string Special { set; get; }

        public Seat(int id, string seatclass, string special)
        {
            this.Id = id;
            this.SeatClass = seatclass;
            this.Occupant = null;
            this.Special = special;
            switch (seatclass)
            {
                case "first":
                    this.Description = "First-class zitplekken bevinden zich aan de voorkant van het vliegtuig. De ultime luxe met de beste service en de grootste stoelen met de meeste been ruimte.";
                    break;
                case "business":
                    this.Description = "Business class zitplekken liggen ergens tussen economy en first-class. Het zijn altijd wat grotere en meer comfortabele plekken dan economy.";
                    break;
                case "economy":
                    this.Description = "Economy class zitplekken zijn de standaard meest goedkope zitplekken.";
                    break;
                default:
                    this.Description = "Unspecified, Deze klasse heeft geen beschrijving.";
                    break;
            }
        }
    }
}
