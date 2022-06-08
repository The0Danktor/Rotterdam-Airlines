using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Admin : User
    {
        public Admin(string email, string password) : base(email, password)
        {
            this.Email = email;
            this.Password = password;
        }

        private static bool RemoveUser()
        {
            List<Customer> user_list = JSON.LoadCustomersJSON();
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

                if (input.ToLower() == user_list[user_count].Email.ToLower())
                {
                    check = true;
                    break;
                }
                user_count += 1;
            }
            if (check == false)
            {
                Console.WriteLine();
                UserInterface.SetErrorColor();
                Console.WriteLine("    Er bestaat geen gebruiker met deze email");
                return false;
            }

            Console.Clear();
            bool remove_confirm_bool = true;
            while (remove_confirm_bool)
            {
                Admin.PrintRemoveUserConfirmScreen();
                foreach (var user in user_list)
                {
                    if (input.ToLower() == user_list[count].Email.ToLower())
                    {
                        check = true;
                        int choice = count;

                        Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                        Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                        Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                        Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                        Console.WriteLine("    Land:                 " + user_list[choice].Country);
                        Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                        Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                        Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                        Console.WriteLine("    Email:                " + user_list[choice].Email);
                        Console.WriteLine();
                        UserInterface.SetMainColor();
                        Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        Console.WriteLine();
                        break;
                    }
                    count += 1;
                }
                UserInterface.SetMainColor();
                Console.WriteLine("    Weet u zeker dat u deze gebruiker wilt verwijderen?");
                Console.Write("    ");
                UserInterface.SetDefaultColor();
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
                        if (input.ToLower() == user_list[count].Email.ToLower() && confirm == 2)
                        {
                            email_check = true;
                            int choice = count;
                            string user_id = user_list[count].UserId;
                            IdHandler.removeID(user_id);
                            user_list.RemoveAt(count);
                            JSON.SaveCustomersJSON(user_list);

                            Console.WriteLine();
                            UserInterface.SetConfirmColor();
                            Console.WriteLine("    Gebruiker Verwijderd");
                            remove_confirm_bool = false;
                            break;
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
                    Console.ReadLine();
                }
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
                        if (user_input.ToLower() == user_list[number].Email.ToLower() || user_input.ToLower() == user_list[number].First_name.ToLower() || user_input.ToLower() == user_list[number].Prefix.ToLower() || user_input.ToLower() == user_list[number].Last_name.ToLower() || user_input.ToLower() == user_list[number].Country.ToLower() || user_input.ToLower() == user_list[number].Gender.ToLower() || user_input.ToLower() == user_list[number].Birth_date.ToLower() || user_input.ToLower() == user_list[number].Phone_number.ToLower() || user_input.ToLower() == user_list[number].UserId.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Email.ToLower() || user_input.ToLower() == user_list[count].First_name.ToLower() || user_input.ToLower() == user_list[count].Prefix.ToLower() || user_input.ToLower() == user_list[count].Last_name.ToLower() || user_input.ToLower() == user_list[count].Country.ToLower() || user_input.ToLower() == user_list[count].Gender.ToLower() || user_input.ToLower() == user_list[count].Birth_date.ToLower() || user_input.ToLower() == user_list[count].Phone_number.ToLower() || user_input.ToLower() == user_list[count].UserId.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].UserId.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].UserId.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].First_name.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].First_name.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Prefix.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Prefix.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Last_name.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Last_name.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Country.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Country.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Gender.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Gender.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Birth_date.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Birth_date.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Phone_number.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (input.ToLower() == user_list[count].Phone_number.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
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
                        if (user_input.ToLower() == user_list[number].Email.ToLower())
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input.ToLower() == user_list[count].Email.ToLower())
                        {
                            check = true;
                            int choice = count;
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    GebruikersID:         " + user_list[choice].UserId);
                            Console.WriteLine("    Voornaam:             " + user_list[choice].First_name);
                            Console.WriteLine("    Tussenvoegsel:        " + user_list[choice].Prefix);
                            Console.WriteLine("    Achternaam:           " + user_list[choice].Last_name);
                            Console.WriteLine("    Land:                 " + user_list[choice].Country);
                            Console.WriteLine("    Geslacht:             " + user_list[choice].Gender);
                            Console.WriteLine("    Geboortedatum:        " + user_list[choice].Birth_date);
                            Console.WriteLine("    Telefoonnummer:       " + user_list[choice].Phone_number);
                            Console.WriteLine("    Email:                " + user_list[choice].Email);
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                        }
                        count += 1;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine();
                    UserInterface.SetErrorColor();
                    Console.WriteLine("    Er bestaan geen gebruikers met deze gegevens");
                    return false;
                }
            }
            else
            {
                Console.WriteLine();
                UserInterface.SetErrorColor();
                Console.WriteLine("    Verkeerde input");
                Console.ReadLine();
            }
            return false;
        }

        public static bool PrintAdminMainScreen()
        {
            Console.Clear();
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Admin");
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [1] Gebruiker Opzoeken");
            Console.WriteLine("    [2] Gebruiker Verwijderen");
            Console.WriteLine();
            Console.WriteLine("    [3] Vluchten");
            Console.WriteLine("    [4] Boekingen");
            Console.WriteLine();
            Console.WriteLine("    [5] Uitloggen");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
            var AdminInput = Console.ReadKey(true);

            bool admin_bool = true;
            while (admin_bool)
            {
                switch (AdminInput.Key)
                {
                    case ConsoleKey.D0:
                        admin_bool = false;
                        Console.Clear();
                        break;
                    case ConsoleKey.D1:
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
                    case ConsoleKey.D2:
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
                    case ConsoleKey.D3:
                        Admin.PrintAdminFlightScreen();
                        admin_bool = false;
                        Console.Clear();
                        break;

                    case ConsoleKey.D4:
                        Admin.PrintAdminBookingScreen();
                        admin_bool = false;
                        Console.Clear();
                        break;

                    case ConsoleKey.D5:
                        return false;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("    Verkeerde menu input. Klik een willekeurige toets om het opnieuw te proberen...");
                        admin_bool = false;
                        Console.ReadKey(true);
                        break;
                }
            }
            return true;
        }

        private static void PrintAdminBookingScreen()
        {
            bool ViewingBookingScreen = true;
            while (ViewingBookingScreen)
            {
                List<Flight> Flights = JSON.LoadFlightsJSON();
                List<Booking> Bookings = JSON.LoadBookingsJSON();
                Flight FlightTarget = null;
                Booking BookingTarget = null;
                Console.Clear();
                UserInterface.PrintLogo();
                UserInterface.SetMainColor();
                Console.WriteLine("    Rotterdam Airlines | Boekingen");
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetDefaultColor();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Boeking Opzoeken");
                Console.WriteLine("    [2] Boeking Annuleren");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();

                var InputBookingScreen = Console.ReadKey(true);
                switch (InputBookingScreen.Key)
                {
                    case ConsoleKey.D0:
                        ViewingBookingScreen = false;
                        break;

                    case ConsoleKey.D1:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("    Vul een boekingcode in: ");
                        UserInterface.SetDefaultColor();
                        var InputBookingID = Console.ReadLine();
                        for (int i = 0; i < Bookings.Count; i++)
                        {
                            if (Bookings[i].BookingID == InputBookingID) { BookingTarget = Bookings[i]; }
                        }
                        if (BookingTarget == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("    Boeking met boekingcode (" + InputBookingID + ") niet gevonden.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                            Console.ReadKey(true);
                        } else
                        {
                            Console.Clear();
                            for (int i = 0; i < Flights.Count; i++)
                            {
                                if (BookingTarget.FlightCode == Flights[i].FlightCode) { FlightTarget = Flights[i]; }
                            }
                            Console.Clear();
                            TextInfo textInfo = new CultureInfo("nl-NL", false).TextInfo;
                            CultureInfo Dutch = new CultureInfo("nl-NL", false);
                            DateTime DepartureInfo = FlightTarget.Departure;
                            string Departure = DepartureInfo.ToString("MMMM", Dutch);
                            Departure = textInfo.ToTitleCase(Departure);
                            UserInterface.SetDefaultColor();
                            UserInterface.PrintLogo();
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            if (BookingTarget.Cancelled == true)
                            {
                                Console.WriteLine("    Rotterdam Airlines | Boeking (" + BookingTarget.BookingID + ") - GEANNULEERD");
                            } else
                            {
                                Console.WriteLine("    Rotterdam Airlines | Boeking (" + BookingTarget.BookingID + ")");
                            }
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            Console.WriteLine("    Vluchtcode    Vluchtnummer     Bestemming           Vertrek");
                            UserInterface.SetDefaultColor();
                            Console.WriteLine();
                            Console.WriteLine("    " + FlightTarget.FlightCode + "\t  " + FlightTarget.FlightNumber + "\t   " + FlightTarget.Destination + " \t\t" + DepartureInfo.Day + " " + Departure + " " + DepartureInfo.TimeOfDay + "\t< Gekozen Vlucht");
                            Console.WriteLine();
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Persoonsgegevens");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            foreach (BookingPerson person in BookingTarget.BookingPersons)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"    {person.GetFullname()}");
                                Console.WriteLine();
                                Console.WriteLine($"        Land                            - {person.CustomerCountry}");
                                Console.WriteLine($"        Geslacht                        - {person.CustomerGender}");
                                Console.WriteLine($"        Geboortedatum                   - {person.CustomerBirthDate}");
                                Console.WriteLine($"        BSN                             - {person.CustomerBSN}");
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Contactgegevens");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            Console.WriteLine();
                            Console.WriteLine($"    Email                                - {BookingTarget.CustomerEmail}");
                            Console.WriteLine($"    Telefoonnummer                       - {BookingTarget.CustomerPhoneNumber}");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.WriteLine("    Stoelen");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            foreach (Seat seat in BookingTarget.SeatList)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"    Stoel {seat.Id}");
                                Console.WriteLine();
                                Console.WriteLine($"        Klasse                          - {seat.SeatClass}");
                                Console.WriteLine($"        Bijzonderheden                  - {seat.Special}");
                                Console.WriteLine($"        Prijs                           - {seat.Price}");
                            }
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.WriteLine("    Prijs");
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            UserInterface.SetDefaultColor();
                            Console.WriteLine();
                            foreach (Seat seat in BookingTarget.SeatList)
                            {
                                Console.WriteLine($"    Stoel {seat.Id}                            - €{seat.Price}");
                            }
                            Console.WriteLine($"                                        ─────────── +");
                            Console.WriteLine($"    Totaal                              - €{BookingTarget.BookingPrice}");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    ──────────────────────────────────────────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            Console.WriteLine("    Klik op een willekeurige toets om terug naar het hoofdmenu te gaan");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;

                    case ConsoleKey.D2:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("    Vul een boekingcode in: ");
                        UserInterface.SetDefaultColor();
                        var InputCancelBookingID = Console.ReadLine();
                        for (int i = 0; i < Bookings.Count; i++)
                        {
                            if (Bookings[i].BookingID == InputCancelBookingID) { BookingTarget = Bookings[i]; }
                        }
                        if (BookingTarget == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("    Boeking met boekingcode (" + InputCancelBookingID + ") niet gevonden.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                            Console.ReadKey(true);
                        } else
                        {
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Weet u zeker dat u boeking (" + InputCancelBookingID + ") wil annuleren?");
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    [1] Ja");
                            Console.WriteLine("    [2] Nee");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            var InputCancelBookingConfirmation = Console.ReadKey();
                            if(InputCancelBookingConfirmation.Key == ConsoleKey.D1)
                            {
                                CancelBooking(BookingTarget);
                                Console.WriteLine();
                                Console.WriteLine();
                                UserInterface.SetConfirmColor();
                                Console.WriteLine("    Boeking succesvol geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                Console.ReadKey(true);
                            } else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("    Boeking niet geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                Console.ReadKey(true);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("    Verkeerde menu input. Klik een willekeurige toets om het opnieuw te proberen...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        
        private static void PrintAdminFlightScreen()
        {
            bool ViewingFlightScreen = true;
            while(ViewingFlightScreen)
            {
                List<Flight> Flights = JSON.LoadFlightsJSON();
                List<Booking> Bookings = JSON.LoadBookingsJSON();
                Flight FlightTarget = null;
                Booking BookingTarget = null;
                Console.Clear();
                UserInterface.PrintLogo();
                UserInterface.SetMainColor();
                Console.WriteLine("    Rotterdam Airlines | Vluchten");
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetDefaultColor();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Vlucht Opzoeken");
                Console.WriteLine("    [2] Vlucht Annuleren");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();

                var InputFlightScreen = Console.ReadKey(true);
                switch (InputFlightScreen.Key)
                {
                    case ConsoleKey.D0:
                        ViewingFlightScreen = false;
                        break;

                    case ConsoleKey.D1:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("    Vul een vluchtcode in: ");
                        UserInterface.SetDefaultColor();
                        var InputFlightCode = Console.ReadLine();

                        for (int i = 0; i < Flights.Count; i++)
                        {
                            if (InputFlightCode == Flights[i].FlightCode) { FlightTarget = Flights[i]; break; }
                        }

                        if (FlightTarget == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("    Vlucht met vluchtcode (" + InputFlightCode + ") niet gevonden.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                            Console.ReadKey(true);
                            break;
                        } else
                        {
                            Console.Clear();
                            UserInterface.PrintLogo();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Rotterdam Airlines | Vlucht: #" + InputFlightCode);
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    Vluchtcode           - " + FlightTarget.FlightCode);
                            Console.WriteLine("    Vluchtnummer         - " + FlightTarget.FlightNumber);
                            Console.WriteLine("    Vliegtuig Type       - " + FlightTarget.PlaneType);
                            Console.WriteLine("    Airline              - " + FlightTarget.Airline);
                            Console.WriteLine("");
                            Console.WriteLine("    Bestemming           - " + FlightTarget.Destination);
                            Console.WriteLine("    Vliegveld            - " + FlightTarget.DestinationAirport);
                            Console.WriteLine("    Vertrektijd          - " + FlightTarget.Departure);
                            Console.WriteLine();
                            if (FlightTarget.Cancelled)
                            {
                                Console.WriteLine("    Geannuleerd          - Ja");
                            } else
                            {
                                Console.WriteLine("    Geannuleerd          - Nee");
                            }
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    ───────────────────────────────────────────────────────────────────");
                            Console.WriteLine();
                            Console.WriteLine("    Klik op een willekeurige toets om terug te gaan");
                            Console.ReadKey(true);
                        }
                        break;

                    case ConsoleKey.D2:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("    Vul een vluchtcode in: ");
                        UserInterface.SetDefaultColor();
                        var InputFlightCodeCancel = Console.ReadLine();

                        for (int i = 0; i < Flights.Count; i++)
                        {
                            if (InputFlightCodeCancel == Flights[i].FlightCode) { FlightTarget = Flights[i]; break; }
                        }

                        if (FlightTarget == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("    Vlucht met vluchtcode (" + InputFlightCodeCancel + ") niet gevonden.\n    Klik op een willekeurige toets om het opnieuw te proberen");
                            Console.ReadKey(true);
                            break;
                        }
                        else {
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.WriteLine("    Weet u zeker dat u vlucht (" + InputFlightCodeCancel + ") wil annuleren?");
                            Console.WriteLine();
                            UserInterface.SetDefaultColor();
                            Console.WriteLine("    [1] Ja");
                            Console.WriteLine("    [2] Nee");
                            Console.WriteLine();
                            UserInterface.SetMainColor();
                            Console.Write("    Maak een keuze: ");
                            var InputCancelBookingConfirmation = Console.ReadKey();
                            if (InputCancelBookingConfirmation.Key == ConsoleKey.D1)
                            {
                                foreach (Booking booking in Bookings)
                                {
                                    if (booking.FlightCode == InputFlightCodeCancel)
                                    {
                                        CancelBooking(booking);
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                UserInterface.SetConfirmColor();
                                Console.WriteLine("    Vlucht succesvol geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                Console.ReadKey(true);
                                FlightTarget.Cancelled = true;
                                JSON.SaveFlightsJSON(Flights);
                            } else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("    Vlucht niet geannuleerd. Klik een willekeurige toets om verder te gaan.");
                                Console.ReadKey(true);
                                FlightTarget.Cancelled = true;
                                JSON.SaveFlightsJSON(Flights);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("    Verkeerde menu input. Klik een willekeurige toets om het opnieuw te proberen...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void PrintAdminSubScreen(string screen, string question)
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Admin | " + screen);
            Console.WriteLine("    ─────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    " + question);
            UserInterface.SetDefaultColor();
            Console.Write("    ");
        }

        private static void PrintSearchUserInfoSubScreen(string screen, string question)
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Admin | " + screen);
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            UserInterface.SetMainColor();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    " + question);
            UserInterface.SetDefaultColor();
            Console.Write("    ");
        }
        private static void PrintRemoveUserConfirmScreen()
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Admin | Gebruiker Verwijderen");
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine("    [2] Gebruiker Verwijderen");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
        }

        private static void PrintUserInfoSubScreen()
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Admin | Gebruiker Opzoeken");
            Console.WriteLine("    ──────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
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
            UserInterface.SetDefaultColor();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
        }

        private static void PrintNumberOfResults(int user_count)
        {
            if (user_count >= 0 && user_count != 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.WriteLine("    " + user_count + " Resultaten");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            }
            if (user_count == 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.WriteLine("    " + user_count + " Resultaat");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            }
        }

        public static void CancelBooking(Booking CancelBooking)
        {
            Console.Clear();
            Console.CursorVisible = false;
            List<Booking> bookings = JSON.LoadBookingsJSON();
            Dictionary<string, List<Seat>> seatJson = JSON.LoadSeatsJSON();
            Console.CursorVisible = true;

            foreach (Seat seat in seatJson[CancelBooking.FlightCode])
            {
                foreach (Seat bookedSeat in CancelBooking.SeatList)
                {
                    if (seat.Id == bookedSeat.Id)
                    {
                        seat.Occupant = null;
                    }
                }
            }
            JSON.SaveSeatsJSON(seatJson);

            foreach(Booking booking in bookings)
            {
                if(booking.BookingID == CancelBooking.BookingID)
                {
                    booking.Cancelled = true;
                }
            }
            JSON.SaveBookingsJSON(bookings);
        }
    }
}