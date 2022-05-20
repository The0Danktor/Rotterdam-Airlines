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
        public bool CheckedLuggage { get; set; }
        public bool Cancelled { get; set; }

        // BOOKING PERSONS
        public List<BookingPerson> BookingPersons = new List<BookingPerson>();
        //BOOKING SEATS
        public List<Seat> SeatList = new List<Seat>();
        // ALL BOOKINGS
        public static List<Booking> Bookings = new List<Booking>();

        public Booking(string customerID, string customerPhoneNumber, string customerEmail, string flightCode, string bookingID, double bookingPrice, double bookingDiscount, List<BookingPerson> bookingPersons,List<Seat> seatlist, bool checkedLuggage, bool cancelled)
        {
            CustomerID = customerID;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerEmail = customerEmail;
            FlightCode = flightCode;
            BookingID = bookingID;
            BookingPrice = bookingPrice;
            BookingDiscount = bookingDiscount;
            CheckedLuggage = checkedLuggage;
            BookingPersons = bookingPersons;
            SeatList = seatlist;
            Bookings.Add(this);
            Cancelled = cancelled;  
        }

        public static string GenerateBookingID()
        {
            Bookings = JSON.LoadBookingsJSON();
            int BookingID;
            try
            {
                BookingID = Int32.Parse(Bookings[^1].BookingID);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                BookingID = 0;
            }
            BookingID++;
            string BookingIDString = BookingID.ToString();

            while (BookingIDString.Length < 6)
            {
                BookingIDString = "0" + BookingIDString;
            }
            return BookingIDString;
        }
        public static void SaveBooking(Booking booking)
        {
            Bookings = JSON.LoadBookingsJSON();
            Bookings.Add(booking);
            JSON.SaveBookingsJSON(Bookings);
        }
        public bool BookingComplete()
        {
            bool done;
            bool personDone = true;
            foreach (BookingPerson person in BookingPersons)
            {
                if (!person.PersonComplete())
                {
                    personDone = false;
                }
            }
            if(CustomerPhoneNumber == null || CustomerEmail == null || !personDone) 
            {
                done = false;
            }
            else
            {
                done = true;
            }
            return done;
        }

    }
}
