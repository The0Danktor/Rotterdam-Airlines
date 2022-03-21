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

            // INITIATE EMAIL CLIENT
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("RotterdamAirlines2022@outlook.com", "yks`PAha8\"5QyTN$"),
                EnableSsl = true,
            };
           
            // CREATE DEFAULT USERS
            Customer CurrentUser = new Customer(null,null,null,null,null,null,null,null,null,null);
            Admin AdminUser = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            
            while (true)
            {
                // PRINT LOGO
                UserInterface.PrintLogo();

                // PRINT WELCOME TEXT
                UserInterface.SetMainColor();
                Console.WriteLine("    Welkom bij het boekingsysteem van Rotterdam Airlines");
                Console.WriteLine("    ────────────────────────────────────────────────────");
                UserInterface.SetDefaultColor();
                Console.WriteLine();

                // PRINT MAIN MENU
                UserInterface.PrintMainMenu(authorized);

                // HANDLE USER INPUT
                Console.WriteLine("    ────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();
                string MainMenuInput = Console.ReadLine();
                int MainMenuChoice = int.Parse(MainMenuInput);

                // HANDLE MENU
                switch(MainMenuChoice)
                {
                    // VLUCHT BOEKEN
                    case 1:
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
                        Console.Clear();
                        UserInterface.PrintLogo();

                        Console.WriteLine("    Vind alle Informatie over Rotterdam Airlines.");
                        Console.WriteLine();

                        UserInterface.PrintInfoMenu();

                        Console.WriteLine();
                        Console.Write("    Maak een keuze: ");

                        string informatie_input = Console.ReadLine();
                        int informatie_choice = int.Parse(informatie_input);

                        switch (informatie_choice)
                        {
                            case 0:
                                Console.Clear();
                                break;

                            case 1:
                                Console.Clear();
                                UserInterface.PrintLogo();

                                Console.WriteLine("    Vind alle Informatie over onze faciliteien.");
                                Console.WriteLine();

                                UserInterface.PrintFaciliteitenMenu();

                                Console.WriteLine();
                                Console.WriteLine("    Maak een keuze.");
                                

                                string faciliteiten_input = Console.ReadLine();
                                int faciliteiten_choice = int.Parse(faciliteiten_input);

                                
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
                        break;

                    // ACCOUNT
                    case 6:
                        Console.Clear();
                        UserInterface.PrintAccountMenu(authorized);
                        Console.WriteLine("    ────────────────────────────────────────────────────");
                        Console.WriteLine();
                        UserInterface.SetMainColor();
                        Console.Write("    Maak een keuze: ");
                        UserInterface.SetDefaultColor();
                        string account_input = Console.ReadLine();
                        int account_choice = int.Parse(account_input);

                        switch(account_choice)
                        {
                            case 0:
                                Console.WriteLine("1");
                                break;
                            case 1:
                                Customer.Login(AdminUser);
                                break;
                            case 2:
                                Console.Clear();
                                Customer.RegisterCustomer(CurrentUser);
                                break;
                            case 3:
                                Console.Clear();
                                break;
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
                        string contact_input = Console.ReadLine();
                        int contact_choice = int.Parse(contact_input);

                        switch (contact_choice)
                        {
                            case 0:
                                Console.Clear();
                                break;
                            case 1:
                                Console.Clear();
                                List<string> ContactInfo = Contact.GetContactInfo();
                                if(ContactInfo.Count == 5) 
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

                    // DEFAULT
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
