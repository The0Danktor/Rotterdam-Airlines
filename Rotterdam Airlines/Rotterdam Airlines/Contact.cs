using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class Contact
    {
        public Contact()
        { }

        public static void PrintContactInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    # Rotterdam Airlines | Contact");
            Console.WriteLine();
            Console.WriteLine("    Adres");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    Rotterdam Airlines");
            Console.WriteLine("    Driemanssteeweg 107");
            Console.WriteLine("    3011 WN Rotterdam");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Telefoonnummer");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    010 446 3444");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    E-mail");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    RotterdamAirlines2022@outlook.com");
            Console.WriteLine();
            Console.WriteLine("    # ----------------------------------------------------------------------------------- #");
            Console.WriteLine();
            Console.WriteLine("    0: Hoofdmenu");
            Console.WriteLine("    1: Contact opnemen");
            Console.WriteLine();
            Console.WriteLine("    # ----------------------------------------------------------------------------------- #");
            Console.WriteLine();
        }

        public static List<string> GetContactInfo()
        {
            List<string> ContactInfo = new List<string>();
            // FIRST NAME INPUT
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Wat is uw voornaam?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("    ");
                string contact_first_name = Console.ReadLine();
                Console.WriteLine();
                if (contact_first_name.All(Char.IsLetter))
                {
                    ContactInfo.Add(contact_first_name);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    Onjuiste invoer. Probeer opniew. (U mag alleen letters gebruiken)");
                    Console.WriteLine();
                }
            }

            // LAST NAME INPUT
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Wat is uw achternaam?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("    ");
                string contact_last_name = Console.ReadLine();
                Console.WriteLine();
                if (contact_last_name.All(Char.IsLetter))
                {
                    ContactInfo.Add(contact_last_name);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    Onjuiste invoer. Probeer opniew. (U mag alleen letters gebruiken)");
                    Console.WriteLine();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Wat is uw emailadres?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("    ");
                string contact_email = Console.ReadLine();
                Console.WriteLine();
                if (contact_email.Contains("@") && contact_email.Contains("."))
                {
                    ContactInfo.Add(contact_email);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                    Console.WriteLine();
                }
            }


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Wat is het onderwerp van uw bericht?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");
            string contact_subject = Console.ReadLine();
            Console.WriteLine();
            ContactInfo.Add(contact_subject);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Wat is uw vraag/opmerking?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");
            string contact_message = Console.ReadLine();
            Console.WriteLine();
            ContactInfo.Add(contact_message);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    Bedankt voor uw bericht! We doen ons best om u binnen 24 uur een antwoord te sturen.");
            Console.WriteLine("    Klik op 'ENTER' om het bericht te versturen en terug te gaan naar het hoofdmenu.");
            Console.ReadLine();

            return ContactInfo;
        }

        public static void SendEmail(List<string> ContactInfo, SmtpClient smtpClient)
        {
            string FirstName = ContactInfo.ElementAt(0);
            string LastName = ContactInfo.ElementAt(1);
            string Email = ContactInfo.ElementAt(2);
            string Subject = ContactInfo.ElementAt(3);
            string Message = ContactInfo.ElementAt(4);

            var mailMessage = new MailMessage
            {
                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "subject",
                Body = String.Format("<h4><b>Naam:</b> {0} {1}</h4>\n<h4><b>Email:</b> {2}</h4>\n<h4><b>Subject:</b> {3}</h4>\n<h4> <b>Message:</b> </h4>\n<p>{4}</p>", FirstName, LastName, Email, Subject, Message),
                IsBodyHtml = true,
            };
            mailMessage.To.Add("RotterdamAirlines2022@outlook.com");
            mailMessage.To.Add(Email);

            smtpClient.Send(mailMessage);
        }

    }
}
