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
            int user_count = 0;
            bool email_check = false;
            bool check = false;

            string input = Console.ReadLine();
            if (input == "0")
            {
                return true;
            }

            foreach (var user in user_list)
            {
                if (input == user_list[user_count].email)
                {
                    check = true;
                    break;
                }
                user_count += 1;
            }
            if (check == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Er bestaat geen gebruiker met deze email");
                return false;
            }

            Console.Clear();
            Admin.PrintRemoveUserConfirmScreen();
            foreach (var user in user_list)
            {
                if (input == user_list[count].email)
                {
                    check = true;
                    int choice = count;
                    Console.WriteLine();
                    Console.WriteLine("    ─────────────────────────────────────────────────────────");
                    Console.WriteLine();
                    Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                    Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                    Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                    Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                    Console.WriteLine("    Land:                 " + user_list[choice].country);
                    Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                    Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                    Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                    Console.WriteLine("    Email:                " + user_list[choice].email);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine();
                    break;
                }
                count += 1;
            }
            Console.WriteLine("    Weet u zeker dat u deze gebruiker wilt verwijderen?");
            Console.Write("    ");
            Console.ForegroundColor = ConsoleColor.White;
            string confirm_input = Console.ReadLine();

            if (confirm_input == "0" || confirm_input == "1" || confirm_input == "2")
            {
                int confirm = int.Parse(confirm_input);

                if (confirm == 0)
                {
                    return true;
                }
                else if (confirm == 1)
                {
                    return false;
                }

                foreach (var user in user_list)
                {
                    if (input == user_list[count].email && confirm == 2)
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
                        return false;
                    }
                    count += 1;
                }

                if (email_check == false && confirm == 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er bestaat geen gebruiker met deze email");
                    return false;
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Verkeerde input");
                return false;
            }
            return false;
        }

        private static bool PrintUserInfoScreen()
        {
            List<Customer> user_list = JSON.LoadCustomersJSON();
            int count = 0;
            int user_count = 0;
            int number = 0;
            bool check = false;

            Admin.PrintUserInfoSubScreen();
            string input = Console.ReadLine();
            string question = "";
            string screen = "Gebruiker Opzoeken";

            if (input == "0" || input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10")
            {
                int input_int = int.Parse(input);

                if (input_int == 0)
                {
                    return true;
                }
                else if (input_int == 1)
                {
                    Console.Clear();
                    question = "Wat is het woord waar u naar wilt zoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].email || user_input == user_list[number].first_name || user_input == user_list[number].prefix || user_input == user_list[number].last_name || user_input == user_list[number].country || user_input == user_list[number].gender || user_input == user_list[number].birth_date || user_input == user_list[number].phone_number || user_input == user_list[number].UserId)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].email || user_input == user_list[count].first_name || user_input == user_list[count].prefix || user_input == user_list[count].last_name || user_input == user_list[count].country || user_input == user_list[count].gender || user_input == user_list[count].birth_date || user_input == user_list[count].phone_number || user_input == user_list[count].UserId)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 2)
                {
                    Console.Clear();
                    question = "Wat is de gebruikersID van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].UserId)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].UserId)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 3)
                {
                    Console.Clear();
                    question = "Wat is de voornaam van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].first_name)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].first_name)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 4)
                {
                    Console.Clear();
                    question = "Wat is het tussenvoegsel van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].prefix)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].prefix)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 5)
                {
                    Console.Clear();
                    question = "Wat is de achternaam van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].last_name)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].last_name)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 6)
                {
                    Console.Clear();
                    question = "Wat is het land van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].country)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].country)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 7)
                {
                    Console.Clear();
                    question = "Wat is het geslacht van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].gender)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].gender)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 8)
                {
                    Console.Clear();
                    question = "Wat is de geboortedatum van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].birth_date)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].birth_date)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 9)
                {
                    Console.Clear();
                    question = "Wat is het telefoonnummer van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].phone_number)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (input == user_list[count].phone_number)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                else if (input_int == 10)
                {
                    Console.Clear();
                    question = "Wat is de email van de gebruiker die u wilt opzoeken?";
                    Admin.PrintSearchUserInfoSubScreen(screen, question);
                    string user_input = Console.ReadLine();

                    if (user_input == "0" || user_input == "1")
                    {
                        int user_input_int = int.Parse(user_input);

                        if (user_input_int == 0)
                        {
                            return true;
                        }
                        else if (user_input_int == 1)
                        {
                            return false;
                        }
                    }

                    foreach (var people in user_list)
                    {
                        if (user_input == user_list[number].email)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].email)
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].first_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].email);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    Er bestaan geen gebruikers met deze gegevens");
                    return false;
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Verkeerde input");
                Console.ReadLine();
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
            if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6")
            {
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
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Verkeerde input");
                Console.ReadLine();
            }
        }

        private static void PrintAdminSubScreen(string screen, string question)
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin | " + screen);
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.WriteLine("    " + question);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");
        }

        private static void PrintSearchUserInfoSubScreen(string screen, string question)
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin | " + screen);
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.WriteLine("    " + question);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");
        }
        private static void PrintRemoveUserConfirmScreen()
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin | Gebruiker Verwijderen");
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine("    [2] Gebruiker Verwijderen");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintUserInfoSubScreen()
        {
            UserInterface.PrintLogo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Rotterdam Airlines | Admin | Gebruiker Opzoeken");
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine();
            Console.WriteLine("    [1] Algemeen");
            Console.WriteLine("    [2] GebruikersID");
            Console.WriteLine("    [3] Voornaam");
            Console.WriteLine("    [4] Tussenvoegsel");
            Console.WriteLine("    [5] Achternaam");
            Console.WriteLine("    [6] Land");
            Console.WriteLine("    [7] Geslacht");
            Console.WriteLine("    [8] Geboortedatum");
            Console.WriteLine("    [9] Telefoonnummer");
            Console.WriteLine("    [10] Email");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.Write("    Maak een keuze: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintNumberOfResults(int user_count)
        {
            if (user_count >= 0 && user_count != 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    " + user_count + " Resultaten");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            }
            if (user_count == 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    " + user_count + " Resultaat");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            }
        }
    }
}