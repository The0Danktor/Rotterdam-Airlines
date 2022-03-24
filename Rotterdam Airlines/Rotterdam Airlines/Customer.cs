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
        public List<string> BookingList { get; set; }
        public bool IsGuest { get; set; }
        public Customer(string UserId, string email, string password, string first_name, string prefix, string last_name, string country, string gender, string birth_date, string phone_number, List<string> BookingList,bool IsGuest = false) : base(email, password)
        {
            this.UserId = UserId;
            this.email = email;
            this.password = password;
            this.first_name = first_name;
            this.prefix = prefix;
            this.last_name = last_name;
            this.country = country;
            this.gender = gender;
            this.birth_date = birth_date;
            this.phone_number = phone_number;
            this.BookingList = BookingList;
            this.IsGuest = IsGuest;
        }

        public bool CheckNull()
        {
            return this.first_name != null &&
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
            this.BookingList = new List<string> ();
            this.IsGuest= true;

        }
        private string getFullName()
        {
            return $"{first_name} {last_name}";
        }

        private void GetNewUserID()
        {
            this.UserId = IdHandler.getID();
        }

        static public object Login(Admin AdminUser , Customer CurrentUser)
        {
            
                string Email = "" ;
                string Password = "" ;
            while (true) 
            {
                UserInterface.PrintInlogMenu(Email,Password);
                string InlogInput = Console.ReadLine();
                int InlogChoice = int.Parse(InlogInput);
                bool UserFound = false;
                switch (InlogChoice)
                {
                    case 0:
                        return CurrentUser;
                    case 1:
                        Console.WriteLine();
                        UserInterface.SetMainColor();
                        Console.Write("    Vul uw email in: ");
                        UserInterface.SetDefaultColor();
                        Email = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine();
                        UserInterface.SetMainColor();
                        Console.Write("    Vul uw wachtwoord in: ");
                        UserInterface.SetDefaultColor();
                        Password = hiddenpassword(CurrentUser, "    Vul uw wachtwoord in: ", true, Email, Password);
                        Console.Clear();
                        break;

                    case 3:
                        List<Customer> Customers = JSON.LoadCustomersJSON();
                        if (Email == AdminUser.email && !UserFound)
                        {
                            UserFound = true;
                            if (AdminUser.password == Password)
                            {
                                return AdminUser;
                            }
                        }
                        else
                        {
                            foreach (Customer customer in Customers)
                            {
                                if (Email == customer.email)
                                {
                                    Customer TempUser = customer;
                                    UserFound = true;
                                    if (TempUser.password == Password)
                                    {
                                        return TempUser;
                                    }
                                }
                            }
                        }
                        if (!UserFound)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Geen gebruiker gevonden met dit emailadress Druk op een willekeurige toets om door te gaan ");
                            UserInterface.SetDefaultColor();
                            Console.ReadKey(true);
                        }
                        break;
                }
               }
           }

        static public string hiddenpassword(Customer CurrentUser, string question, bool inlog = false, string email = "" ,string password = "") 
        {
            string HiddenPassword = "";
            string hidden = "";
            while (true) 
            {
                var temp = Console.ReadKey(true);
                if (temp.Key != ConsoleKey.Enter && temp.Key != ConsoleKey.Backspace && temp.Key != ConsoleKey.Escape)
                {
                    HiddenPassword += temp.KeyChar;
                    hidden += "*";
                    Console.Write("*");
                }
                else if (temp.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return "break";
                }
                else if (temp.Key == ConsoleKey.Backspace)
                {
                    if (HiddenPassword.Length > 0)
                    {
                        HiddenPassword = HiddenPassword.Remove(HiddenPassword.Length - 1);
                        hidden = hidden.Remove(hidden.Length - 1);
                        Console.Clear();
                        if (!inlog)
                        {
                            UserInterface.PrintRegisterMenu(CurrentUser);
                        }
                        else
                        {
                            UserInterface.PrintInlogMenu(email, password);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        UserInterface.SetMainColor();
                        Console.Write(question);
                        UserInterface.SetDefaultColor();
                        Console.Write(hidden);
                    }
                }
                else
                {
                    Console.Clear();
                    return HiddenPassword;

                }
            }
        }

        public static void RegisterCustomer(Customer CurrentUser)

        {
            TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
            bool creating = true;
            while (creating)
            {

                UserInterface.PrintRegisterMenu(CurrentUser);

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
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw email in: ");
                            UserInterface.SetDefaultColor();
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
                        string TempPassword = "";
                        string Temp2Password = "";
                        bool secondeinput = true;
                        while (true)
                        {
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw wachtwoord in: ");
                            UserInterface.SetDefaultColor();
                            TempPassword = hiddenpassword(CurrentUser, "    Vul uw wachtwoord in: ");
                            if (TempPassword == "break") { secondeinput = false; break; }
                            else if (TempPassword.Length >= 8 ) 
                            {
                                break;
                            }
                            else 
                            {
                                UserInterface.PrintRegisterMenu(CurrentUser);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Uw wachtwoord moet langer zijn dat 8 characters)");
                                Console.WriteLine();
                                UserInterface.SetDefaultColor();
                            }
                        }
                        while (secondeinput)
                        {
                            UserInterface.PrintRegisterMenu(CurrentUser);
                            Console.WriteLine();
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Vul het zelfde wachtwoord in: ");
                            UserInterface.SetDefaultColor();
                            Temp2Password = hiddenpassword(CurrentUser, "    Vul het zelfde wachtwoord in: ");
                            if (Temp2Password == "break") { break;}
                            else if (TempPassword == Temp2Password)
                            {
                                CurrentUser.password = TempPassword;
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                UserInterface.PrintRegisterMenu(CurrentUser);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Het ingevoerde Wachtwoorden waren niet het zelfde)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 3:
                        while(true)
                        {
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw naam in: ");
                            UserInterface.SetDefaultColor();
                            string TempFirstName = Console.ReadLine();
                            if (TempFirstName.All(char.IsLetter))
                            { 
                                CurrentUser.first_name = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                            UserInterface.SetDefaultColor();
                            string TempPrefix = Console.ReadLine();
                            if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
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
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw achternaam in: ");
                            UserInterface.SetDefaultColor();
                            string TempLastName = Console.ReadLine();
                            if (TempLastName.All(char.IsLetter)) 
                            { 
                                CurrentUser.last_name = textInfo.ToTitleCase(TempLastName.ToLower());
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
                        UserInterface.SetMainColor();
                        Console.Write("    Vul uw land in: ");
                        UserInterface.SetDefaultColor();
                        CurrentUser.country = textInfo.ToTitleCase(Console.ReadLine().ToLower());

                        Console.Clear();
                        break;
                    case 6:
                        while(true)
                        {
                            Console.WriteLine("    [1] Man");
                            Console.WriteLine("    [2] Vrouw");
                            Console.WriteLine("    [3] Overig");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();
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
                            else if(TempInput == "3")
                            {
                                CurrentUser.gender = "overig";
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
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw geboortedatum in als dd-mm-jjjj: ");
                            UserInterface.SetDefaultColor();
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
                            if (validDate) 
                            {
                                if ((today.Subtract(scheduleDate).Days/365.242199) >= 18)
                                {
                                    CurrentUser.birth_date = TempBirthDate;
                                    Console.Clear();
                                    break;
                                }
                                else
                                { 
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("    Je moet achtien jaar en ouder zijn om een account aan te maken Druk op een willekeurige toets om door te gaan.");
                                    UserInterface.SetDefaultColor();
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    break;
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
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Vul uw telefoonnummer in: ");
                            UserInterface.SetDefaultColor();
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
                            CurrentUser.IsGuest = false;
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
