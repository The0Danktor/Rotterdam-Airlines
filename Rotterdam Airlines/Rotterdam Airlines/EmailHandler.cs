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

        public EmailHandler()
        {

        }


        //public static bool SendBookingConfirmation(Booking BookingData, SmtpClient EmailClient)
        public static bool SendBookingConfirmation(SmtpClient EmailClient)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "test",
                Body = "TEst",
                IsBodyHtml = true,
            };


            // Add RotterdamAirlines and customer to recipients
            mailMessage.To.Add("RotterdamAirlines2022@outlook.com");
            mailMessage.To.Add("lucas2002prins@gmail.com");
            // mailMessage.To.Add(BookingData.CustomerEmail);
            // Send email to RotterdamAirlines and Customer
            EmailClient.Send(mailMessage);

            // Return TRUE if email was succesfully sent
            // Return FALSE if email was not succesfully sent
            return true;
        }
    }
}
