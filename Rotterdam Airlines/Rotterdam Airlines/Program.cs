using System;

namespace Rotterdam_Airlines
{
    internal class Program
    {
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
        static void Main(string[] args)
        {

            while(true)
            {
                // PRINT WELCOME TEXT
                Console.WriteLine("Welkom bij het boekingsysteem van Rotterdam Airlines.");
                Console.WriteLine();

                // PRINT MAIN MENU
                printMainMenu();

                // HANDLE USER INPUT
                Console.Write("Maak een keuze: ");
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                switch(choice)
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
                        break;
                    case 7:
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
