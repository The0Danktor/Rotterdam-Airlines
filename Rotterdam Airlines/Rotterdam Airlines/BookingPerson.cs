using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class BookingPerson
    {
        // CUSTOMER PERSON DATA
        public string CustomerFlightNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerBirthDate { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerBSN { get; set; }
        public BookingPerson(string customerFlightNumber, string customerFirstName, string customerMiddleName, string customerLastName, string customerBirthDate, string customerGender, string customerCountry, string customerBSN = null)
        {
            CustomerFlightNumber = customerFlightNumber;
            CustomerFirstName = customerFirstName;
            CustomerMiddleName = customerMiddleName;
            CustomerLastName = customerLastName;
            CustomerBirthDate = customerBirthDate;
            CustomerGender = customerGender;
            CustomerCountry = customerCountry;
            CustomerBSN = customerBSN;
        }
    }
}
