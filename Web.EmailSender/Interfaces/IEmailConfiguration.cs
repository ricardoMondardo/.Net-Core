using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.EmailSender.Interfaces
{
    public interface IEmailConfiguration
    {
        //Rest
        string ApiKey { get; set; }
        string ApiBaseUri { get; set; }
        string RequestUri { get; set; }
        string From { get; set; }

        //SOAP
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }

        string PopServer { get; }
        int PopPort { get; }
        string PopUsername { get; }
        string PopPassword { get; }
    }
}
