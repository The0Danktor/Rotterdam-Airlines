using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Customer : User
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country { get; set; }
        public char gender { get; set; }
        public string birth_date { get; set; }
        public string phone_number { get; set; }

        public Customer(string email, string password, string first_name, string last_name, string country, char gender, string birth_date, string phone_number) : base(email, password)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.country = country;
            this.gender = gender;
            this.birth_date = birth_date;
            this.phone_number = phone_number;
            this.email = email;
            this.password = password;
        }

        private string getFullName()
        {
            return $"{first_name} {last_name}";
        }
    }
}
