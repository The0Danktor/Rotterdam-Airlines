using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class User
    {
        public string email { get; set; }
        public string password { get; set; }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
