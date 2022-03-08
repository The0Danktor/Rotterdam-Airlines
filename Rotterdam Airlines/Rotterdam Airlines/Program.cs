using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
namespace Rotterdam_Airlines
{
    internal class Program
    {
        private static bool authorized = false;

        static void printLogo()
        {
            Console.WriteLine(@" _____       _   _               _                          _      _ _                 ");
            Console.WriteLine(@"|  __ \     | | | |             | |                   /\   (_)    | (_)                ");
            Console.WriteLine(@"| |__) |___ | |_| |_ ___ _ __ __| | __ _ _ __ ___    /  \   _ _ __| |_ _ __   ___  ___ ");
            Console.WriteLine(@"|  _  // _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \  / /\ \ | | '__| | | '_ \ / _ \/ __|");
            Console.WriteLine(@"| | \ \ (_) | |_| ||  __/ | | (_| | (_| | | | | | |/ ____ \| | |  | | | | | |  __/\__ \");
            Console.WriteLine(@"|_|  \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_/_/    \_\_|_|  |_|_|_| |_|\___||___/");
            Console.WriteLine();
        }

        // PRINTS ALL THE OPTIONS OF THE MAIN MENU
        // TO THE CONSOLE.
        static void printMainMenu()
        {
            Console.WriteLine("1: Vlucht boeken");
            Console.WriteLine("2: Overzicht boekingen");
            Console.WriteLine("3: Mededelingen");
            Console.WriteLine("4: Aanbiedingen");
            Console.WriteLine("5: Informatie");
            Console.WriteLine();
            Console.WriteLine("6: Account");
            Console.WriteLine("7: Contact");
            Console.WriteLine("8: Afsluiten");
            Console.WriteLine();
        }
        static void printAccountMenu()
        {
            if(authorized == true)
            {
                Console.WriteLine("0: Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("1: Gegevens aanpassen");
                Console.WriteLine("2: Overzicht boekingen");
                Console.WriteLine("3: Uitloggen");
            } else
            {
                Console.WriteLine("0: Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("1: Inloggen");
                Console.WriteLine("2: Registreren");
                Console.WriteLine("3: Wachtwoord vergeten");
                Console.WriteLine();
            }
        }
        static void printRegisterMenu(Customer CurrenctUser)
        {
            Console.WriteLine($"    0: Terug          ");
            Console.WriteLine();
            Console.WriteLine($"    1: Email          - {CurrenctUser.email}");
            Console.WriteLine($"    2: Wachtwoord     - {CurrenctUser.password}");
            Console.WriteLine($"    3: Naam           - {CurrenctUser.first_name}");
            Console.WriteLine($"    4: Achternaam     - {CurrenctUser.last_name}");
            Console.WriteLine($"    5: Land           - {CurrenctUser.country}");
            Console.WriteLine($"    6: Geslacht       - {CurrenctUser.gender}");
            Console.WriteLine($"    7: Geboortedatum  - {CurrenctUser.birth_date}");
            Console.WriteLine($"    8: Telefoonnummer - {CurrenctUser.phone_number}");
            Console.WriteLine();
            Console.WriteLine($"    9: Afronden       ");
            Console.WriteLine();
        }

        static void register(Customer CurrenctUser)
        {
            bool creating = true;
            while (creating)
            {
                printLogo();
                printRegisterMenu(CurrenctUser);
                Console.Write("Maak een keuze: ");
                string register_input = Console.ReadLine();
                int register_choice = int.Parse(register_input);
                switch (register_choice)
                {
                    case 0:
                        creating = false;
                        break;
                    case 1:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw email in: ");
                        CurrenctUser.email = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw wachtwoord in: ");
                        CurrenctUser.password = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw naam in: ");
                        CurrenctUser.first_name = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw achternaam in: ");
                        CurrenctUser.last_name = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw land in: ");
                        CurrenctUser.country = Console.ReadLine();
                        Console.Clear();
                        break ;
                    case 6:
                        Console.Clear();
                        printLogo();
                        Console.WriteLine("1: man");
                        Console.WriteLine("2: vrouw");
                        Console.WriteLine();
                        Console.Write("Maak een keuze: ");
                        if (Console.ReadLine() == "1")
                        {
                            CurrenctUser.gender = "man";
                        }
                        else
                        {
                            CurrenctUser.gender = "vrouw";
                        }
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw geboortedatum in als dd-mm-jjjj: ");
                        CurrenctUser.birth_date = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        printLogo();
                        Console.Write("Vul uw telefoonnummer in: ");
                        CurrenctUser.phone_number = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 9:
                        List<Customer> temp = JSON.LoadCustomersJSON();
                        temp.Add(CurrenctUser);
                        Console.WriteLine(temp);

                        CurrenctUser.SetToDefault();
                        JSON.SaveCustomersJSON(temp);

                        creating = false;
                        break;
                }
            }
            
        }
        static void Main(string[] args)
        {
            // CREATE DEFAULT USERS
            Customer CurrenctUser = new Customer(null,null,null,null,null,null,null,null);
            Admin admin = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            while (true)
            {

                // PRINT LOGO
                printLogo();

                // PRINT WELCOME TEXT
                Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                Console.WriteLine();

                // PRINT MAIN MENU
                printMainMenu();

                // HANDLE USER INPUT
                Console.Write("Maak een keuze: ");
                string main_menu_input = Console.ReadLine();
                int main_menu_choice = int.Parse(main_menu_input);

                // HANDLE MENU
                switch(main_menu_choice)
                {
                    // VLUCHT BOEKEN
                    case 1:
                        Console.WriteLine("1");
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

                        printLogo();

                        Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                        Console.WriteLine();

                        printAccountMenu();

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
                                register(CurrenctUser);
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
                    default:
                        Console.Clear();
                        break;
                }

            }

        }
    }
}
