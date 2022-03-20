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
        private string CustomerFirstName { get; set; }
        private string CustomerMiddleName { get; set; }
        private string CustomerLastName { get; set; }
        private string CustomerBirthDate { get; set; }
        private string CustomerGender { get; set; }
        private string CustomerCountry { get; set; }

        public BookingPerson(string customerFirstName, string customerMiddleName, string customerLastName, string customerBirthDate, string customerGender, string customerCountry)
        {
            CustomerFirstName = customerFirstName;
            CustomerMiddleName = customerMiddleName;
            CustomerLastName = customerLastName;
            CustomerBirthDate = customerBirthDate;
            CustomerGender = customerGender;
            CustomerCountry = customerCountry;
        }
    }
}
