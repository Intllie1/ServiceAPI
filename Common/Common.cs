using System.Net;
using System.Net.Mail;

namespace RegistrationAPI.Common
{
    public class Common
    {
        //Sendemail 
        public static string SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var fromAddress = new MailAddress("Admin@Intelliswift.com");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "";
                string body = content;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}