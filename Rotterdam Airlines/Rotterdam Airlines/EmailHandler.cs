using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class EmailHandler
    {
        private string 


        public EmailHandler()
        {

        }


        public static bool SendBookingConfirmation(Booking BookingData, SmtpClient EmailClient)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "subject",
                Body = String.Format("<h4><b>Naam:</b> {0} {1}</h4>\n<h4><b>Email:</b> {2}</h4>\n<h4><b>Subject:</b> {3}</h4>\n<h4> <b>Message:</b> </h4>\n<p>{4}</p>"),
                IsBodyHtml = true,
            };


            // Add RotterdamAirlines and customer to recipients
            mailMessage.To.Add("RotterdamAirlines2022@outlook.com");
            mailMessage.To.Add(BookingData.CustomerEmail);
            // Send email to RotterdamAirlines and Customer
            EmailClient.Send(mailMessage);

            // Return TRUE if email was succesfully sent
            // Return FALSE if email was not succesfully sent
            return true;
        }
    }
}
