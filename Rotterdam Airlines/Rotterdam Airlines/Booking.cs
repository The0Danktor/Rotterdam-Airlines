using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Booking
    {
        // CUSTOMER PERSON DATA
        private string CustomerID { get; set; }
        private string CustomerFirstName { get; set; }
        private string CustomerLastName { get; set; }
        private string CustomerBirthDate { get; set; }
        private string CustomerGender { get; set; }

        // CUSTOMER CONTACT DATA
        private string CustomerCountry { get; set; }
        private string CustomerPhoneNumber { get; set; }
        private string CustomerEmail { get; set; }

        // BOOKING DATA
        private Flight Flight { get; set; }
        private string BookingID { get; set; }
        private double BookingPrice { get; set; }
        private double BookingDiscount { get; set; }

        // ALL BOOKINGS
        private static List<Booking> Bookings = new List<Booking>();

        public Booking(string customerID, string customerFirstName, string customerLastName, string customerBirthDate, string customerGender, string customerCountry, string customerPhoneNumber, string customerEmail, Flight flight, string bookingID, double bookingPrice, double bookingDiscount)
        {
            this.CustomerID = customerID;
            this.CustomerFirstName = customerFirstName;
            this.CustomerLastName = customerLastName;
            this.CustomerBirthDate = customerBirthDate;
            this.CustomerGender = customerGender;
            this.CustomerCountry = customerCountry;
            this.CustomerPhoneNumber = customerPhoneNumber;
            this.CustomerEmail = customerEmail;
            this.Flight = flight;
            this.BookingID = bookingID;
            this.BookingPrice = bookingPrice;
            this.BookingDiscount = bookingDiscount;
            Bookings.Add(this);
        }
    }
}
