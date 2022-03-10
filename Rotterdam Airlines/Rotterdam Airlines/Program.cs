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
            Customer CurrenctUser = new Customer(null,null,null,null,null,null,null,null);
            Admin AdminUser = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            
            while (true)
            {
                // PRINT LOGO
                UserInterface.PrintLogo();

                // PRINT WELCOME TEXT
                UserInterface.SetMainColor();
                Console.WriteLine("    Welkom bij het boekingsysteem van Rotterdam Airlines.");
                UserInterface.SetDefaultColor();
                Console.WriteLine();

                // PRINT MAIN MENU
                UserInterface.PrintMainMenu();

                // HANDLE USER INPUT
                Console.Write("    Maak een keuze: ");
                string MainMenuInput = Console.ReadLine();
                int MainMenuChoice = int.Parse(MainMenuInput);

                // HANDLE MENU
                switch(MainMenuChoice)
                {
                    // VLUCHT BOEKEN
                    case 1:
                        Console.Clear();
                        Console.WriteLine(IdHandler.getID());
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
                        break;

                    // ACCOUNT
                    case 6:
                        Console.Clear();
                        UserInterface.PrintLogo();

                        Console.WriteLine("    Welkom bij het boekingsysteem van Rotterdam Airlines.");
                        Console.WriteLine();

                        UserInterface.PrintAccountMenu(authorized);

                        Console.Write("    Maak een keuze: ");
                        string account_input = Console.ReadLine();
                        int account_choice = int.Parse(account_input);

                        switch(account_choice)
                        {
                            case 0:
                                Console.Clear();
                                break;
                            case 1:
                                Console.WriteLine("1");
                                break;
                            case 2:
                                Console.Clear();
                                Customer.RegisterCustomer(CurrenctUser);
                                break;
                        }

                        Console.Clear();
                        break;

                    // CONTACT
                    case 7:
                        Console.Clear();
                        UserInterface.PrintLogo();
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
                                UserInterface.PrintLogo();

                                List<string> ContactInfo = Contact.GetContactInfo();
                                Contact.SendEmail(ContactInfo, smtpClient);

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
