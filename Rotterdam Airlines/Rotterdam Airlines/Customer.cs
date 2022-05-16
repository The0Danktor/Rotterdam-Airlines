using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;


namespace Rotterdam_Airlines
{
    class Customer : User
    {
        public string UserId { get; set; }
        public string First_name { get; set; }
        public string Prefix { get; set; }
        public string Last_name { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Birth_date { get; set; }
        public string Phone_number { get; set; }
        public List<string> BookingList { get; set; }
        public bool IsGuest { get; set; }
        public Customer(string UserId, string email, string password, string first_name, string prefix, string last_name, string country, string gender, string birth_date, string phone_number, List<string> BookingList,bool IsGuest = false) : base(email, password)
        {
            this.UserId = UserId;
            this.Email = email;
            this.Password = password;
            this.First_name = first_name;
            this.Prefix = prefix;
            this.Last_name = last_name;
            this.Country = country;
            this.Gender = gender;
            this.Birth_date = birth_date;
            this.Phone_number = phone_number;
            this.BookingList = BookingList;
            this.IsGuest = IsGuest;
        }

        public bool CheckNull()
        {
            return this.First_name != null &&
                   this.Prefix != null &&
                   this.Last_name != null &&
                   this.Country != null &&
                   this.Gender != null &&
                   this.Birth_date != null &&
                   this.Phone_number != null &&
                   this.Email != null &&
                   this.Password != null;
        }
        public void SetToDefault()
        {
            this.UserId = null;
            this.First_name = null;
            this.Prefix=null;
            this.Last_name = null;
            this.Country = null;
            this.Gender = null;
            this.Birth_date = null;
            this.Phone_number = null;
            this.Email = null;
            this.Password = null;
            this.BookingList = new List<string> ();
            this.IsGuest= true;

        }
        private string GetFullName()
        {
            return $"{First_name} {Last_name}";
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
                Console.Clear();
                UserInterface.PrintInlogMenu(Email,Password);
                int InlogChoice = 100;
                try { InlogChoice = int.Parse(Console.ReadLine()); } catch { }
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
                        Password = Hiddenpassword(CurrentUser, "    Vul uw wachtwoord in: ", true, Email, Password);
                        Console.Clear();
                        break;

                    case 3:
                        List<Customer> Customers = JSON.LoadCustomersJSON();
                        if (Email == AdminUser.Email && !UserFound)
                        {
                            UserFound = true;
                            if (AdminUser.Password == Password)
                            {
                                return AdminUser;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("    Verkeerd wachtwoord ingevuld Druk op een willekeurige toets om door te gaan ");
                                UserInterface.SetDefaultColor();
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                        }
                        else
                        {
                            foreach (Customer customer in Customers)
                            {
                                if (Email == customer.Email)
                                {
                                    Customer TempUser = customer;
                                    UserFound = true;
                                    if (TempUser.Password == Password)
                                    {
                                        return TempUser;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("    Verkeerd wachtwoord ingevuld Druk op een willekeurige toets om door te gaan ");
                                        UserInterface.SetDefaultColor();
                                        Console.ReadKey(true);
                                        Console.Clear();
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
                            Console.Clear();
                        }
                        break;
                }
               }
           }

        static public string Hiddenpassword(Customer CurrentUser, string question, bool inlog = false, string email = "" ,string password = "")
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
            bool EmailExists(string email)
            {
                bool EmailExists = false;
                List<Customer> customers = JSON.LoadCustomersJSON();
                for (int i = 0; i < customers.Count; i++)
                {
                    if(customers[i].Email == email)
                    {
                        EmailExists = true;
                        break;
                    }
                }
                return EmailExists;
            }

            TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
            bool creating = true;
            while (creating)
            {
                Console.Clear();
                UserInterface.PrintRegisterMenu(CurrentUser);
                int register_choice = 100;
                try { register_choice = int.Parse(Console.ReadLine()); } catch { }
                switch (register_choice)
                {
                    case 0:
                        CurrentUser.SetToDefault();
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

                            try
                            {
                                if (EmailExists(TempEmail))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine();
                                    Console.WriteLine("    Er bestaat al een account met deze email. Vul een andere email in.");
                                    UserInterface.SetDefaultColor();
                                } else
                                {
                                    if (TempEmail.Contains("@") && TempEmail.Contains("."))
                                    {
                                        CurrentUser.Email = TempEmail;
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                        UserInterface.SetDefaultColor();
                                    }
                                }
                            } catch 
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
                            TempPassword = Hiddenpassword(CurrentUser, "    Vul uw wachtwoord in: ");
                            if (TempPassword == "break") { secondeinput = false; break; }
                            else if (TempPassword.Length >= 8 ) 
                            {
                                break;
                            }
                            else 
                            {
                                UserInterface.PrintRegisterMenu(CurrentUser);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Uw wachtwoord moet langer zijn dat 8 characters)");
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
                            Temp2Password = Hiddenpassword(CurrentUser, "    Vul het zelfde wachtwoord in: ");
                            if (Temp2Password == "break") { break;}
                            else if (TempPassword == Temp2Password)
                            {
                                CurrentUser.Password = TempPassword;
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                UserInterface.PrintRegisterMenu(CurrentUser);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("    Onjuiste invoer. De ingevoerde wachtwoorden waren niet hetzelfde.\n    Klik op ENTER om het opnieuw te proberen.");
                                UserInterface.SetDefaultColor();
                                Console.ReadKey();
                                Console.Clear();
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
                                CurrentUser.First_name = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                CurrentUser.Prefix = TempPrefix;
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
                                CurrentUser.Last_name = textInfo.ToTitleCase(TempLastName.ToLower());
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        break;
                    case 5:
                        while(true)
                        {
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.Write("    Vul uw land in: ");
                            UserInterface.SetDefaultColor();
                            string InputCountry = Console.ReadLine();
                            InputCountry = InputCountry.ToLower();
                            InputCountry = textInfo.ToTitleCase(InputCountry);
                            if(InputCountry.Any(char.IsDigit))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                UserInterface.SetDefaultColor();
                            } else
                            {
                                CurrentUser.Country = InputCountry;
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    case 6:
                        while(true)
                        {
                            Console.WriteLine();
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
                                CurrentUser.Gender = "Man";
                                Console.Clear();
                                break;
                            }
                            else if(TempInput == "2")
                            {
                                CurrentUser.Gender = "Vrouw";
                                Console.Clear();
                                break;
                            }
                            else if(TempInput == "3")
                            {
                                CurrentUser.Gender = "Overig";
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
                                    CurrentUser.Birth_date = TempBirthDate;
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
                                CurrentUser.Phone_number = TempPhoneNumber;
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

        public static void BookFlight(Admin AdminUser ,Customer CurrentUser)
        {
            
            bool BookingFlight = true;
            string[][] BookingSteps = GenerateBookingSteps();

            // BOOKING INFO
            string[] BookingSelectedLuggage;
            List<BookingPerson> BookingPersonData = new List<BookingPerson>();
            if (CurrentUser.IsGuest)
            {
                bool chaning_account = true;
                Customer OldUser = CurrentUser;
                while (chaning_account)
                {

                    Console.Clear();
                    UserInterface.PrintLogo();
                    UserInterface.SetMainColor();
                    Console.WriteLine("    Rotterdam Airlines | Vlucht Boeken");
                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                    Console.WriteLine();
                    UserInterface.SetDefaultColor();
                    Console.WriteLine("    [1] Inloggen");
                    Console.WriteLine("    [2] Registreren");
                    Console.WriteLine("    [3] Verder gaan als gast");
                    Console.WriteLine();
                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                    UserInterface.SetMainColor();
                    Console.Write("    Maak een keuze: ");
                    UserInterface.SetDefaultColor();
                    int InputContactGegevens = 100;
                    try { InputContactGegevens = int.Parse(Console.ReadLine()); } catch { }
                    switch (InputContactGegevens)
                    {
                        case 1:
                            CurrentUser = (Customer)Login(AdminUser, CurrentUser);
                            if (!(CurrentUser == OldUser))
                            {
                                chaning_account = false;
                            }
                            break;
                        case 2:
                            var oldtemp = JSON.LoadCustomersJSON();
                            RegisterCustomer(CurrentUser);
                            var temp = JSON.LoadCustomersJSON();
                            if (!(temp.Count == oldtemp.Count))
                            {
                                CurrentUser = temp[temp.Count - 1];
                                chaning_account = false;
                            }
                            break;
                        case 3:
                            chaning_account = false;
                            break;
                    }
                }
            }
            Customer BookingCustomer = CurrentUser;
            Flight BookingSelectedFlight = null;
            bool FlightSelected = false;
            TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;

            List<Flight> AllFlights = Flight.GetFlights();
            List<Flight> FilteredFlights = Flight.GetFlights();
            List<string> FlightDestinations = Flight.GetFlightDestinations();

            // FILTERS
            Hashtable Filters = new Hashtable()
            {
                {"Bestemming", ""},
                {"Datum", "" },
                {"Aantal Personen", 1},
                {"Maximum Prijs", 1000}
            };

            // LOCAL FUNCTIONS
            string[][] GenerateBookingSteps()
            {
                string[][] GenerateBookingSteps =
                {
                new string[] { "Vlucht Selecteren", "X" },
                new string[] { "Persoonsgegevens", "X" },
                new string[] { "Contactgegevens", "X" },
                new string[] { "Bagage", "X" },
                new string[] { "Stoelen", "X" },
                new string[] { "Bevestigen", "X" }
                };

                return GenerateBookingSteps;
            }

            void PrintBookingStatus()
            {
                UserInterface.SetMainColor();
                Console.Write("    Vlucht Boeken | ");
                for(int i = 0; i < BookingSteps.Length; i++)
                {
                    if(BookingSteps[i][1] == "Y")
                    {
                        UserInterface.SetMainColor();
                        Console.Write(BookingSteps[i][0]);
                        UserInterface.SetDefaultColor();
                        if(i != BookingSteps.Length - 1) { Console.Write(" - "); }
                    } else
                    {
                        UserInterface.SetDefaultColor();
                        Console.Write(BookingSteps[i][0]);
                        if (i != BookingSteps.Length - 1) { Console.Write(" - "); }
                    }
                }
            }

            bool BackToMainMenu()
            {
                Console.WriteLine();
                UserInterface.SetErrorColor();
                Console.WriteLine("    Weet je zeker dat je terug naar het hoofdmenu wilt gaan?\n    Je boeking wordt niet opgeslagen!");
                UserInterface.SetDefaultColor();
                Console.WriteLine();
                Console.WriteLine("    [0] Nee");
                Console.WriteLine("    [1] Ja");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();
                int InputConfirm = 100;
                try { InputConfirm = int.Parse(Console.ReadLine()); } catch { }
                if (InputConfirm == 1)
                {
                    return false;
                } else
                {
                    return true;
                }
            }

            void PrintFlightOverview()
            {
                if(FlightSelected == true)
                {
                    CultureInfo Dutch = new CultureInfo("nl-NL", false);
                    TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
                    DateTime DepartureInfo = BookingSelectedFlight.Departure;
                    string Departure = DepartureInfo.ToString("MMMM", Dutch);
                    Departure = textInfo.ToTitleCase(Departure);
                    UserInterface.SetMainColor();
                    Console.WriteLine("    Vluchtcode    Vluchtnummer     Bestemming           Vertrek");
                    UserInterface.SetDefaultColor();
                    Console.WriteLine();
                    Console.WriteLine("    " + BookingSelectedFlight.FlightCode + "\t  " + BookingSelectedFlight.FlightNumber + "\t   " + BookingSelectedFlight.Destination + " \t\t" + DepartureInfo.Day + " " + Departure + " " + DepartureInfo.TimeOfDay + "\t< Gekozen Vlucht");
                    Console.WriteLine();
                    Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine();
                }
            }

            // BOOK FLIGHT MENU
            while (BookingFlight)
            {       
            if (BookingSelectedFlight != null && !CurrentUser.IsGuest && BookingPersonData.Count == 0) { BookingPersonData.Add(new BookingPerson(BookingSelectedFlight.FlightCode, CurrentUser.First_name, CurrentUser.Prefix, CurrentUser.Last_name, CurrentUser.Birth_date, CurrentUser.Gender, CurrentUser.Country)); }
                Console.Clear();
                UserInterface.SetDefaultColor();
                UserInterface.PrintLogo();
                PrintBookingStatus();
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                UserInterface.SetDefaultColor();
                Console.WriteLine();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Vlucht Selecteren");
                Console.WriteLine("    [2] Persoonsgegevens");
                Console.WriteLine("    [3] Contactgegevens");
                Console.WriteLine("    [4] Bagage Toevoegen");
                Console.WriteLine("    [5] Stoelen Kiezen");
                Console.WriteLine();
                Console.WriteLine("    [6] Boeking Overzicht");
                Console.WriteLine("    [7] Boeking Bevestigen");
                Console.WriteLine();
                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                PrintFlightOverview();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();

                int Input = 100;

                try { Input = int.Parse(Console.ReadLine()); } catch { }

                switch (Input)
                {
                    // HOOFDMENU
                    case 0:
                        BookingFlight = BackToMainMenu();
                        Console.Clear();
                        break;

                    // VLUCHT SELECTEREN
                    case 1:
                        BookingSteps[0][1] = "Y";
                        bool SelectingFlight = true;
                        int CurrentPage = 0;
                        double MaxPagesDec = FilteredFlights.Count / 10;
                        int MaxPages = (int)Math.Ceiling(MaxPagesDec);
                        void PrintFlightsOverview()
                        {
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Vluchtcode    Vluchtnummer     Bestemming           Vertrek                              Pagina " + (CurrentPage + 1) + "/" + (MaxPages + 1));
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();

                            for (int i = 0; i < 10; i++)
                            {
                                int index = i + (CurrentPage * 10);
                                try
                                {
                                    CultureInfo Dutch = new CultureInfo("nl-NL", false);
                                    TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
                                    DateTime DepartureInfo = FilteredFlights[index].Departure;
                                    string Departure = DepartureInfo.ToString("MMMM", Dutch);
                                    Departure = textInfo.ToTitleCase(Departure);
                                    Console.WriteLine("    " + FilteredFlights[index].FlightCode + "\t  " + FilteredFlights[index].FlightNumber + "\t   " + FilteredFlights[index].Destination + " \t\t" + DepartureInfo.Day + " " + Departure + " " + DepartureInfo.TimeOfDay);
                                }
                                catch (System.ArgumentOutOfRangeException)
                                {
                                    Console.Write("");
                                }
                            }
                        }

                        while (SelectingFlight)
                        {
                            FilteredFlights = FilterHandler.filterList(AllFlights, Filters, "");
                            MaxPagesDec = FilteredFlights.Count / 10;
                            MaxPages = (int)Math.Ceiling(MaxPagesDec);
                            Console.Clear();
                            UserInterface.SetDefaultColor();
                            UserInterface.PrintLogo();
                            PrintBookingStatus();
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            Console.WriteLine();
                            Console.WriteLine("    [0] Hoofdmenu");
                            Console.WriteLine("    [1] Terug");
                            Console.WriteLine();
                            Console.WriteLine("    [2] Filters Aanpassen");
                            Console.WriteLine("    [3] Sorteren");
                            Console.WriteLine("    [4] Vorige Pagina");
                            Console.WriteLine("    [5] Volgende Pagina");
                            Console.WriteLine();
                            Console.WriteLine("    [6] Vluchtcode Invoeren");
                            Console.WriteLine();
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            PrintFlightsOverview();
                            Console.WriteLine("");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine("");
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();

                            int InputSelectFlight = 100;
                            try { InputSelectFlight = int.Parse(Console.ReadLine()); } catch { }

                            switch (InputSelectFlight)
                            {
                                case 0:
                                    SelectingFlight = BackToMainMenu();
                                    BookingFlight = SelectingFlight;
                                    Console.Clear();
                                    break;

                                case 1:
                                    SelectingFlight = false;
                                    BookingSteps[0][1] = "X";
                                    Console.Clear();
                                    break;

                                case 2:
                                    bool ChangingFilters = true;
                                    while (ChangingFilters)
                                    {
                                        Console.Clear();
                                        UserInterface.SetDefaultColor();
                                        UserInterface.PrintLogo();
                                        PrintBookingStatus();
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                        UserInterface.SetDefaultColor();
                                        Console.WriteLine();
                                        Console.WriteLine("    [0] Hoofdmenu");
                                        Console.WriteLine("    [1] Terug");
                                        Console.WriteLine();
                                        Console.WriteLine("    [2] Bestemming           " + Filters["Bestemming"]);
                                        Console.WriteLine("    [3] Datum                " + Filters["Datum"]);
                                        Console.WriteLine("    [4] Aantal Personen      " + Filters["Aantal Personen"]);
                                        Console.WriteLine("    [5] Maximum Prijs        " + Filters["Maximum Prijs"]);
                                        Console.WriteLine();
                                        Console.WriteLine("    [6] Filters Resetten");
                                        Console.WriteLine("    [7] Filters Bevestigen");
                                        Console.WriteLine();
                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Maak een keuze: ");
                                        UserInterface.SetDefaultColor();

                                        int InputSelectFlightFilter = 100;
                                        try { InputSelectFlightFilter = int.Parse(Console.ReadLine()); } catch { }

                                        switch (InputSelectFlightFilter)
                                        {
                                            case 0:
                                                ChangingFilters = BackToMainMenu();
                                                SelectingFlight = ChangingFilters;
                                                BookingFlight = ChangingFilters;
                                                Console.Clear();
                                                break;
                                            case 1:
                                                ChangingFilters = false;
                                                Console.Clear();
                                                break;
                                            case 2:
                                                bool EnteringDestination = true;
                                                Console.WriteLine();
                                                UserInterface.SetMainColor();
                                                Console.WriteLine("    Bestemmingen:");
                                                UserInterface.SetDefaultColor();
                                                Console.Write("    ");
                                                for (int i = 0; i < FlightDestinations.Count; i++)
                                                {
                                                    Console.Write(FlightDestinations[i]);
                                                    if (i != FlightDestinations.Count - 1) { Console.Write(", "); } else { Console.Write("."); }
                                                    if (i == 10 || i == 20 || i == 30) { Console.WriteLine(); Console.Write("    "); }
                                                }
                                                Console.WriteLine();
                                                while (EnteringDestination)
                                                {
                                                    UserInterface.SetMainColor();
                                                    Console.WriteLine();
                                                    Console.Write("    Kies een bestemming: ");
                                                    UserInterface.SetDefaultColor();
                                                    string InputDestination = Console.ReadLine();
                                                    InputDestination = InputDestination.ToLower();
                                                    InputDestination = textInfo.ToTitleCase(InputDestination);
                                                    if (FlightDestinations.Contains(InputDestination)) { Filters["Bestemming"] = InputDestination; EnteringDestination = false; }
                                                    else
                                                    {
                                                        UserInterface.SetErrorColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    De ingevoerde bestemming is niet gevonden!");
                                                        UserInterface.SetDefaultColor();
                                                    }
                                                }

                                                Console.Clear();
                                                break;

                                            case 3:
                                                bool EnteringDate = true;
                                                while(EnteringDate)
                                                {
                                                    Console.WriteLine();
                                                    UserInterface.SetMainColor();
                                                    Console.Write("    Kies een datum (DD-MM-JJJJ): ");
                                                    UserInterface.SetDefaultColor();
                                                    string InputDate = Console.ReadLine();
                                                    DateTime dDate;
                                                    if (DateTime.TryParse(InputDate, out dDate)) { Filters["Datum"] = InputDate; EnteringDate = false; }
                                                    else
                                                    {
                                                        UserInterface.SetErrorColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    De ingevoerde datum is niet correct. Heeft u het correcte format gebruikt? (DD-MM-JJJJ)");
                                                        UserInterface.SetDefaultColor();
                                                    }
                                                }


                                                Console.Clear();
                                                break;
                                            case 4:
                                                bool EnteringPersons = true;
                                                while(EnteringPersons)
                                                {
                                                    Console.WriteLine();
                                                    UserInterface.SetMainColor();
                                                    Console.Write("    Kies het aantal personen: ");
                                                    UserInterface.SetDefaultColor();
                                                    string InputPersons = Console.ReadLine();
                                                    try
                                                    {
                                                        if (Int32.Parse(InputPersons) < 5) { Filters["Aantal Personen"] = Int32.Parse(InputPersons); EnteringPersons = false;}
                                                        else
                                                        {
                                                            UserInterface.SetErrorColor();
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt voor maximaal 4 personen tegelijk boeken.");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        UserInterface.SetErrorColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt alleen een nummer invoeren.");
                                                        UserInterface.SetDefaultColor();
                                                    }
                                                }

                                                Console.Clear();
                                                break;
                                            case 5:
                                                bool EnteringPrice = true;
                                                while (EnteringPrice)
                                                {
                                                Console.WriteLine();
                                                UserInterface.SetMainColor();
                                                Console.Write("    Kies een maximumprijs: ");
                                                UserInterface.SetDefaultColor();
                                                string InputPrice = Console.ReadLine();

                                                    try { Filters["Maximum Prijs"] = Int32.Parse(InputPrice); EnteringPrice = false; }
                                                    catch
                                                    {
                                                        UserInterface.SetErrorColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    De ingevoerde prijs is niet correct. U kunt alleen een nummer invoeren.");
                                                        UserInterface.SetDefaultColor();
                                                    }
                                                }
                                                Console.Clear();
                                                break;
                                            case 6:
                                                Filters["Bestemming"] = "";
                                                Filters["Datum"] = "";
                                                Filters["Aantal Personen"] = 1;
                                                Filters["Maximum Prijs"] = 1000;
                                                Console.Clear();
                                                break;
                                            case 7:
                                                ChangingFilters = false;
                                                Console.Clear();
                                                break;
                                            default:
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    CurrentPage = 0;
                                    Console.Clear();
                                    break;

                                // SORTEREN
                                case 3:
                                    break;
                                
                                // VORIGE PAGINA
                                case 4:
                                    if (CurrentPage != 0) {CurrentPage--;} else {CurrentPage = MaxPages;} Console.Clear();
                                    break;
                                
                                // VOLGENDE PAGINA
                                case 5:
                                    if (CurrentPage + 1 > MaxPages) {CurrentPage = 0;} else {CurrentPage++;} Console.Clear();
                                    break;

                                case 6:
                                    bool EnteringFlightCode = true;
                                    while(EnteringFlightCode)
                                    {
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Vul een vluchtcode in: ");
                                        UserInterface.SetDefaultColor();
                                        string InputFlightCode = Console.ReadLine();
                                        if(Flight.FlightExists(InputFlightCode))
                                        {
                                            int index = Flight.GetFlightIndex(InputFlightCode);
                                            BookingSelectedFlight = Flight.Flights[index];
                                            FlightSelected = true;
                                            EnteringFlightCode = false;
                                            SelectingFlight = false;
                                        } else
                                        {
                                            UserInterface.SetErrorColor();
                                            Console.WriteLine();
                                            Console.WriteLine("    De ingevoerde vluchtcode is niet gevonden! Probeer het opnieuw.");
                                            UserInterface.SetDefaultColor();
                                        }

                                        // CHECK IF INPUT IS CORRECT AND ASSIGN FLIGHT TO BOOKINGSELECTEDFLIGHT
                                    }

                                    Console.Clear();
                                    break;

                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        BookingSteps[0][1] = "X";
                        Console.Clear();
                        break;
                    //PERSOONS GEGEVENS INVULLEN
                    case 2:
                        BookingSteps[1][1] = "Y";
                        bool ChangingPersoons = true;
                        if(BookingSelectedFlight == null) 
                        {
                            UserInterface.SetErrorColor();
                            Console.WriteLine("    Je moet eerst een vlucht selecteren");
                            UserInterface.SetDefaultColor();
                            Console.ReadKey(true);
                            break;
                        }
                        while (ChangingPersoons)
                        {   

                            if ((int)Filters["Aantal Personen"] == 1)
                            {
                                if(BookingPersonData.Count == 0) { BookingPersonData.Add(new BookingPerson(null, null, null, null, null, null, null));}
                                if (BookingPersonData.Count > 1) 
                                { 
                                    for (int i = BookingPersonData.Count - 1; i >= 1; i--)
                                    {
                                        BookingPersonData.RemoveAt(i);
                                    }
                                }
                                Console.Clear();
                                UserInterface.PrintLogo();
                                PrintBookingStatus();
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                UserInterface.SetDefaultColor();
                                Console.WriteLine();
                                Console.WriteLine($"    [0] Hoofdmenu");
                                Console.WriteLine($"    [1] Terug");
                                Console.WriteLine();
                                Console.WriteLine($"    [2] Aantal Personen                - {Filters["Aantal Personen"]}");
                                Console.WriteLine();
                                Console.WriteLine($"    [3] Voornaam                       - {BookingPersonData[0].CustomerFirstName}");
                                if (BookingPersonData[0].CustomerMiddleName == null || BookingPersonData[0].CustomerMiddleName == "") { Console.WriteLine($"    [4] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName} {BookingPersonData[0].CustomerMiddleName}"); }
                                else {Console.WriteLine($"    [4] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName}, {BookingPersonData[0].CustomerMiddleName}"); }
                                Console.WriteLine($"    [5] Land                           - {BookingPersonData[0].CustomerCountry}");
                                Console.WriteLine($"    [6] Geslacht                       - {BookingPersonData[0].CustomerGender}");
                                Console.WriteLine($"    [7] Geboortedatum                  - {BookingPersonData[0].CustomerBirthDate}");
                                Console.WriteLine();
                                Console.WriteLine($"    [8] Bevestigen");
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                                int InputPersoonsgegevens = 100;
                                try { InputPersoonsgegevens = int.Parse(Console.ReadLine()); } catch { }
                                switch (InputPersoonsgegevens)
                                {
                                    case 0:
                                        BookingFlight = BackToMainMenu();
                                        ChangingPersoons = false;
                                        Console.Clear();
                                        break;
                                    case 1:
                                        ChangingPersoons = false;
                                        break;
                                    case 2:
                                        bool EnteringPersons = true;
                                        while (EnteringPersons)
                                        {
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Kies het aantal personen: ");
                                            UserInterface.SetDefaultColor();
                                            string InputPersons = Console.ReadLine();
                                            try
                                            {
                                                if (Int32.Parse(InputPersons) < 5) { Filters["Aantal Personen"] = Int32.Parse(InputPersons); EnteringPersons = false; }
                                                else
                                                {
                                                    UserInterface.SetErrorColor();
                                                    Console.WriteLine();
                                                    Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt voor maximaal 4 personen tegelijk boeken.");
                                                    UserInterface.SetDefaultColor();
                                                }
                                            }
                                            catch
                                            {
                                                UserInterface.SetErrorColor();
                                                Console.WriteLine();
                                                Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt alleen een nummer invoeren.");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Vul uw naam in: ");
                                            UserInterface.SetDefaultColor();
                                            string TempFirstName = Console.ReadLine();
                                            if (TempFirstName.All(char.IsLetter))
                                            {
                                                BookingPersonData[0].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                BookingPersonData[0].CustomerMiddleName = TempPrefix;
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
                                                BookingPersonData[0].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine();
                                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 5:
                                        while (true)
                                        {
                                            UserInterface.SetMainColor();
                                            Console.WriteLine();
                                            Console.Write("    Vul uw land in: ");
                                            UserInterface.SetDefaultColor();
                                            string InputCountry = Console.ReadLine();
                                            InputCountry = InputCountry.ToLower();
                                            InputCountry = textInfo.ToTitleCase(InputCountry);
                                            if (InputCountry.Any(char.IsDigit))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine();
                                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                UserInterface.SetDefaultColor();
                                            }
                                            else
                                            {
                                                BookingPersonData[0].CustomerCountry = InputCountry;
                                                break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 6:
                                        while (true)
                                        {
                                            Console.WriteLine();
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
                                                BookingPersonData[0].CustomerGender = "Man";
                                                Console.Clear();
                                                break;
                                            }
                                            else if (TempInput == "2")
                                            {
                                                BookingPersonData[0].CustomerGender = "Vrouw";
                                                Console.Clear();
                                                break;
                                            }
                                            else if (TempInput == "3")
                                            {
                                                BookingPersonData[0].CustomerGender = "Overig";
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 7:
                                        while (true)
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
                                                if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                {
                                                    BookingPersonData[0].CustomerBirthDate = TempBirthDate;
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
                                        ChangingPersoons = false;
                                        break;
                                }
                            }
                            else if ((int)Filters["Aantal Personen"] == 2)
                            {
                                if (BookingPersonData.Count < 2)
                                {
                                    for (int i = BookingPersonData.Count; i < 2; i++)
                                    {
                                        BookingPersonData.Add(new BookingPerson(null, null, null, null, null, null, null)); 
                                    }
                                }
                                if (BookingPersonData.Count > 2)
                                {
                                    for (int i = BookingPersonData.Count -1; i >= 2; i--)
                                    {
                                        BookingPersonData.RemoveAt(i);
                                    }
                                }
                                Console.Clear();
                                UserInterface.PrintLogo();
                                PrintBookingStatus();
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                UserInterface.SetDefaultColor();
                                Console.WriteLine();
                                Console.WriteLine($"    [0] Hoofdmenu");
                                Console.WriteLine($"    [1] Terug");
                                Console.WriteLine();
                                Console.WriteLine($"    [2] Aantal Personen                - {Filters["Aantal Personen"]}");
                                Console.WriteLine();
                                Console.WriteLine($"    [3] Persoon 1");
                                Console.WriteLine($"    [4] Persoon 2");
                                Console.WriteLine();
                                Console.WriteLine($"    [5] Bevestigen");
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                                int InputPersoonsgegevens = 100;
                                try { InputPersoonsgegevens = int.Parse(Console.ReadLine()); } catch { }
                                switch (InputPersoonsgegevens)
                                {
                                    case 0:
                                        BookingFlight = BackToMainMenu();
                                        ChangingPersoons = false;
                                        Console.Clear();
                                        break;
                                    case 1:
                                        ChangingPersoons = false;
                                        break;
                                    case 2:
                                        bool EnteringPersons = true;
                                        while (EnteringPersons)
                                        {
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Kies het aantal personen: ");
                                            UserInterface.SetDefaultColor();
                                            string InputPersons = Console.ReadLine();
                                            try
                                            {
                                                if (Int32.Parse(InputPersons) < 5) { Filters["Aantal Personen"] = Int32.Parse(InputPersons); EnteringPersons = false; }
                                                else
                                                {
                                                    UserInterface.SetErrorColor();
                                                    Console.WriteLine();
                                                    Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt voor maximaal 4 personen tegelijk boeken.");
                                                    UserInterface.SetDefaultColor();
                                                }
                                            }
                                            catch
                                            {
                                                UserInterface.SetErrorColor();
                                                Console.WriteLine();
                                                Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt alleen een nummer invoeren.");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 3:
                                        bool ChangingPersoon1 = true;
                                        while (ChangingPersoon1)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[0].CustomerFirstName}");
                                            if (BookingPersonData[0].CustomerMiddleName == null || BookingPersonData[0].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName} {BookingPersonData[0].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    " +$"[3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName}, {BookingPersonData[0].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[0].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[0].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[0].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[0].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon1gegevens = 100;
                                            try { InputPersoon1gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon1gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon1 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[0].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[0].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[0].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[0].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[0].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[0].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[0].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        bool ChangingPersoon2 = true;
                                        while (ChangingPersoon2)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[1].CustomerFirstName}");
                                            if (BookingPersonData[1].CustomerMiddleName == null || BookingPersonData[1].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName} {BookingPersonData[1].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName}, {BookingPersonData[1].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[1].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[1].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[1].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[1].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon2 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[1].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[1].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[1].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[1].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[1].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[1].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[1].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        ChangingPersoons = false;
                                        break;
                                }
                            }
                            else if ((int)Filters["Aantal Personen"] == 3)
                            {
                                if (BookingPersonData.Count < 3)
                                {
                                    for (int i = BookingPersonData.Count; i < 3; i++)
                                    {
                                        BookingPersonData.Add(new BookingPerson(null, null, null, null, null, null, null));
                                    }
                                }
                                if (BookingPersonData.Count > 3)
                                {
                                    for (int i = BookingPersonData.Count -1; i >= 3; i--)
                                    {
                                        BookingPersonData.RemoveAt(i);
                                    }
                                }
                                Console.Clear();
                                UserInterface.PrintLogo();
                                PrintBookingStatus();
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                UserInterface.SetDefaultColor();
                                Console.WriteLine();
                                Console.WriteLine($"    [0] Hoofdmenu");
                                Console.WriteLine($"    [1] Terug");
                                Console.WriteLine();
                                Console.WriteLine($"    [2] Aantal Personen                - {Filters["Aantal Personen"]}");
                                Console.WriteLine();
                                Console.WriteLine($"    [3] Persoon 1");
                                Console.WriteLine($"    [4] Persoon 2");
                                Console.WriteLine($"    [5] Persoon 3");
                                Console.WriteLine();
                                Console.WriteLine($"    [6] Bevestigen");
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                                int InputPersoonsgegevens = 100;
                                try { InputPersoonsgegevens = int.Parse(Console.ReadLine()); } catch { }
                                switch (InputPersoonsgegevens)
                                {
                                    case 0:
                                        BookingFlight = BackToMainMenu();
                                        ChangingPersoons = false;
                                        Console.Clear();
                                        break;
                                    case 1:
                                        ChangingPersoons = false;
                                        break;
                                    case 2:
                                        bool EnteringPersons = true;
                                        while (EnteringPersons)
                                        {
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Kies het aantal personen: ");
                                            UserInterface.SetDefaultColor();
                                            string InputPersons = Console.ReadLine();
                                            try
                                            {
                                                if (Int32.Parse(InputPersons) < 5) { Filters["Aantal Personen"] = Int32.Parse(InputPersons); EnteringPersons = false; }
                                                else
                                                {
                                                    UserInterface.SetErrorColor();
                                                    Console.WriteLine();
                                                    Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt voor maximaal 4 personen tegelijk boeken.");
                                                    UserInterface.SetDefaultColor();
                                                }
                                            }
                                            catch
                                            {
                                                UserInterface.SetErrorColor();
                                                Console.WriteLine();
                                                Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt alleen een nummer invoeren.");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 3:
                                        bool ChangingPersoon1 = true;
                                        while (ChangingPersoon1)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[0].CustomerFirstName}");
                                            if (BookingPersonData[0].CustomerMiddleName == null || BookingPersonData[0].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName} {BookingPersonData[0].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    " + $"[3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName}, {BookingPersonData[0].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[0].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[0].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[0].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[0].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon1gegevens = 100;
                                            try { InputPersoon1gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon1gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon1 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[0].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[0].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[0].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[0].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[0].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[0].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[0].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        bool ChangingPersoon2 = true;
                                        while (ChangingPersoon2)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[1].CustomerFirstName}");
                                            if (BookingPersonData[1].CustomerMiddleName == null || BookingPersonData[1].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName} {BookingPersonData[1].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName}, {BookingPersonData[1].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[1].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[1].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[1].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[1].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon2 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[1].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[1].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[1].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[1].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[1].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[1].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[1].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        bool ChangingPersoon3 = true;
                                        while (ChangingPersoon3)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[2].CustomerFirstName}");
                                            if (BookingPersonData[2].CustomerMiddleName == null || BookingPersonData[2].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[2].CustomerLastName} {BookingPersonData[2].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[2].CustomerLastName}, {BookingPersonData[2].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[2].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[2].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[2].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[2].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon3 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[2].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[2].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[2].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[2].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[2].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[2].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[2].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[2].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[2].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 6:
                                        ChangingPersoons = false;
                                        break;
                                }
                            }
                            else if ((int)Filters["Aantal Personen"] == 4)
                            {
                                if (BookingPersonData.Count < 4)
                                {
                                    for (int i = BookingPersonData.Count; i < 4; i++)
                                    {
                                        BookingPersonData.Add(new BookingPerson(null, null, null, null, null, null, null));
                                    }
                                }
                                if (BookingPersonData.Count > 4)
                                {
                                    for (int i = BookingPersonData.Count - 1; i >= 4; i--)
                                    {
                                        BookingPersonData.RemoveAt(i);
                                    }
                                }
                                Console.Clear();
                                UserInterface.PrintLogo();
                                PrintBookingStatus();
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                UserInterface.SetDefaultColor();
                                Console.WriteLine();
                                Console.WriteLine($"    [0] Hoofdmenu");
                                Console.WriteLine($"    [1] Terug");
                                Console.WriteLine();
                                Console.WriteLine($"    [2] Aantal Personen                - {Filters["Aantal Personen"]}");
                                Console.WriteLine();
                                Console.WriteLine($"    [3] Persoon 1");
                                Console.WriteLine($"    [4] Persoon 2");
                                Console.WriteLine($"    [5] Persoon 3");
                                Console.WriteLine($"    [6] Persoon 4");
                                Console.WriteLine();
                                Console.WriteLine($"    [7] Bevestigen");
                                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                                int InputPersoonsgegevens = 100;
                                try { InputPersoonsgegevens = int.Parse(Console.ReadLine()); } catch { }
                                switch (InputPersoonsgegevens)
                                {
                                    case 0:
                                        BookingFlight = BackToMainMenu();
                                        ChangingPersoons = false;
                                        Console.Clear();
                                        break;
                                    case 1:
                                        ChangingPersoons = false;
                                        break;
                                    case 2:
                                        bool EnteringPersons = true;
                                        while (EnteringPersons)
                                        {
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Kies het aantal personen: ");
                                            UserInterface.SetDefaultColor();
                                            string InputPersons = Console.ReadLine();
                                            try
                                            {
                                                if (Int32.Parse(InputPersons) < 5) { Filters["Aantal Personen"] = Int32.Parse(InputPersons); EnteringPersons = false; }
                                                else
                                                {
                                                    UserInterface.SetErrorColor();
                                                    Console.WriteLine();
                                                    Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt voor maximaal 4 personen tegelijk boeken.");
                                                    UserInterface.SetDefaultColor();
                                                }
                                            }
                                            catch
                                            {
                                                UserInterface.SetErrorColor();
                                                Console.WriteLine();
                                                Console.WriteLine("    Het ingevoerde aantal personen is niet correct. U kunt alleen een nummer invoeren.");
                                                UserInterface.SetDefaultColor();
                                            }
                                        }
                                        break;
                                    case 3:
                                        bool ChangingPersoon1 = true;
                                        while (ChangingPersoon1)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[0].CustomerFirstName}");
                                            if (BookingPersonData[0].CustomerMiddleName == null || BookingPersonData[0].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName} {BookingPersonData[0].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    " + $"[3] Achternaam en Tussenvoegsel    - {BookingPersonData[0].CustomerLastName}, {BookingPersonData[0].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[0].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[0].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[0].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[0].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon1gegevens = 100;
                                            try { InputPersoon1gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon1gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon1 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[0].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[0].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[0].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[0].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[0].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[0].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[0].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[0].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        bool ChangingPersoon2 = true;
                                        while (ChangingPersoon2)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[1].CustomerFirstName}");
                                            if (BookingPersonData[1].CustomerMiddleName == null || BookingPersonData[1].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName} {BookingPersonData[1].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[1].CustomerLastName}, {BookingPersonData[1].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[1].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[1].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[1].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[1].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon2 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[1].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[1].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[1].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[1].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[1].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[1].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[1].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[1].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        bool ChangingPersoon3 = true;
                                        while (ChangingPersoon3)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[2].CustomerFirstName}");
                                            if (BookingPersonData[2].CustomerMiddleName == null || BookingPersonData[2].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[2].CustomerLastName} {BookingPersonData[2].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[2].CustomerLastName}, {BookingPersonData[2].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[2].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[2].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[2].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[2].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon3 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[2].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[2].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[2].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[2].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[2].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[2].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[2].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[2].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[2].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 6:
                                        bool ChangingPersoon4 = true;
                                        while (ChangingPersoon4)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            PrintBookingStatus();
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine($"    [0] Hoofdmenu");
                                            Console.WriteLine($"    [1] Terug");
                                            Console.WriteLine();
                                            Console.WriteLine($"    [2] Voornaam                       - {BookingPersonData[3].CustomerFirstName}");
                                            if (BookingPersonData[3].CustomerMiddleName == null || BookingPersonData[3].CustomerMiddleName == "") { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[3].CustomerLastName} {BookingPersonData[3].CustomerMiddleName}"); }
                                            else { Console.WriteLine($"    [3] Achternaam en Tussenvoegsel    - {BookingPersonData[3].CustomerLastName}, {BookingPersonData[3].CustomerMiddleName}"); }
                                            Console.WriteLine($"    [4] Land                           - {BookingPersonData[3].CustomerCountry}");
                                            Console.WriteLine($"    [5] Geslacht                       - {BookingPersonData[3].CustomerGender}");
                                            Console.WriteLine($"    [6] Geboortedatum                  - {BookingPersonData[3].CustomerBirthDate}");
                                            Console.WriteLine($"    [7] BSN                            - {BookingPersonData[3].CustomerBSN}");
                                            Console.WriteLine();
                                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            int InputPersoon2gegevens = 100;
                                            try { InputPersoon2gegevens = int.Parse(Console.ReadLine()); } catch { }
                                            switch (InputPersoon2gegevens)
                                            {
                                                case 0:
                                                    BookingFlight = BackToMainMenu();
                                                    ChangingPersoons = false;
                                                    Console.Clear();
                                                    break;
                                                case 1:
                                                    ChangingPersoon4 = false;
                                                    break;
                                                case 2:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw naam in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempFirstName = Console.ReadLine();
                                                        if (TempFirstName.All(char.IsLetter))
                                                        {
                                                            BookingPersonData[3].CustomerFirstName = textInfo.ToTitleCase(TempFirstName.ToLower());
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
                                                case 3:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vul uw tussenvoegsel in (optioneel): ");
                                                        UserInterface.SetDefaultColor();
                                                        string TempPrefix = Console.ReadLine();
                                                        if (!TempPrefix.All(char.IsNumber) || TempPrefix == "")
                                                        {
                                                            BookingPersonData[3].CustomerMiddleName = TempPrefix;
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
                                                            BookingPersonData[3].CustomerLastName = textInfo.ToTitleCase(TempLastName.ToLower());
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    while (true)
                                                    {
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.Write("    Vul uw land in: ");
                                                        UserInterface.SetDefaultColor();
                                                        string InputCountry = Console.ReadLine();
                                                        InputCountry = InputCountry.ToLower();
                                                        InputCountry = textInfo.ToTitleCase(InputCountry);
                                                        if (InputCountry.Any(char.IsDigit))
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine();
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen letters gebruiken)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                        else
                                                        {
                                                            BookingPersonData[3].CustomerCountry = InputCountry;
                                                            break;
                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
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
                                                            BookingPersonData[3].CustomerGender = "Man";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "2")
                                                        {
                                                            BookingPersonData[3].CustomerGender = "Vrouw";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (TempInput == "3")
                                                        {
                                                            BookingPersonData[3].CustomerGender = "Overig";
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (U mag alleen 1 of 2 invoeren)");
                                                            UserInterface.SetDefaultColor();
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    while (true)
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
                                                            if ((today.Subtract(scheduleDate).Days / 365.242199) >= 18)
                                                            {
                                                                BookingPersonData[3].CustomerBirthDate = TempBirthDate;
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
                                                case 7:
                                                    while (true)
                                                    {
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.Write("    Vull uw BSN in: ");
                                                        UserInterface.SetDefaultColor();
                                                        BookingPersonData[3].CustomerBSN = Console.ReadLine();
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 7:
                                        ChangingPersoons = false;
                                        break;
                                }
                            }
                        }
                        BookingSteps[1][1] = "X";
                        break;
                    // CONTACT GEGEVENS INVULLEN
                    case 3:
                        BookingSteps[2][1] = "Y";
                        if (BookingSelectedFlight == null) {break;}
                        bool EmailExists(string email)
                        {
                            bool EmailExists = false;
                            List<Customer> customers = JSON.LoadCustomersJSON();
                            for (int i = 0; i < customers.Count; i++)
                            {
                                if (customers[i].Email == email)
                                {
                                    EmailExists = true;
                                    break;
                                }
                            }
                            return EmailExists;
                        }
                        bool ChangingContactGegevens = true;
                        while (ChangingContactGegevens)
                        {
                            Console.Clear();
                            UserInterface.PrintLogo();
                            PrintBookingStatus();
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            Console.WriteLine();
                            Console.WriteLine($"    [0] Hoofdmenu");
                            Console.WriteLine($"    [1] Terug");
                            Console.WriteLine();
                            Console.WriteLine($"    [2] Email       {CurrentUser.Email}");
                            Console.WriteLine($"    [3] Telefoon Nummer     {CurrentUser.Phone_number}");
                            Console.WriteLine();
                            Console.WriteLine($"    [4] Bevestigen");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            int InputContactGegevens = 100;
                            try { InputContactGegevens = int.Parse(Console.ReadLine()); } catch { }
                            switch (InputContactGegevens)
                            {
                                case 0:
                                    BookingFlight = BackToMainMenu();
                                    ChangingContactGegevens = false;
                                    Console.Clear();
                                    break;
                                case 1:
                                    ChangingContactGegevens = false;
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Vul uw email in: ");
                                        UserInterface.SetDefaultColor();
                                        string TempEmail = Console.ReadLine();

                                        try
                                        {
                                            if (EmailExists(TempEmail))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine();
                                                Console.WriteLine("    Er bestaat al een account met deze email. Vul een andere email in.");
                                                UserInterface.SetDefaultColor();
                                            }
                                            else
                                            {
                                                if (TempEmail.Contains("@") && TempEmail.Contains("."))
                                                {
                                                    CurrentUser.Email = TempEmail;
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                                    UserInterface.SetDefaultColor();
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                            UserInterface.SetDefaultColor();
                                        }
                                    }
                                    break;

                                case 3:
                                    while (true)
                                    {
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Vul uw telefoonnummer in: ");
                                        UserInterface.SetDefaultColor();
                                        string TempPhoneNumber = Console.ReadLine();
                                        if (TempPhoneNumber.All(char.IsNumber) && TempPhoneNumber.Length == 10)
                                        {
                                            CurrentUser.Phone_number = TempPhoneNumber;
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
                                case 4:
                                    ChangingContactGegevens = false;
                                    break;

                            }

                        }
                        BookingSteps[2][1] = "X";
                        break;
                    // DEFAULT
                    default:
                        Console.Clear();
                        break;
                }
            }
        }


        public static void ChangePassword(SmtpClient smtpClient)
        {
            bool Email = true;
            while (Email)
            {

                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    Vul uw email in: ");
                UserInterface.SetDefaultColor();
                List<Customer> customers = JSON.LoadCustomersJSON();
                string inputemail = Console.ReadLine();
                string currentemail;
                bool EmailExists = false;
                
                foreach (Customer customer in customers)
                {
                    if (customer.Email == inputemail)
                    {
                        EmailExists = true;
                    }
                }
                if (!EmailExists) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    niet bestande email ingevoerd");
                    UserInterface.SetDefaultColor();
                }
                else
                {
                    currentemail = inputemail;
                    Random rd = new Random();
                    int RandCode = rd.Next(100000, 999999);
                    Customer.SendCodeMail(currentemail, smtpClient, RandCode);
                    Customer.CheckChangeCode(RandCode, currentemail);
                    Email = false;
                }

            }

        }


        public static void SendCodeMail(string currentEmail, SmtpClient smtpClient, int RandCode)
        {

            var currentemail = new MailMessage

            {

                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "Code",
                Body = String.Format("<h4><b>code:</b> {0} </h4>Email:<h4> {1}", RandCode, currentEmail),
                IsBodyHtml = true,
            };
            currentemail.To.Add("RotterdamAirlines2022@outlook.com");
            currentemail.To.Add(currentEmail);
            smtpClient.Send(currentemail);

        }


        public static void CheckChangeCode(int Truecode, string EmailChangable)
        {
            bool code = true;
            int InputTries = 3;
            while (code)
            {

                Console.WriteLine("    ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    Vul de code in: ");
                UserInterface.SetDefaultColor();
                List<Customer> customers = JSON.LoadCustomersJSON();
                string inputcode = Console.ReadLine();
                int InputCode = int.Parse(inputcode);
                int y = 0;
                

                if (Truecode == InputCode)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("    Kies een wachtwoord: ");
                    UserInterface.SetDefaultColor();
                    string InputFirstPassword = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("    Vul het wachtwoord opnieuw : ");
                    UserInterface.SetDefaultColor();
                    string InputSecondPassword = Console.ReadLine();
                    foreach (Customer customer in customers)
                    {
                        if (customer.Email == EmailChangable)
                        {
                            customers[y].Password = InputSecondPassword;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("    Wachtwoord succesvol aangepast!");
                            UserInterface.SetDefaultColor();
                            code = false;
                        }
                        y++;

                    }
                    JSON.SaveCustomersJSON(customers);
                    
                }
                else
                {
                    
                    if (InputTries > 0)
                    { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    Code is onjuist, probeer opniew");
                        Console.WriteLine("    u hebt nog " + InputTries.ToString() + " kansen om het juiste wachtwoord in te vullen");
                        UserInterface.SetDefaultColor();
                        InputTries--;
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    uw kansen zijn op, klik op [enter] om naar het hoofdmenu te gaan");
                        UserInterface.SetDefaultColor();
                        Console.ReadLine();
                        code = false;
                    }
                }

            }

        }

    }

}
