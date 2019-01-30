using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Helpers.Pagging
{
    public class LinkInfo
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
