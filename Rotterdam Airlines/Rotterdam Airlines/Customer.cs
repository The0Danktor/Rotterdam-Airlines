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
        public string gender { get; set; }
        public string birth_date { get; set; }
        public string phone_number { get; set; }

        public Customer(string email, string password, string first_name, string last_name, string country, string gender, string birth_date, string phone_number) : base(email, password)
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

        public void SetToDefault()
        {
            this.first_name = null;
            this.last_name = null;
            this.country = null;
            this.gender = null;
            this.birth_date = null;
            this.phone_number = null;
            this.email = null;
            this.password = null;

        }
        private string getFullName()
        {
            return $"{first_name} {last_name}";
        }

        public static void RegisterCustomer(Customer CurrentUser)
        {
            bool creating = true;
            while (creating)
            {
                UserInterface.PrintLogo();
                UserInterface.PrintRegisterMenu(CurrentUser);
                Console.Write("Maak een keuze: ");
                string register_input = Console.ReadLine();
                int register_choice = int.Parse(register_input);
                switch (register_choice)
                {
                    case 0:
                        creating = false;
                        break;
                    case 1:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw email in: ");
                        CurrentUser.email = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw wachtwoord in: ");
                        CurrentUser.password = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        UserInterface.PrintLogo(); ;
                        Console.Write("Vul uw naam in: ");
                        CurrentUser.first_name = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw achternaam in: ");
                        CurrentUser.last_name = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw land in: ");
                        CurrentUser.country = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.WriteLine("1: man");
                        Console.WriteLine("2: vrouw");
                        Console.WriteLine();
                        Console.Write("Maak een keuze: ");
                        if (Console.ReadLine() == "1")
                        {
                            CurrentUser.gender = "man";
                        }
                        else
                        {
                            CurrentUser.gender = "vrouw";
                        }
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw geboortedatum in als dd-mm-jjjj: ");
                        CurrentUser.birth_date = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        UserInterface.PrintLogo();
                        Console.Write("Vul uw telefoonnummer in: ");
                        CurrentUser.phone_number = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 9:
                        List<Customer> temp = JSON.LoadCustomersJSON();
                        temp.Add(CurrentUser);
                        Console.WriteLine(temp);

                        CurrentUser.SetToDefault();
                        JSON.SaveCustomersJSON(temp);

                        creating = false;
                        break;
                }
            }

        }
    }
}
