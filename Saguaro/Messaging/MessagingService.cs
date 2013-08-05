using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Saguaro.Messaging
{
    public class MessagingService
    {

        public async Task<bool> SendEmail(string to, string subject, string bodyHtml, string fromEmail, string fromName)
        {
            bool isSuccess = false;

            string headers = "{\"to\":[\"" + to + "\"],\"filters\" : {\"domainkeys\" : {\"settings\" : {\"enable\" : 0}}}}";
            //string headers = "{\"to\":[\"example1@example.com\",\"example2@example.com\",\"example3@example.com\"],\"filters\" : {\"domainkeys\" : {\"settings\" : {\"enable\" : 0}}}}"; 
            //The bellow commented line works for twitter status messages 
            //string headers = "{\"to\":[\"example@twitterstatus\"],\"filters\" : {\"twitter\" : {\"settings\" : {\"enable\" : \"1\", \"username\" : \"example@gmail.com\",\"password\" : \"password\"}}}}"; 

            MailMessage msg = new MailMessage();

            msg.Subject = subject;
            msg.Body = bodyHtml;
            msg.From = new MailAddress(fromEmail);
            msg.To.Add(to);
            msg.Headers.Add("X-SMTPAPI", headers);
            msg.IsBodyHtml = true;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            NetworkCredential basicauthenticationinfo = new NetworkCredential(EnvironmentSettings.SendGridAccount.UserName, EnvironmentSettings.SendGridAccount.APIKey);
            client.Host = EnvironmentSettings.SendGridAccount.SMTPAddress;
            client.Port = 25;

            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(msg);

            isSuccess = true;

            return isSuccess;


        }
    }
}