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

                if (input == user_list[user_count].Email)
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
                    if (input == user_list[count].Email)
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
                        if (input == user_list[count].Email && confirm == 2)
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
                        if (user_input == user_list[number].Email || user_input == user_list[number].First_name || user_input == user_list[number].Prefix || user_input == user_list[number].Last_name || user_input == user_list[number].Country || user_input == user_list[number].Gender || user_input == user_list[number].Birth_date || user_input == user_list[number].Phone_number || user_input == user_list[number].UserId)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Email || user_input == user_list[count].First_name || user_input == user_list[count].Prefix || user_input == user_list[count].Last_name || user_input == user_list[count].Country || user_input == user_list[count].Gender || user_input == user_list[count].Birth_date || user_input == user_list[count].Phone_number || user_input == user_list[count].UserId)
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
                        if (user_input == user_list[number].First_name)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].First_name)
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
                        if (user_input == user_list[number].Prefix)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Prefix)
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
                        if (user_input == user_list[number].Last_name)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Last_name)
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
                        if (user_input == user_list[number].Country)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Country)
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
                        if (user_input == user_list[number].Gender)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Gender)
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
                        if (user_input == user_list[number].Birth_date)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Birth_date)
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
                        if (user_input == user_list[number].Phone_number)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (input == user_list[count].Phone_number)
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
                        if (user_input == user_list[number].Email)
                        {
                            user_count += 1;
                        }
                        number += 1;
                    }
                    Admin.PrintNumberOfResults(user_count);

                    foreach (var user in user_list)
                    {
                        if (user_input == user_list[count].Email)
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
            bool admin_bool = true;
            while (admin_bool)
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
                Console.WriteLine("    ─────────────────────────────────────────────────────────");
                Console.WriteLine();
                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();
                var AdminInput = Console.ReadKey(true);
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

                        break;

                    default:
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
    }
}