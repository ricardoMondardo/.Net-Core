using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.EmailSender.Interfaces;

namespace Web.EmailSender
{
    public class EmailConfiguration : IEmailConfiguration
    {
        //Rest
        public string ApiKey { get; set; }
        public string ApiBaseUri { get; set; }
        public string RequestUri { get; set; }
        public string From { get; set; }


        //SOAP
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }

        public string PopServer { get; set; }
        public int PopPort { get; set; }
        public string PopUsername { get; set; }
        public string PopPassword { get; set; }
    }
}
