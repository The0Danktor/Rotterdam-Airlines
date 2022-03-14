using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Rotterdam_Airlines
{
    class Customer : User
    {
        public string UserId { get; set; }
        public string first_name { get; set; }
        public string prefix { get; set; }
        public string last_name { get; set; }
        public string country { get; set; }
        public string gender { get; set; }
        public string birth_date { get; set; }
        public string phone_number { get; set; }


        public Customer(string UserId, string email, string password, string first_name, string prefix ,string last_name, string country, string gender, string birth_date, string phone_number) : base(email, password)
        {
            this.UserId = UserId;
            this.first_name = first_name;
            this.prefix = prefix;
            this.last_name = last_name;
            this.country = country;
            this.gender = gender;
            this.birth_date = birth_date;
            this.phone_number = phone_number;
            this.email = email;
            this.password = password;
        }

        public bool CheckNull()
        {
            return this.UserId != null &&
                   this.first_name != null &&
                   this.prefix != null &&
                   this.last_name != null &&
                   this.country != null &&
                   this.gender != null &&
                   this.birth_date != null &&
                   this.phone_number != null &&
                   this.email != null &&
                   this.password != null;
        }
        public void SetToDefault()
        {
            this.UserId = null;
            this.first_name = null;
            this.prefix=null;
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

        private void GetNewUserID()
        {
            this.UserId = IdHandler.getID();
        }   
        public static void RegisterCustomer(Customer CurrentUser)

        {
            bool creating = true;
            while (creating)
            {
                UserInterface.PrintLogo();
                UserInterface.SetMainColor();
                Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
                Console.WriteLine("    ────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetDefaultColor();
                UserInterface.PrintRegisterMenu(CurrentUser);
                Console.Write("    Maak een keuze: ");

                string register_input = Console.ReadLine();
                int register_choice = int.Parse(register_input);
                switch (register_choice)
                {
                    case 0:
                        creating = false;
                        break;
                    case 1:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw email in: ");
                            string TempEmail = Console.ReadLine();
                            if (TempEmail.Contains("@") && TempEmail.Contains("."))
                            {
                                CurrentUser.email = TempEmail;
                                Console.Clear();
                                break ;
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw wachtwoord in: ");
                            string TempPassword = Console.ReadLine();
                            if (TempPassword.Length >= 8) 
                            {
                                CurrentUser.password = TempPassword;
                                Console.Clear();
                                break;
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Uw wachtwoord moet langer zijn dat 8 characters)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 3:
                        while(true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw naam in: ");
                            string TempFirstName = Console.ReadLine();
                            if (TempFirstName.All(char.IsLetter))
                            { 
                                CurrentUser.first_name = TempFirstName;
                                Console.Clear();
                                break;
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                            string TempPrefix = Console.ReadLine();
                            if (!TempPrefix.All(char.IsNumber))
                            { 
                                CurrentUser.prefix = TempPrefix;
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        while (true) 
                        { 
                            Console.WriteLine();
                            Console.Write("    Vul uw achternaam in: ");
                            string TempLastName = Console.ReadLine();
                            if (TempLastName.All(char.IsLetter)) 
                            { 
                                CurrentUser.last_name = TempLastName;
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 5:
                        Console.Write("    Vul uw land in: ");
                        CurrentUser.country = Console.ReadLine();

                        Console.Clear();
                        break;
                    case 6:
                        while(true)
                        {
                            Console.WriteLine("    1: man");
                            Console.WriteLine("    2: vrouw");
                            Console.WriteLine();
                            Console.Write("    Maak een keuze: ");
                            string TempInput = Console.ReadLine();
                            if (TempInput == "1")
                            {
                                CurrentUser.gender = "man";
                                Console.Clear();
                                break;
                            }
                            else if(TempInput == "2")
                            {
                                CurrentUser.gender = "vrouw";
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 7:
                        while(true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw geboortedatum in als dd-mm-jjjj: ");
                            string TempBirthDate = Console.ReadLine();
                            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
                            DateTime scheduleDate;
                            bool validDate = DateTime.TryParseExact(
                            TempBirthDate,
                            dateFormats,
                            DateTimeFormatInfo.InvariantInfo,
                            DateTimeStyles.None,
                            out scheduleDate);
                            DateTime today = DateTime.Today;
                            if (validDate && today.Year - scheduleDate.Year >= 18) 
                            {
                                if (today.Year - scheduleDate.Year >= 18)
                                {
                                    CurrentUser.birth_date = TempBirthDate;
                                    Console.Clear();
                                    break;
                                }
                                else
                                { 
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("    Je moet achtien jaar en ouder zijn om een account aan te maken.");
                                    UserInterface.SetDefaultColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Invoer moet geschreven zijn in dd-mm-jjjj)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 8:
                        while (true) 
                        { 
                            Console.Write("    Vul uw telefoonnummer in: ");
                            string TempPhoneNumber = Console.ReadLine();
                            if (TempPhoneNumber.All(char.IsNumber) && TempPhoneNumber.Length == 10)
                            {
                                CurrentUser.phone_number = TempPhoneNumber;
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Uw invoer moet 10 characters lang zijn en uw mag alleen cijfers gebruiken)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 9:
                        if (CurrentUser.CheckNull()) 
                        {
                            List<Customer> temp = JSON.LoadCustomersJSON();
                            temp.Add(CurrentUser);
                            CurrentUser.GetNewUserID();
                            JSON.SaveCustomersJSON(temp);
                            CurrentUser.SetToDefault();
                            creating = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("    Niet alle velden zijn ingevuld.");
                        }
                        break;
                }
            }

        }
    }
}
