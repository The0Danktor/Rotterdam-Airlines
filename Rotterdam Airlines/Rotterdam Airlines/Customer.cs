using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

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

        public static void BookFlight(Customer Customer)
        {
            bool BookingFlight = true;
            string[][] BookingSteps = GenerateBookingSteps();

            // BOOKING INFO
            string[] BookingSelectedLuggage;
            List<BookingPerson> BookingPersonData = new List<BookingPerson>();
            Customer BookingCustomer = Customer;
            Flight BookingSelectedFlight = null;
            bool FlightSelected = false;

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
                int InputConfirm = int.Parse(Console.ReadLine());
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
                                                    TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
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

                    // DEFAULT
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
