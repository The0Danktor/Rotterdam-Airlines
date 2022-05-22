using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        public static bool SendBookingConfirmation(Booking booking)
        {
            string HTML = @"<!DOCTYPE html>
                        <html lang=""en"">
                        <head>
                            <meta charset = ""UTF-8"">
                            <meta http - equiv = ""X-UA-Compatible"" content = ""IE=edge"">
                            <meta name = ""viewport"" content = ""width=device-width, initial-scale=1.0"">
                            <title> Booking Confirmation </title>
                            <style>
                                @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600;700;800;900&display=swap');

                                 body {
                                    font-family: 'Poppins', sans-serif;
                                    padding: 2rem;
                                }
                                .email-wrapper {
                                    border-radius: 2rem;
                                    max-width: 600px;
                                    min-height: 800px;
                                    color: black;
                                }
                                .header-wrapper {
                                    border-radius: 2rem;
                                    color: white;
                                    background-color: #506CF6;
                                    padding: 2rem;
                                 }
                                 .header-wrapper p {
                                    font-size: 1.25rem;
                                    font-weight: 500;    
                                 }

                            </style>
                        </head>
                        <body>
                            <div class=""email-wrapper"">
                                <div class=""header-wrapper"">
                                    <h1>Bedankt voor je boeking!</h1>
                                    <p>Je boeking is succesvol afgerond. Je boekingscode vindt je in het onderwerp van deze email.</p>
                                </div>
                            </div>
                        </body>
                ";

            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("RotterdamAirlines2022@outlook.com", "yks`PAha8\"5QyTN$"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("RotterdamAirlines2022@outlook.com"),
                Subject = "Boeking: #" + booking.BookingID,
                Body = HTML,
                IsBodyHtml = true
            };


            // Add RotterdamAirlines and customer to recipients
            mailMessage.To.Add("RotterdamAirlines2022@outlook.com");
            mailMessage.To.Add(booking.CustomerEmail);
            // mailMessage.To.Add(BookingData.CustomerEmail);
            // Send email to RotterdamAirlines and Customer
            smtpClient.Send(mailMessage);

            // Return TRUE if email was succesfully sent
            // Return FALSE if email was not succesfully sent
            return true;
        }
    }
}
