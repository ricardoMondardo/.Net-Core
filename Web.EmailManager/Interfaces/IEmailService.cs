using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.EmailManager.Models;

namespace Web.EmailManager.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}
