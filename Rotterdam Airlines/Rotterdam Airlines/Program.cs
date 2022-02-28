using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Rotterdam_Airlines
{
    internal class Program
    {
        private static bool authorized = false;

        static void printLogo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"     _____       _   _               _                          _      _ _                 ");
            Console.WriteLine(@"    |  __ \     | | | |             | |                   /\   (_)    | (_)                ");
            Console.WriteLine(@"    | |__) |___ | |_| |_ ___ _ __ __| | __ _ _ __ ___    /  \   _ _ __| |_ _ __   ___  ___ ");
            Console.WriteLine(@"    |  _  // _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \  / /\ \ | | '__| | | '_ \ / _ \/ __|");
            Console.WriteLine(@"    | | \ \ (_) | |_| ||  __/ | | (_| | (_| | | | | | |/ ____ \| | |  | | | | | |  __/\__ \");
            Console.WriteLine(@"    |_|  \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_/_/    \_\_|_|  |_|_|_| |_|\___||___/");
            Console.WriteLine();
        }

        // PRINTS ALL THE OPTIONS OF THE MAIN MENU
        // TO THE CONSOLE.
        static void printMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    1: Vlucht boeken");
            Console.WriteLine("    2: Overzicht boekingen");
            Console.WriteLine("    3: Mededelingen");
            Console.WriteLine("    4: Aanbiedingen");
            Console.WriteLine("    5: Informatie");
            Console.WriteLine();
            Console.WriteLine("    6: Account");
            Console.WriteLine("    7: Contact");
            Console.WriteLine("    8: Afsluiten");
            Console.WriteLine();
        }

        static void printAccountMenu()
        {
            if(authorized == true)
            {
                Console.WriteLine("    0: Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    1: Gegevens aanpassen");
                Console.WriteLine("    2: Overzicht boekingen");
                Console.WriteLine("    3: Uitloggen");
            } else
            {
                Console.WriteLine("    0: Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    1: Inloggen");
                Console.WriteLine("    2: Registreren");
                Console.WriteLine("    3: Wachtwoord vergeten");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // INITIATE EMAIL CLIENT
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("RotterdamAirlines2022@outlook.com", "yks`PAha8\"5QyTN$"),
                EnableSsl = true,
            };

            while (true)
            {
                printLogo();

                // PRINT WELCOME TEXT
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Welkom bij het boekingsysteem van Rotterdam Airlines.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                // PRINT MAIN MENU
                printMainMenu();

                // HANDLE USER INPUT
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    Maak een keuze: ");
                Console.ForegroundColor = ConsoleColor.White;
                string main_menu_input = Console.ReadLine();
                int main_menu_choice = int.Parse(main_menu_input);

                switch(main_menu_choice)
                {
                    case 1:
                        Console.WriteLine("1");
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

                    // ACCOUNT
                    case 6:
                        Console.Clear();

                        printLogo();

                        Console.WriteLine("    Welkom bij het boekingsysteem van Rotterdam Airlines.");
                        Console.WriteLine();

                        printAccountMenu();

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
                            default:
                                break;
                        }

                        Console.Clear();
                        break;

                    // CONTACT
                    case 7:
                        Console.Clear();
                        printLogo();
                        Contact.PrintContactInfo();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("    Maak een keuze: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string contact_input = Console.ReadLine();
                        int contact_choice = int.Parse(contact_input);

                        switch (contact_choice)
                        {
                            case 0:
                                Console.Clear();
                                break;
                            case 1:
                                Console.Clear();
                                printLogo();

                                List<string> ContactInfo = Contact.GetContactInfo();
                                Contact.SendEmail(ContactInfo, smtpClient);

                                break;
                            default:
                                break;
                        }

                        Console.Clear();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }

        }
    }
}
