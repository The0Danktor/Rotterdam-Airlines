﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Rotterdam_Airlines
{
    internal class Program
    {
        static bool authorized = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // LOAD ALL FLIGHTS WHICH ARE IN THE FLIGHTS.JSON TO THE FLIGHT LIST
            Flight.GenerateFlightWeeks();
            // INITIATE EMAIL CLIENT
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("RotterdamAirlines2022@outlook.com", "yks`PAha8\"5QyTN$"),
                EnableSsl = true,
            };

            // CREATE DEFAULT USERS
            Customer CurrentUser = new Customer(null, null, null, null, null, null, null, null, null, null, new List<string>(), true);
            Admin AdminUser = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            while(true)
            {
                if (authorized)
                {
                    bool adminmain_bool = true;
                    while (adminmain_bool)
                    {
                        Console.Clear();
                        if (Admin.PrintAdminMainScreen())
                        {   
                            adminmain_bool = true;
                            authorized = true;
                        }
                        else
                        {
                            adminmain_bool = false;
                            authorized = false;
                        }
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                }
                else
                {
                    // PRINT LOGO
                    UserInterface.PrintLogo();

                    // PRINT WELCOME TEXT
                    UserInterface.SetMainColor();
                    if (!CurrentUser.IsGuest == true)
                    {
                        Console.WriteLine($"    Welkom {CurrentUser.First_name} bij het boekingsysteem van Rotterdam Airlines");
                    }
                    else
                    {
                        Console.WriteLine($"    Welkom bij het boekingsysteem van Rotterdam Airlines");
                    }
                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                    UserInterface.SetDefaultColor();
                    Console.WriteLine();

                    // PRINT MAIN MENU
                    UserInterface.PrintMainMenu(authorized);

                    // HANDLE USER INPUT
                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                    Console.WriteLine();
                    UserInterface.SetMainColor();
                    Console.Write("    Maak een keuze: ");
                    UserInterface.SetDefaultColor();

                    var Input = Console.ReadKey(true);

                    // HANDLE MENU
                    switch (Input.Key)
                    {
                        // VLUCHT BOEKEN
                        case ConsoleKey.D1:
                            Console.Clear();
                            Customer.BookFlight(AdminUser, CurrentUser);
                            Console.Clear();
                            break;

                        // OVERZICHT BOEKINGEN
                        case ConsoleKey.D2:
                            // IF USER IS NOT LOGGED IN
                            List<Flight> Flights = JSON.LoadFlightsJSON();
                            Flight FlightTarget = null;
                            List<Booking> Bookings = JSON.LoadBookingsJSON();
                            if (CurrentUser.UserId == null)
                            {
                                bool SearchingBookings = true;  
                                while (SearchingBookings)
                                {
                                    Console.Clear();
                                    UserInterface.PrintLogo();
                                    UserInterface.SetMainColor();
                                    Console.WriteLine("    Rotterdam Airlines | Overzicht Boekingen");
                                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                    Console.WriteLine();
                                    UserInterface.SetDefaultColor();
                                    Console.WriteLine("    [0] Hoofdmenu");
                                    Console.WriteLine();
                                    Console.WriteLine("    [1] Boekingcode Invoeren");
                                    Console.WriteLine();
                                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                    Console.WriteLine();
                                    UserInterface.SetMainColor();
                                    Console.Write("    Maak een keuze: ");
                                    UserInterface.SetDefaultColor();

                                    var InputSearchBookings = Console.ReadKey(true);
                                    switch(InputSearchBookings.Key)
                                    {
                                        case ConsoleKey.D0:
                                            SearchingBookings = false;
                                            break;
                                        case ConsoleKey.D1:
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    Rotterdam Airlines | Boekingcode Invoeren");
                                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            Console.Write("    Boekingcode: ");
                                            UserInterface.SetDefaultColor();
                                            var InputBookingID = Console.ReadLine();
                                            Booking BookingTarget = null;
                                            for(int i = 0; i < Bookings.Count; i++)
                                            {
                                                if (Bookings[i].BookingID == InputBookingID) { BookingTarget = Bookings[i]; }
                                            }
                                            if(BookingTarget == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("    Boeking met boekingcode (" + InputBookingID + ") niet gevonden.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                                                Console.ReadKey(true);
                                            } else
                                            {
                                                Console.WriteLine();
                                                UserInterface.SetMainColor();
                                                Console.Write("    Vul de email in die gekoppeld is aan deze boeking: ");
                                                UserInterface.SetDefaultColor();
                                                var InputSearchBookingEmail = Console.ReadLine();
                                                if (InputSearchBookingEmail != BookingTarget.CustomerEmail)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("    U heeft de verkeerde email ingevoerd.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                                                    Console.ReadKey(true);
                                                }
                                                else
                                                {
                                                    bool LookingAtBooking = true;
                                                    while (LookingAtBooking)
                                                    {
                                                        for (int i = 0; i < Flights.Count; i++)
                                                        {
                                                            if (BookingTarget.FlightCode == Flights[i].FlightCode) { FlightTarget = Flights[i]; }
                                                        }
                                                        Console.Clear();
                                                        TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
                                                        CultureInfo Dutch = new CultureInfo("nl-NL", false);
                                                        DateTime DepartureInfo = FlightTarget.Departure;
                                                        string Departure = DepartureInfo.ToString("MMMM", Dutch);
                                                        Departure = textInfo.ToTitleCase(Departure);
                                                        UserInterface.SetDefaultColor();
                                                        UserInterface.PrintLogo();
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        if (BookingTarget.Cancelled == true)
                                                        {
                                                            Console.WriteLine("    Rotterdam Airlines | Boeking (" + BookingTarget.BookingID + ") - GEANNULEERD");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("    Rotterdam Airlines | Boeking (" + BookingTarget.BookingID + ")");
                                                        }
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        Console.WriteLine();
                                                        UserInterface.SetDefaultColor();
                                                        Console.WriteLine("    [0] Terug");
                                                        Console.WriteLine();
                                                        Console.WriteLine("    [1] Boeking Annuleren");
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        Console.WriteLine();
                                                        Console.WriteLine("    Vluchtcode    Vluchtnummer     Bestemming           Vertrek");
                                                        UserInterface.SetDefaultColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    " + FlightTarget.FlightCode + "\t  " + FlightTarget.FlightNumber + "\t   " + FlightTarget.Destination + " \t\t" + DepartureInfo.Day + " " + Departure + " " + DepartureInfo.TimeOfDay);
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine("    Persoonsgegevens");
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        UserInterface.SetDefaultColor();
                                                        foreach (BookingPerson person in BookingTarget.BookingPersons)
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"    {person.GetFullname()}");
                                                            Console.WriteLine();
                                                            Console.WriteLine($"        Land                            - {person.CustomerCountry}");
                                                            Console.WriteLine($"        Geslacht                        - {person.CustomerGender}");
                                                            Console.WriteLine($"        Geboortedatum                   - {person.CustomerBirthDate}");
                                                            Console.WriteLine($"        BSN                             - {person.CustomerBSN}");
                                                            Console.WriteLine();
                                                        }
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine("    Contactgegevens");
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        UserInterface.SetDefaultColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine($"    Email                                   - {BookingTarget.CustomerEmail}");
                                                        Console.WriteLine($"    Telefoonnummer                          - {BookingTarget.CustomerPhoneNumber}");
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    Stoelen");
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        UserInterface.SetDefaultColor();
                                                        foreach (Seat seat in BookingTarget.SeatList)
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"    Stoel {seat.Id}");
                                                            Console.WriteLine();
                                                            Console.WriteLine($"        Klasse                          - {seat.SeatClass}");
                                                            Console.WriteLine($"        Bijzonderheden                  - {seat.Special}");
                                                            Console.WriteLine($"        Prijs                           - {seat.Price}");
                                                        }
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine();
                                                        Console.WriteLine("    Prijs");
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        UserInterface.SetDefaultColor();
                                                        Console.WriteLine();
                                                        foreach (Seat seat in BookingTarget.SeatList)
                                                        {
                                                            Console.WriteLine($"    Stoel {seat.Id}                            - €{seat.Price}");
                                                        }
                                                        Console.WriteLine($"                                        ─────────── +");
                                                        Console.WriteLine($"    Totaal                              - €{BookingTarget.BookingPrice}");
                                                        Console.WriteLine();
                                                        UserInterface.SetMainColor();
                                                        Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                                                        Console.WriteLine();
                                                        Console.Write("    Maak een keuze: ");
                                                        var BookingOverviewInput = Console.ReadKey();
                                                        switch(BookingOverviewInput.Key)
                                                        {
                                                            case ConsoleKey.D0:
                                                                LookingAtBooking = false;
                                                                break;
                                                            case ConsoleKey.D1:
                                                                Console.WriteLine();
                                                                UserInterface.SetMainColor();
                                                                Console.WriteLine("    Weet u zeker dat u boeking (" + BookingTarget.BookingID + ") wil annuleren?");
                                                                Console.WriteLine();
                                                                UserInterface.SetDefaultColor();
                                                                Console.WriteLine("    [1] Ja");
                                                                Console.WriteLine("    [2] Nee");
                                                                Console.WriteLine();
                                                                UserInterface.SetMainColor();
                                                                Console.Write("    Maak een keuze: ");
                                                                var InputCancelBookingConfirmation = Console.ReadKey();
                                                                if (InputCancelBookingConfirmation.Key == ConsoleKey.D1)
                                                                {
                                                                    if(!BookingTarget.Cancelled)
                                                                    {
                                                                        Admin.CancelBooking(BookingTarget);
                                                                        Console.WriteLine();
                                                                        Console.WriteLine();
                                                                        UserInterface.SetConfirmColor();
                                                                        Console.WriteLine("    Boeking succesvol geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                                                        Console.ReadKey(true);
                                                                        LookingAtBooking = false;
                                                                        SearchingBookings = false;
                                                                    } else
                                                                    {
                                                                        Console.WriteLine();
                                                                        Console.WriteLine();
                                                                        UserInterface.SetErrorColor();
                                                                        Console.WriteLine("    Boeking is al geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                                                        Console.ReadKey(true);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine();
                                                                    Console.WriteLine();
                                                                    Console.WriteLine("    Boeking niet geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                                                    Console.ReadKey(true);
                                                                }
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                }
                                                    
                                            }
                                            break;

                                        default:
                                            Console.WriteLine();
                                            Console.WriteLine("    Verkeerde menu input. Klik een willekeurige toets om het opnieuw te proberen...");
                                            var InputSearchBookingsTemp = Console.ReadKey(true);
                                            break;
                                    }
                                }
                            } 
                            // IF USER IS LOGGED IN
                            else
                            {
                                CurrentUser.ViewBookings();
                            }

                            Console.Clear();
                            break;

                        // VLUCHTSCHEMA
                        case ConsoleKey.D3:
                            Console.Clear();
                            List<Flight> AllFlights = JSON.LoadFlightsJSON();
                            List<Flight> TodayFlights = new List<Flight>();

                            foreach (Flight flight in AllFlights)
                            {
                                if(flight.Departure.Date == DateTime.Now.Date)
                                {
                                    TodayFlights.Add(flight);
                                }
                            }

                            bool ViewingFlightScheme = true;
                            while(ViewingFlightScheme)
                            {
                                Console.Clear();
                                UserInterface.PrintLogo();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    Rotterdam Airlines | Vluchtschema (Alle vluchten van vandaag)");
                                Console.WriteLine("    ────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetDefaultColor();
                                Console.WriteLine("    [0] Hoofdmenu");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                if (TodayFlights.Count > 0)
                                {
                                    Console.WriteLine("    Vluchtcode    Vluchtnummer     Bestemming           Vertrek                 Status");
                                    Console.WriteLine();
                                    UserInterface.SetDefaultColor();
                                    foreach (Flight flight in TodayFlights)
                                    {
                                        string FlightStatus = "";
                                        if(flight.Cancelled == true) { FlightStatus = "Geannuleerd"; }
                                        else if(DateTime.Compare(DateTime.Now, flight.Departure) > 0) { FlightStatus = "Vertrokken"; }
                                        Console.Write("    " + flight.FlightCode + "\t  " + flight.FlightNumber + "\t   " + flight.Destination + " \t\t" + flight.Departure + "\t");
                                        if(FlightStatus == "Geannuleerd")
                                        {
                                            UserInterface.SetErrorColor();
                                            Console.WriteLine(FlightStatus);
                                            UserInterface.SetDefaultColor();
                                        } else
                                        {
                                            UserInterface.SetConfirmColor();
                                            Console.WriteLine(FlightStatus);
                                            UserInterface.SetDefaultColor();
                                        }
                                    }
                                } else
                                {
                                    UserInterface.SetErrorColor();
                                    Console.WriteLine("    Geen vluchten gevonden...");
                                    UserInterface.SetDefaultColor();
                                }

                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    ────────────────────────────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();

                                var InputSearchBookings = Console.ReadKey(true);
                                switch (InputSearchBookings.Key) {
                                    case ConsoleKey.D0:
                                        ViewingFlightScheme = false;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            Console.Clear();
                            break;

                        // INFORMATIE
                        case ConsoleKey.D4:
                            bool InformationActive = true;
                            while (InformationActive)
                            {
                                Console.Clear();
                                UserInterface.PrintLogo();
                                UserInterface.SetMainColor();
                                Console.WriteLine("    Rotterdam Airlines | Informatie");
                                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetDefaultColor();
                                UserInterface.PrintInfoMenu();
                                Console.WriteLine();
                                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                  
                                ConsoleKey informatie_choice = Console.ReadKey().Key;

                                switch (informatie_choice)
                                {
                                    case ConsoleKey.D0:
                                        InformationActive = false;
                                        Console.Clear();
                                        break;

                                    case ConsoleKey.D1:
                                        bool FaciliteitenActive = true;
                                        while (FaciliteitenActive)
                                        {
                                            Console.Clear();
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    Rotterdam Airlines | Informatie | Faciliteiten");
                                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetDefaultColor();
                                            UserInterface.PrintFaciliteitenMenu();
                                            Console.WriteLine();
                                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                                            Console.WriteLine();
                                            UserInterface.SetMainColor();
                                            Console.Write("    Maak een keuze: ");
                                            UserInterface.SetDefaultColor();
                                            
                                            ConsoleKey faciliteiten_choice = Console.ReadKey().Key;

                                            switch (faciliteiten_choice)
                                            {
                                                case ConsoleKey.D0:
                                                    Console.Clear();
                                                    FaciliteitenActive = false;
                                                    InformationActive = false;
                                                    break;
                                                case ConsoleKey.D1:
                                                    FaciliteitenActive = false;
                                                    break;
                                                case ConsoleKey.D2:
                                                    bool WinklenActive = true;
                                                    while (WinklenActive)
                                                    {
                                                        Console.Clear();
                                                        UserInterface.PrintLogo();
                                                        Informatie.PrintWinkelen();

                                                        ConsoleKey winkelen_choice = Console.ReadKey(true).Key;

                                                        switch (winkelen_choice)
                                                        {
                                                            case ConsoleKey.D0:
                                                                Console.Clear();
                                                                WinklenActive = false;
                                                                FaciliteitenActive = false;                                                                
                                                                InformationActive = false;
                                                                
                                                                break;
                                                            case ConsoleKey.D1:
                                                                Console.Clear();                                                               
                                                                WinklenActive = false;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case ConsoleKey.D3:
                                                    bool EetActive = true;
                                                    while (EetActive)
                                                    {
                                                        Console.Clear();
                                                        UserInterface.PrintLogo();
                                                        Informatie.PrintEetgelegenheden();
                                                        ConsoleKey eet_choice = Console.ReadKey(true).Key;

                                                        switch (eet_choice)
                                                        {
                                                            case ConsoleKey.D0:
                                                                Console.Clear();
                                                                EetActive = false;
                                                                FaciliteitenActive = false;
                                                                InformationActive = false;

                                                                break;
                                                            case ConsoleKey.D1:
                                                                Console.Clear();
                                                                EetActive = false;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case ConsoleKey.D4:
                                                    bool RecreatieActive = true;
                                                    while (RecreatieActive)
                                                    {
                                                        Console.Clear();
                                                        UserInterface.PrintLogo();
                                                        Informatie.PrintRecreatie();
                                                        ConsoleKey recreatie_choice = Console.ReadKey().Key;
                                                        switch (recreatie_choice)
                                                        {
                                                            case ConsoleKey.D0:
                                                                Console.Clear();
                                                                RecreatieActive = false;
                                                                FaciliteitenActive = false;
                                                                InformationActive = false;

                                                                break;
                                                            case ConsoleKey.D1:
                                                                Console.Clear();
                                                                RecreatieActive = false;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;

                                    case ConsoleKey.D2:
                                        bool NieuwsActive = true;
                                        while (NieuwsActive)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            Informatie.PrintLaatsteNieuws();
                                            ConsoleKey nieuws_choice = Console.ReadKey(true).Key;

                                            switch (nieuws_choice)
                                            {
                                                case ConsoleKey.D0:
                                                    Console.Clear();
                                                    NieuwsActive = false;
                                                    InformationActive = false;

                                                    break;
                                                case ConsoleKey.D1:
                                                    Console.Clear();
                                                    NieuwsActive = false;
                                                    break;
                                            }
                                        }
                                        break;
                                
                                
                                    case ConsoleKey.D3:
                                        bool VliegtuigenActive = true;
                                        while (VliegtuigenActive)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            Informatie.PrintOnzeVliegtuigen();
                                            ConsoleKey vliegtuigen_choice = Console.ReadKey(true).Key;

                                            switch (vliegtuigen_choice)
                                            {
                                                case ConsoleKey.D0:
                                                    Console.Clear();
                                                    VliegtuigenActive = false;
                                                    InformationActive = false;

                                                    break;
                                                case ConsoleKey.D1:
                                                    Console.Clear();
                                                    VliegtuigenActive = false;
                                                    break;
                                            }
                                        }
                                        break;
                                    case ConsoleKey.D4:
                                        bool FAQActive = true;
                                        while (FAQActive)
                                        {
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            Informatie.PrintFAQ();
                                            ConsoleKey FAQ_choice = Console.ReadKey(true).Key;

                                            switch (FAQ_choice)
                                            {
                                                case ConsoleKey.D0:
                                                    Console.Clear();
                                                    FAQActive = false;
                                                    InformationActive = false;

                                                    break;
                                                case ConsoleKey.D1:
                                                    Console.Clear();
                                                    FAQActive = false;
                                                    break;
                                            }
                                        }
                                        break;
                                    
                                }
                            }
                            Console.Clear();
                            break;

                        // ACCOUNT
                        case ConsoleKey.D5:
                            bool AccountMenu = true;
                            while (AccountMenu)
                            {

                                Console.Clear();
                                UserInterface.PrintAccountMenu(authorized, CurrentUser);
                                Console.WriteLine("    ────────────────────────────────────────────────────");
                                Console.WriteLine();
                                UserInterface.SetMainColor();
                                Console.Write("    Maak een keuze: ");
                                UserInterface.SetDefaultColor();
                                ConsoleKey account_choice = Console.ReadKey(true).Key;
                                // Options for when no one is logged in
                                if (CurrentUser.IsGuest)
                                {
                                    switch (account_choice)
                                    {
                                        case ConsoleKey.D0:
                                            AccountMenu = false;
                                            break;
                                        case ConsoleKey.D1:
                                            Console.Clear();
                                            Type check = typeof(Customer);
                                            object LoginInformation = Customer.Login(AdminUser, CurrentUser);
                                            if (LoginInformation.GetType().Equals(check))
                                            {
                                                CurrentUser = (Customer)LoginInformation;
                                            }
                                            else
                                            {
                                                authorized = true;
                                            }
                                            AccountMenu = false;
                                            break;
                                        case ConsoleKey.D2:
                                            Console.Clear();
                                            Customer.RegisterCustomer(CurrentUser);
                                            break;
                                        case ConsoleKey.D3:
                                            Console.Clear();
                                            UserInterface.PrintLogo();
                                            UserInterface.SetMainColor();
                                            Console.WriteLine("    Rotterdam Airlines | Account | Wachtwoord vergeten");
                                            Console.WriteLine("    ──────────────────────────────────────────────────");
                                            UserInterface.SetDefaultColor();
                                            Console.WriteLine();
                                            Console.WriteLine("    [0] Terug");
                                            Console.WriteLine("    ");
                                            Console.WriteLine("    ──────────────────────────────────────────────────");
                                            Customer.ChangePassword(smtpClient);
                                            break;
                                    }
                                }
                                // Options for when a admin is logged in 
                                else if (authorized) { }
                                // Options for when a user is logged in 
                                else
                                {

                                    switch (account_choice)
                                    {
                                        case ConsoleKey.D0:
                                            AccountMenu = false;
                                            break;
                                        case ConsoleKey.D1:
                                            CurrentUser.ChangeAccount(CurrentUser);
                                            break;
                                        case ConsoleKey.D2:
                                            CurrentUser.ViewBookings();
                                            break;
                                        case ConsoleKey.D3:
                                            CurrentUser.SetToDefault();
                                            break;
                                    }
                                }
                            }
                            Console.Clear();
                            break;

                        // CONTACT
                        case ConsoleKey.D6:
                            Console.Clear();
                            Contact.PrintContactInfo();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();
                            
                            ConsoleKey contact_choice = Console.ReadKey().Key;


                            switch (contact_choice)
                            {
                                case ConsoleKey.D0:
                                    Console.Clear();
                                    break;
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    List<string> ContactInfo = Contact.GetContactInfo();
                                    if (ContactInfo.Count == 5)
                                    {
                                        Contact.SendEmail(ContactInfo, smtpClient);
                                    }
                                    break;
                                default:
                                    break;
                            }

                            Console.Clear();
                            break;

                        // EXIT
                        case ConsoleKey.D7:
                            Environment.Exit(0);
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
}
