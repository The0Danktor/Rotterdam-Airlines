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
        private string CustomerID { get; set; }
        private string CustomerPhoneNumber { get; set; }
        private string CustomerEmail { get; set; }

        // BOOKING DATA
        private string FlightCode { get; set; }
        private string BookingID { get; set; }
        private double BookingPrice { get; set; }
        private double BookingDiscount { get; set; }

        // BOOKING PERSONS
        private List<BookingPerson> BookingPersons = new List<BookingPerson>();

        // ALL BOOKINGS
        private static List<Booking> Bookings = new List<Booking>();

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
