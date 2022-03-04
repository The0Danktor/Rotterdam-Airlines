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
        static List<Customer> loadJSON(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Customer> objects= JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            Console.WriteLine(objects); 
            return objects;
        }
        static void saveJSON(string fileName, List<Customer> data)
        {
            string jsonString = JsonConvert.SerializeObject(data,Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }
        static Customer register(List<Customer> customers , string CustomersJSON)
        {
            customers[0].first_name = Console.ReadLine();
            customers[0].last_name = Console.ReadLine();
            customers[0].country = Console.ReadLine();
            if (Console.ReadLine() == "1")
            {
                customers[0].gender = 'm';
            }
            else
            {
                customers[0].gender = 'f';
            }
            customers[0].birth_date = Console.ReadLine();
            customers[0].phone_number = Console.ReadLine();
            Console.WriteLine();
            Console.ReadLine();
            saveJSON(CustomersJSON, customers);
            return customers[0];
        }
        static void Main(string[] args)
        {
            // define Json paths
            string CustomersJSON = @"D:\codes\test project\Project-B\Rotterdam Airlines\Rotterdam Airlines\JSON\customers.json";
            
            // CREATE DEFAULT USERS
            List<Customer> customers = loadJSON(CustomersJSON);
            Admin admin = new Admin("admin@rotterdamairlines.com", "321898aS*D*@ads-");
            saveJSON(CustomersJSON, customers);
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
                                register(customers, CustomersJSON);
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
                        saveJSON(CustomersJSON, customers);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }

        }
    }
}
