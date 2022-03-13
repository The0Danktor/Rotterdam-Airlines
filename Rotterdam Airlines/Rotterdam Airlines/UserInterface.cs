using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class UserInterface
    {

        public static ConsoleColor MainColor = ConsoleColor.Blue;
        public static ConsoleColor DefaultColor = ConsoleColor.White;

        public UserInterface()
        { }

        // PRINT HET LOGO NAAR DE CONSOLE
        public static void PrintLogo()
        {
            SetDefaultColor();
            Console.WriteLine(@"     _____       _   _               _                          _      _ _                 ");
            Console.WriteLine(@"    |  __ \     | | | |             | |                   /\   (_)    | (_)                ");
            Console.WriteLine(@"    | |__) |___ | |_| |_ ___ _ __ __| | __ _ _ __ ___    /  \   _ _ __| |_ _ __   ___  ___ ");
            Console.WriteLine(@"    |  _  // _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \  / /\ \ | | '__| | | '_ \ / _ \/ __|");
            Console.WriteLine(@"    | | \ \ (_) | |_| ||  __/ | | (_| | (_| | | | | | |/ ____ \| | |  | | | | | |  __/\__ \");
            Console.WriteLine(@"    |_|  \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_/_/    \_\_|_|  |_|_|_| |_|\___||___/");
            Console.WriteLine();
            SetDefaultColor();
        }

        // PRINTS ALL THE OPTIONS OF THE MAIN MENU
        // TO THE CONSOLE.
        public static void PrintMainMenu()
        {
            Console.WriteLine("    [1] Vlucht boeken");
            Console.WriteLine("    [2] Overzicht boekingen");
            Console.WriteLine("    [3] Mededelingen");
            Console.WriteLine("    [4] Aanbiedingen");
            Console.WriteLine("    [5] Informatie");
            Console.WriteLine();
            Console.WriteLine("    [6] Account");
            Console.WriteLine("    [7] Contact");
            Console.WriteLine("    [8] Afsluiten");
            Console.WriteLine();
        }

        public static void PrintAccountMenu(bool authorized)
        {
            UserInterface.SetDefaultColor();
            if (authorized == true)
            {
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Gegevens aanpassen");
                Console.WriteLine("    [2] Overzicht boekingen");
                Console.WriteLine("    [3] Uitloggen");
            }
            else
            {
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Inloggen");
                Console.WriteLine("    [2] Registreren");
                Console.WriteLine("    [3] Wachtwoord vergeten");
                Console.WriteLine();
            }
        }

        public static void PrintRegisterMenu(Customer CurrentUser)
        {
            Console.WriteLine($"    0: Terug          ");
            Console.WriteLine();
            Console.WriteLine($"    1: Email          - {CurrentUser.email}");
            Console.WriteLine($"    2: Wachtwoord     - {CurrentUser.password}");
            Console.WriteLine($"    3: Naam           - {CurrentUser.first_name}");
            Console.WriteLine($"    4: Achternaam     - {CurrentUser.last_name}");
            Console.WriteLine($"    5: Land           - {CurrentUser.country}");
            Console.WriteLine($"    6: Geslacht       - {CurrentUser.gender}");
            Console.WriteLine($"    7: Geboortedatum  - {CurrentUser.birth_date}");
            Console.WriteLine($"    8: Telefoonnummer - {CurrentUser.phone_number}");
            Console.WriteLine();
            Console.WriteLine($"    9: Afronden       ");
            Console.WriteLine();
        }
        public static void PrintInfoMenu()
        {
            Console.WriteLine($"    [0] Hoofdmenu");
            Console.WriteLine();
            Console.WriteLine($"    [1] Faciliteiten");
            Console.WriteLine($"    [2] Laatste nieuws");
            Console.WriteLine($"    [3] Onze vliegtuigen");
            Console.WriteLine($"    [4] Veelgestelde vragen");

        }

        public static void PrintFaciliteitenMenu()
        {
            Console.WriteLine($"    [0] Hoofdmenu");
            Console.WriteLine();
            Console.WriteLine($"    [1] Winkelen");
            Console.WriteLine($"    [2] Eetgelegenheden");
            Console.WriteLine($"    [3] Recreatie");

        }


        public static void SetMainColor()
        {
            Console.ForegroundColor = MainColor;
        }

        public static void SetDefaultColor()
        {
            Console.ForegroundColor = DefaultColor;
        }
    }
}
