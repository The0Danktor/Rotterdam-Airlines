using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
namespace Rotterdam_Airlines
{
    internal class Program
    {
        static bool authorized = false;
        static void Main(string[] args)
        {
            // CREATE DEFAULT USERS
            Customer CurrenctUser = new Customer(null,null,null,null,null,null,null,null);
            Admin AdminUser = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            
            while (true)
            {
                // PRINT LOGO
                UserInterface.PrintLogo();

                // PRINT WELCOME TEXT
                Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                Console.WriteLine();

                // PRINT MAIN MENU
                UserInterface.PrintMainMenu();

                // HANDLE USER INPUT
                Console.Write("Maak een keuze: ");
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
                        break;

                    // ACCOUNT
                    case 6:
                        Console.Clear();
                        UserInterface.PrintLogo();

                        Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                        Console.WriteLine();

                        UserInterface.PrintAccountMenu(authorized);

                        Console.Write("Maak een keuze: ");
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
