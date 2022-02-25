using System;

namespace Rotterdam_Airlines
{
    internal class Program
    {
        private static bool authorized = false;

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
        static void contact_info()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Contact");
            Console.WriteLine();
            Console.WriteLine("Adres");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rotterdam Airlines");
            Console.WriteLine("Driemanssteeweg 107");
            Console.WriteLine("3011 WN Rotterdam");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Telefoonnummer");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("0104463544");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("E-mail");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RotterdamAirlines2022@outlook.com");
            Console.WriteLine();
            Console.WriteLine("Klik op 'enter' om terug te gaan");
            string contact_input = Console.ReadLine();
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

        static void Main(string[] args)
        {
            while (true)
            {
                // PRINT WELCOME TEXT
                Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                Console.WriteLine();

                // PRINT MAIN MENU
                printMainMenu();

                // HANDLE USER INPUT
                Console.Write("Maak een keuze: ");
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
                    case 6:
                        Console.Clear();
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
                            default:
                                break;
                        }

                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        contact_info();
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
