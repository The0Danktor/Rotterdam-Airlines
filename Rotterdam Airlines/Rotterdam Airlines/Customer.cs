using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

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

        }
        private string getFullName()
        {
            return $"{first_name} {last_name}";
        }

        private void GetNewUserID()
        {
            this.UserId = IdHandler.getID();
        }

        static public string hiddenpassword(Customer CurrentUser, string question) 
        {
            string test = "";
            string hidden = "";
            while (true) 
            {
                var temp = Console.ReadKey(true);
                if (temp.Key != ConsoleKey.Enter && temp.Key != ConsoleKey.Backspace)
                {
                    test += temp.KeyChar;
                    hidden += "*";
                    /*Console.Clear();
                    UserInterface.PrintLogo();
                    UserInterface.SetMainColor();
                    Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
                    Console.WriteLine("    ────────────────────────────────────────────────────");
                    Console.WriteLine();
                    UserInterface.SetDefaultColor();
                    UserInterface.PrintRegisterMenu(CurrentUser);
                    Console.Write("    Maak een keuze: ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write(question);
                    Console.WriteLine(hidden);*/
                    Console.Write("*");
                }
                else if (temp.Key == ConsoleKey.Backspace)
                {
                    if (test.Length > 0)
                    {
                        test = test.Remove(test.Length - 1);
                        hidden = hidden.Remove(hidden.Length - 1);
                        Console.Clear();
                        UserInterface.PrintLogo();
                        UserInterface.SetMainColor();
                        Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
                        Console.WriteLine("    ────────────────────────────────────────────────────");
                        Console.WriteLine();
                        UserInterface.SetDefaultColor();
                        UserInterface.PrintRegisterMenu(CurrentUser);
                        Console.Write("    Maak een keuze: ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write(question);
                        Console.Write(hidden);
                    }
                }
                else
                {
                    Console.Clear();
                    return test;

                }
            }
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
                        string TempPassword = "";
                        string Temp2Password = "";
                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("    Vul uw wachtwoord in: ");
                            TempPassword = hiddenpassword(CurrentUser, "    Vul uw wachtwoord in: ");
                            if (TempPassword.Length >= 8) 
                            {
                                break;
                            }
                            else 
                            {
                                UserInterface.PrintLogo();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
                                Console.WriteLine("    ────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetDefaultColor();
                                UserInterface.PrintRegisterMenu(CurrentUser);
                                Console.Write("    Maak een keuze: ");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opnieuw. (Uw wachtwoord moet langer zijn dat 8 characters)");
                                UserInterface.SetDefaultColor();
                            }
                        }
                        while (true)
                        {
                            UserInterface.PrintLogo();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
                            Console.WriteLine("    ────────────────────────────────────────────────────");
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            UserInterface.PrintRegisterMenu(CurrentUser);
                            Console.Write("    Maak een keuze: ");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("    Vul het zelfde wachtwoord in: ");
                            Temp2Password = hiddenpassword(CurrentUser, "    Vul het zelfde wachtwoord in: ");
                            if (TempPassword == Temp2Password)
                            {
                                CurrentUser.password = TempPassword;
                                Console.Clear();
                                break;
                            }
                            else
                            {
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
                            Console.WriteLine("    [1] man");
                            Console.WriteLine("    [2] vrouw");
                            Console.WriteLine("    [3] overig");
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
                            if (validDate) 
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

        public static string[][] GenerateBookingSteps()
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

        public static void BookFlight(Customer Customer)
        {
            bool BookingFlight = true;
            string[][] BookingSteps = GenerateBookingSteps();

            // BOOKING INFO
            Flight BookingSelectedFlight;
            string[] BookingSelectedLuggage;
            List<BookingPerson> BookingPersonData = new List<BookingPerson>();
            Customer BookingCustomer = Customer;

            Hashtable Filter = new Hashtable()
            {
                {"Bestemming", ""},
                {"Datum", "doomsday"},
                {"Aantal Personen", 2},
                {"Maximum Prijs", 1000}
            };

            // FILTERS
            string FilterDestination = "-";
            string FilterDate = "-";
            int FilterPersons = 1;
            double FilterPrice = 1000;

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
                int InputConfirm = int.Parse(Console.ReadLine());
                if (InputConfirm == 1)
                {
                    return false;
                } else
                {
                    return true;
                }
            }

            // BOOK FLIGHT MENU
            while (BookingFlight)
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
                Console.WriteLine();
                Console.WriteLine("    [1] Vlucht Selecteren");
                Console.WriteLine("    [3] Persoonsgegevens");
                Console.WriteLine("    [4] Contactgegevens");
                Console.WriteLine("    [5] Bagage Toevoegen");
                Console.WriteLine("    [6] Stoelen Kiezen");
                Console.WriteLine();
                Console.WriteLine("    [6] Boeking Overzicht");
                Console.WriteLine("    [7] Boeking Bevestigen");
                Console.WriteLine();
                Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();

                int Input = int.Parse(Console.ReadLine());

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
                        while(SelectingFlight)
                        {
                            int CurrentPage = 1;
                            List<Flight> Flights = Flight.GetFlights();

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
                            Console.WriteLine("    [3] Vorige Pagina");
                            Console.WriteLine("    [4] Volgende Pagina");
                            Console.WriteLine();
                            Console.WriteLine("    [5] Vluchtcode Invoeren");
                            Console.WriteLine();
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();

                            int InputSelectFlight = int.Parse(Console.ReadLine());

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
                                        Console.WriteLine("    [2] Bestemming           " + FilterDestination);
                                        Console.WriteLine("    [3] Datum                " + FilterDate);
                                        Console.WriteLine("    [4] Aantal Personen      " + FilterPersons);
                                        Console.WriteLine("    [5] Maximum Prijs        " + FilterPrice);
                                        Console.WriteLine();
                                        Console.WriteLine("    [6] Filters Bevestigen");
                                        Console.WriteLine();
                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Maak een keuze: ");
                                        UserInterface.SetDefaultColor();

                                        int InputSelectFlightFilter = int.Parse(Console.ReadLine());

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
                                                Console.Clear();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                break;
                                            case 5:
                                                Console.Clear();
                                                break;
                                            case 6:
                                                ChangingFilters = false;
                                                Console.Clear();
                                                break;
                                            default:
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    Console.Clear();
                                    break;

                                case 3:
                                    if (CurrentPage != 1) { CurrentPage -= 1; }
                                    Console.Clear();
                                    break;
                                case 4:
                                    CurrentPage += 1;
                                    Console.Clear();
                                    break;

                                case 5:
                                    bool EnteringFlightCode = true;
                                    while(EnteringFlightCode)
                                    {
                                        Console.WriteLine();
                                        UserInterface.SetMainColor();
                                        Console.Write("    Vul een vluchtcode in: ");
                                        UserInterface.SetDefaultColor();
                                        string InputFlightCode = Console.ReadLine();
                                        // CHECK IF INPUT IS CORRECT AND ASSIGN FLIGHT TO BOOKINGSELECTEDFLIGHT
                                        EnteringFlightCode = false;
                                        SelectingFlight = false;
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

                    // DEFAULT
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
