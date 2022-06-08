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

        // PRINT DE CONTACTINFORMATIE VAN ROTTERDAMAIRLINES
        // NAAR DE CONSOLE
        public static void PrintContactInfo()
        {
            UserInterface.PrintLogo();
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Contact");
            Console.WriteLine("    ────────────────────────────");
            UserInterface.SetDefaultColor();
            Console.WriteLine();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine();
            Console.WriteLine("    [1] Contact opnemen");
            Console.WriteLine();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Adres                    Telefoonnummer      E-mail");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Rotterdam Airlines       010 446 3444        RotterdamAirlines2022@outlook.com");
            Console.WriteLine("    Driemanssteeweg 107");
            Console.WriteLine("    3011 WN Rotterdam");
            Console.WriteLine();
            Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
        }

        // VRAAGT DE GEBRUIKER OM INPUT VOOR
        // DE CONTACTGEGEVENS
        public static List<string> GetContactInfo()
        {
            List<string> ContactInfo = new List<string>();
            bool Creating = true;

            string contact_first_name = null;
            string contact_last_name = null;
            string contact_email = null;
            string contact_subject = null;
            string contact_message = null;

            while (Creating)
            {
                UserInterface.PrintLogo();
                UserInterface.SetMainColor();
                Console.WriteLine("    Rotterdam Airlines | Contact Opnemen");
                Console.WriteLine("    ────────────────────────────────────");
                UserInterface.SetDefaultColor();
                Console.WriteLine();
                Console.WriteLine("    [0] Hoofdmenu        ");
                Console.WriteLine();
                Console.WriteLine("    [1] Voornaam         " + contact_first_name);
                Console.WriteLine("    [2] Achternaam       " + contact_last_name);
                Console.WriteLine("    [3] Email            " + contact_email);
                Console.WriteLine("    [4] Onderwerp        " + contact_subject);
                Console.WriteLine("    [5] Bericht          " + contact_message);
                Console.WriteLine();
                Console.WriteLine("    [6] Versturen");
                Console.WriteLine();
                Console.WriteLine("    ───────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine();

                UserInterface.SetMainColor();
                Console.Write("    Maak een keuze: ");
                UserInterface.SetDefaultColor();
                
                ConsoleKey Choice = Console.ReadKey().Key;

                switch (Choice)
                {
                    case ConsoleKey.D0:
                        Creating = false;
                        Console.Clear();
                        break;
                    case ConsoleKey.D1:
                        while (true)
                        {
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.WriteLine("    Wat is uw voornaam?");
                            UserInterface.SetDefaultColor();
                            Console.Write("    ");
                            contact_first_name = Console.ReadLine();
                            Console.WriteLine();
                            if (contact_first_name.All(Char.IsLetter))
                            {
                                ContactInfo.Add(contact_first_name);
                                break;
                            }
                            else
                            {
                                UserInterface.SetErrorColor();
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (U mag alleen letters gebruiken)");
                                Console.WriteLine();
                            }
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        while (true)
                        {
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.WriteLine("    Wat is uw achternaam? (+ tussenvoegsel!)");
                            UserInterface.SetDefaultColor();
                            Console.Write("    ");
                            contact_last_name = Console.ReadLine();
                            Console.WriteLine();
                            if (contact_last_name.All(Char.IsNumber) == false)
                            {
                                ContactInfo.Add(contact_last_name);
                                break;
                            }
                            else
                            {
                                UserInterface.SetErrorColor();
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (U mag alleen letters gebruiken)");
                                Console.WriteLine();
                            }
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:
                        while (true)
                        {
                            UserInterface.SetMainColor();
                            Console.WriteLine();
                            Console.WriteLine("    Wat is uw emailadres?");
                            UserInterface.SetDefaultColor();
                            Console.Write("    ");
                            contact_email = Console.ReadLine();
                            Console.WriteLine();
                            if (contact_email.Contains("@") && contact_email.Contains("."))
                            {
                                ContactInfo.Add(contact_email);
                                break;
                            }
                            else
                            {
                                UserInterface.SetErrorColor();
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                Console.WriteLine();
                            }
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine("    Wat is het onderwerp van uw bericht?");
                        UserInterface.SetDefaultColor();
                        Console.Write("    ");
                        contact_subject = Console.ReadLine();
                        Console.WriteLine();
                        ContactInfo.Add(contact_subject);
                        Console.Clear();
                        break;
                    case ConsoleKey.D5:
                        UserInterface.SetMainColor();
                        Console.WriteLine();
                        Console.WriteLine("    Wat is uw vraag/opmerking?");
                        UserInterface.SetDefaultColor();
                        Console.Write("    ");
                        contact_message = Console.ReadLine();
                        Console.WriteLine();
                        ContactInfo.Add(contact_message);
                        Console.Clear();
                        break;
                    case ConsoleKey.D6:
                        bool InputIsNull = false;
                        foreach(var x in ContactInfo)
                        {
                            if(x == null)
                            {
                                InputIsNull = true;
                                break;
                            }
                        }
                        if(InputIsNull || ContactInfo.Count == 0)
                        {
                            UserInterface.SetErrorColor();
                            Console.WriteLine();
                            Console.WriteLine("    U heeft niet alle velden ingevuld.");
                            Console.WriteLine("    Klik op een willekeurige toets om verder te gaan.");
                            Console.ReadKey();
                            Console.Clear();
                        } else
                        {
                            UserInterface.SetConfirmColor();
                            Console.WriteLine();
                            Console.WriteLine("    Bedankt voor uw bericht! We doen ons best om u binnen 24 uur een antwoord te sturen.");
                            Console.WriteLine("    Klik op 'ENTER' om het bericht te versturen en terug te gaan naar het hoofdmenu.");
                            Console.ReadLine();
                            Creating = false;
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            return ContactInfo;
        }

        // FUNCTIE KRIJGT EEN LIJST MET CONTACTGEGEVENS MEE EN
        // STUURT VERVOLGENS EEN EMAIL NAAR DE INGEVOERDE EMAIL
        // EN NAAR ROTTERDAMAIRLINES
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
