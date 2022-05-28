using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class UserInterface
    {

        public static ConsoleColor MainColor = ConsoleColor.Yellow;
        public static ConsoleColor DefaultColor = ConsoleColor.White;
        public static ConsoleColor ErrorColor = ConsoleColor.Red;
        public static ConsoleColor ConfirmColor = ConsoleColor.Green;

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
        public static void PrintMainMenu(bool authorized)
        {
            
            Console.WriteLine("    [1] Vlucht boeken");
            Console.WriteLine("    [2] Overzicht boekingen");
            Console.WriteLine("    [3] Vluchtschema");
            Console.WriteLine("    [4] Informatie");
            Console.WriteLine();
            Console.WriteLine("    [5] Account");
            Console.WriteLine("    [6] Contact");
            Console.WriteLine("    [7] Afsluiten");
            Console.WriteLine();
        }

        public static void PrintAccountMenu(bool authorized,Customer CurrentUser)
        {
            SetDefaultColor();
            if (!CurrentUser.IsGuest)
            {
                PrintLogo();
                SetMainColor();
                Console.WriteLine($"    Rotterdam Airlines | Account ({CurrentUser.First_name})");
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                SetDefaultColor();
                Console.WriteLine();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Gegevens aanpassen");
                Console.WriteLine("    [2] Overzicht boekingen");
                Console.WriteLine("    [3] Uitloggen");
                Console.WriteLine();
            }
            else
            {
                PrintLogo();
                SetMainColor();
                Console.WriteLine("    Rotterdam Airlines | Account");
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                SetDefaultColor();
                Console.WriteLine();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Inloggen");
                Console.WriteLine("    [2] Registreren");
                Console.WriteLine("    [3] Wachtwoord Vergeten");
                Console.WriteLine();
            }
        }

        public static void PrintInlogMenu(string Email, string Password)
        {
            PrintLogo();
            SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Account | Inloggen");
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            SetDefaultColor();
            Console.WriteLine($"    [0] Terug");
            Console.WriteLine();
            Console.WriteLine($"    [1] Email                          - {Email}");
            string HiddenPassword = "";
            for(int i = 0; Password.Length > i ; i++)
            {
                HiddenPassword += "*";
            }
            Console.WriteLine($"    [2] Password                       - {HiddenPassword}");
            Console.WriteLine();
            Console.WriteLine($"    [3] Inloggen");
            Console.WriteLine();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            SetMainColor();
            Console.Write("    Maak een keuze: ");
            SetDefaultColor();
        }
        public static void PrintRegisterMenu(Customer CurrentUser)
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Account | Registreren");
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine($"    [0] Annuleren         ");
            Console.WriteLine();
            Console.WriteLine($"    [1] Email                          - {CurrentUser.Email}");
            string HiddenPassword = "";
            if(CurrentUser.Password != null)
            {
                for (int i = 0; CurrentUser.Password.Length > i; i++)
                {
                     HiddenPassword += "*";
                }
            }
            Console.WriteLine($"    [2] Wachtwoord                     - {HiddenPassword}");
            Console.WriteLine($"    [3] Voornaam                       - {CurrentUser.First_name}");
            if(CurrentUser.Prefix == null || CurrentUser.Prefix == "") { Console.WriteLine($"    [4] Achternaam en Tussenvoegsel    - {CurrentUser.Last_name} {CurrentUser.Prefix}"); } 
            else { Console.WriteLine($"    [4] Achternaam en Tussenvoegsel    - {CurrentUser.Last_name}, {CurrentUser.Prefix}"); }
            Console.WriteLine($"    [5] Land                           - {CurrentUser.Country}");
            Console.WriteLine($"    [6] Geslacht                       - {CurrentUser.Gender}");
            Console.WriteLine($"    [7] Geboortedatum                  - {CurrentUser.Birth_date}");
            Console.WriteLine($"    [8] Telefoonnummer                 - {CurrentUser.Phone_number}");
            Console.WriteLine();
            Console.WriteLine($"    [9] Account Creëren       ");
            Console.WriteLine();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
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
            Console.WriteLine();
            Console.WriteLine($"    [4] Terug");
        }

        public static void SetMainColor()
        {
            Console.ForegroundColor = MainColor;
        }

        public static void SetDefaultColor()
        {
            Console.ForegroundColor = DefaultColor;
        }

        public static void SetErrorColor()
        {
            Console.ForegroundColor = ErrorColor;
        }

        public static void SetConfirmColor()
        {
            Console.ForegroundColor = ConfirmColor;
        }
    }
}
