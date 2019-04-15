using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Web.EmailSender.Interfaces;
using Web.EmailSender.Models;

namespace Web.EmailSender
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public void Send(EmailMessage emailMessage)
        {
            var message = new MailMessage();

            message.From = new MailAddress(_emailConfiguration.From);
            message.To.Add("ricardo9300@gmail.com");


            message.Subject = emailMessage.Subject;
            message.Body = emailMessage.Content;

            using (var emailClient = new SmtpClient(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort))
            {

                NetworkCredential Credentials = new NetworkCredential(_emailConfiguration.From, _emailConfiguration.SmtpPassword);
                emailClient.Credentials = Credentials;

                emailClient.Send(message);

            }
        }
    }
}
