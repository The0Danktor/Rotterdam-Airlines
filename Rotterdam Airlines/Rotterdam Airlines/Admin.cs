using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Admin : User
    {
        public Admin(string email, string password) : base(email, password)
        {
            this.email = email;
            this.password = password;
        }

        private static bool RemoveUser()
        {
            List <Customer> user_list = JSON.LoadCustomersJSON();
            int count = 0;
            bool email_check = false;
            string input = Console.ReadLine();

            foreach (var user in user_list)
            {
                if (input == user_list[count].email)
                {
                    email_check = true;
                    int choice = count;
                    string user_id = user_list[count].UserId;
                    IdHandler.removeID(user_id);
                    user_list.RemoveAt(count);
                    JSON.SaveCustomersJSON(user_list);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("    Gebruiker Verwijderd");
                    return true;
                }
                count += 1;
            }

            if (email_check == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Er bestaat geen gebruiker met deze email");
            }
            return false;
        }

        private static bool PrintUserInfoScreen()
        {
            List<Customer> user_list = JSON.LoadCustomersJSON();
            int count = 0;
            bool email_check = false;
            string input = Console.ReadLine();

            foreach (var user in user_list)
            {
                if (input == user_list[count].email)
                {
                    email_check = true;
                    int choice = count;
                    Console.WriteLine();
                    Console.WriteLine("    ─────────────────────────────────────────────────────────");
                    Console.WriteLine();
                    Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                    Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                    Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                    Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                    Console.WriteLine("    Land:                 " + user_list[choice].Country);
                    Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                    Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                    Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                    Console.WriteLine("    Email:                " + user_list[choice].email);
                    Console.WriteLine("    Wachtwoord:           " + user_list[choice].password);
                    return true; 
                }
                count += 1;
            }

            if (email_check == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Er bestaat geen gebruiker met deze email");
            }
            return false;
        }

        public static void PrintAdminMainScreen()
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin");
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine();
            Console.WriteLine("    [1] Gebruiker Opzoeken");
            Console.WriteLine("    [2] Gebruiker Verwijderen");
            Console.WriteLine();
            Console.WriteLine("    [3] Vluchten Opzoeken");
            Console.WriteLine("    [4] Vluchten Wijzigen");
            Console.WriteLine();
            Console.WriteLine("    [5] Boekingen Opzoeken");
            Console.WriteLine("    [6] Boekingen Wijzigen");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("    Maak een keuze: ");
            Console.ForegroundColor = ConsoleColor.White;

            bool admin_bool = true;
            string input = Console.ReadLine();
            int choice = int.Parse(input);

            while (admin_bool) 
            {
                switch (choice)
                {
                    case 0:
                        admin_bool = false;
                        Console.Clear();
                        break;
                    case 1:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Gebruiker Opzoeken";
                            string question = "Wat is de email van de gebruiker die u wilt opzoeken?";
                            PrintAdminSubScreen(screen, question);
                            if (Admin.PrintUserInfoScreen())
                            {
                                admin_bool = false;
                            } 

                            else
                            {
                                admin_bool = true;
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    case 2:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Gebruiker Verwijderen";
                            string question = "Wat is de email van de gebruiker die u wilt verwijderen?";
                            PrintAdminSubScreen(screen, question);
                            if (Admin.RemoveUser())
                            {
                                admin_bool = false;
                            }

                            else
                            {
                                admin_bool = true;
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    case 3:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Vluchten Opzoeken";
                            string question = "Wat is de vluchtcode van de vlucht die u wilt Opzoeken?";
                            PrintAdminSubScreen(screen, question);
                            Console.ReadLine();
                            admin_bool = false;
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    case 4:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Vluchten Wijzigen";
                            string question = "Wat is de vluchtcode van de vlucht die u wilt wijzigen?";
                            PrintAdminSubScreen(screen, question);
                            Console.ReadLine();
                            admin_bool = false;
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    case 5:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Boekingen Opzoeken";
                            string question = "Wat is de email van de gebruiker waarvan u de boeking wilt opzoeken?";
                            PrintAdminSubScreen(screen, question);
                            Console.ReadLine();
                            admin_bool = false;
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    case 6:
                        while (admin_bool)
                        {
                            Console.Clear();
                            string screen = "Boekingen Wijzigen";
                            string question = "Wat is de email van de gebruiker waarvan u de boeking wilt wijzigen?";
                            PrintAdminSubScreen(screen, question);
                            Console.ReadLine();
                            admin_bool = false;
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                }
            }
        }

        private static void PrintAdminSubScreen(string screen, string question)
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin | " + screen);
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.WriteLine("    " + question);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");
        }
    }
}