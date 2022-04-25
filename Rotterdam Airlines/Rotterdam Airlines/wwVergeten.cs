using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class WwVergeten
    {

        public static void ChangePassword(SmtpClient smtpClient)
        {
            Console.Write("    Vul uw email in: ");
            List<Customer> customers = JSON.LoadCustomersJSON();
            string inputemail = Console.ReadLine();
            string currentemail;
            foreach (Customer customer in customers)
            {
                if (customer.email == inputemail)
                {
                    currentemail = customer.email;
                    Random rd = new Random();
                    int RandCode = rd.Next(100000, 999999);
                    WwVergeten.SendCodeMail(currentemail,  smtpClient, RandCode);
                    WwVergeten.CheckChangeCode(RandCode, currentemail);

                }
                else
                {
                    Console.WriteLine("    niet bestande email ingevoerd");
                }
            }
        }


        public static void SendCodeMail(string currentEmail, SmtpClient smtpClient, int RandCode)
        {
            
            var currentemail = new MailMessage

            {

                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "Code",
                Body = String.Format("<h4><b>code:</b> {0} {1}</h4>\n<h4><b>Email:</b> {2}</h4>\n<h4><b>Subject:</b>", RandCode, currentEmail),
                IsBodyHtml = true,
            };
            currentemail.To.Add("RotterdamAirlines2022@outlook.com");
            currentemail.To.Add(currentEmail);
            smtpClient.Send(currentemail);

        }


        public static void CheckChangeCode(int Truecode, string EmailChangable)
        {
            Console.Write("    Vul de code in: ");
            List<Customer> customers = JSON.LoadCustomersJSON();
            string inputcode = Console.ReadLine();
            int InputCode = int.Parse(inputcode);
            int y = 0;
            if (Truecode == InputCode)
            {
                Console.WriteLine("    Kies een wachtwoord: ");
                string InputFirstPassword = Console.ReadLine();
                Console.WriteLine("    Vul het wachtwoord nog een keer in : ");
                string InputSecondPassword = Console.ReadLine();
                foreach (Customer customer in customers)
                {
                    if (customer.email == EmailChangable)
                    {

                        customers[y].password = InputFirstPassword;
                    }
                
                    y++;
                }

            }
            else
            {
                Console.WriteLine("    Code is onjuist, probeer opniew");
            }

        }
   
    }

}
