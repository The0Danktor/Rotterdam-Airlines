using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.IO;
using Newtonsoft.Json;
namespace Rotterdam_Airlines
{
    internal class Program
    {
        static bool authorized = false;
        static void Main(string[] args)
        {
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
            Admin AdminUser = new Admin("a", "a");
            //Admin AdminUser = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            {
                if (authorized)
                {
                    Console.Clear();
                    Admin.PrintAdminMainScreen();
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
                        Console.WriteLine($"    Welkom {CurrentUser.first_name} bij het boekingsysteem van Rotterdam Airlines");
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

                    int Input = 100;
                    try { Input = int.Parse(Console.ReadLine()); } catch { }

                    // HANDLE MENU
                    switch (Input)
                    {
                        // VLUCHT BOEKEN
                        case 1:
                            Console.Clear();
                            Customer.BookFlight(CurrentUser);
                            Console.Clear();
                            break;

                        // OVERZICHT BOEKINGEN
                        case 2:
                            Console.Clear();
                            break;

                        // MEDEDELINGEN
                        case 3:
                            Console.Clear();
                            break;

                        // AANBIEDINGEN
                        case 4:
                            Console.Clear();
                            break;

                        // INFORMATIE
                        case 5:
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
                                int informatie_choice = 100;
                                try { informatie_choice = int.Parse(Console.ReadLine()); } catch { }

                                switch (informatie_choice)
                                {
                                    case 0:
                                        InformationActive = false;
                                        Console.Clear();
                                        break;

                                    case 1:
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
                                        int faciliteiten_choice = 100;
                                        try { faciliteiten_choice = int.Parse(Console.ReadLine()); } catch { }

                                        switch (faciliteiten_choice)
                                        {
                                            case 0:
                                                Console.Clear();
                                                break;
                                            case 1:
                                                Console.Clear();
                                                UserInterface.PrintLogo();
                                                Informatie.PrintWinkelen();
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                UserInterface.PrintLogo();
                                                Informatie.PrintEetgelegenheden();
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            case 3:
                                                Console.Clear();
                                                UserInterface.PrintLogo();
                                                Informatie.PrintRecreatie();
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        UserInterface.PrintLogo();
                                        Informatie.PrintOnzeVliegtuigen();
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        UserInterface.PrintLogo();
                                        Informatie.PrintFAQ();
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                            }
                            Console.Clear();
                            break;

                        // ACCOUNT
                        case 6:
                            Console.Clear();
                            UserInterface.PrintAccountMenu(authorized, CurrentUser);
                            Console.WriteLine("    ────────────────────────────────────────────────────");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();
                            int account_choice = 100;
                            try { account_choice = int.Parse(Console.ReadLine()); } catch { }
                            // Options for when no one is logged in
                            if (CurrentUser.IsGuest)
                            {
                                switch (account_choice)
                                {
                                    case 0:
                                        break;
                                    case 1:
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
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Customer.RegisterCustomer(CurrentUser);
                                        break;
                                    case 3:
                                        Console.Clear();
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
                                    case 0:
                                        break;
                                    case 1:
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        CurrentUser.SetToDefault();
                                        break;
                                }
                            }
                            Console.Clear();
                            break;

                        // CONTACT
                        case 7:
                            Console.Clear();
                            Contact.PrintContactInfo();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            UserInterface.SetDefaultColor();
                            int contact_choice = 100;
                            try { contact_choice = int.Parse(Console.ReadLine()); } catch { }


                            switch (contact_choice)
                            {
                                case 0:
                                    Console.Clear();
                                    break;
                                case 1:
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
                        case 8:
                            Environment.Exit(0);
                            break;

                        // Admin Test
                        case 9:
                            Console.Clear();
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
}
