using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Booking
    {
        // CUSTOMER CONTACT DATA
        public string CustomerID { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }

        // BOOKING DATA
        public string FlightCode { get; set; }
        public string BookingID { get; set; }
        public double BookingPrice { get; set; }
        public double BookingDiscount { get; set; }

        // BOOKING PERSONS
        public List<BookingPerson> BookingPersons = new List<BookingPerson>();

        // ALL BOOKINGS
        public static List<Booking> Bookings = new List<Booking>();

        public Booking(string customerID, string customerPhoneNumber, string customerEmail, string flightCode, string bookingID, double bookingPrice, double bookingDiscount, List<BookingPerson> bookingPersons)
        {
            CustomerID = customerID;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerEmail = customerEmail;
            FlightCode = flightCode;
            BookingID = bookingID;
            BookingPrice = bookingPrice;
            BookingDiscount = bookingDiscount;
            BookingPersons = bookingPersons;
            Bookings.Add(this);
        }
    }
}
