using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.IdentityServer.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            /* Call the EmailManager and send the Email
             * Call The Api and write the status in a dataBase
             */

            throw new NotImplementedException();
        }
    }
}
