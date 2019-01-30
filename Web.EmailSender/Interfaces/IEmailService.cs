using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.EmailSender.Models;

namespace Web.EmailSender.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}
