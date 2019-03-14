using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Server.Helpers
{
    public class BadRequestModel
    {
        public List<ErrorModel> Erros { get; set; }
        public string Title { get; set; }
    }

   public class ErrorModel
   {
        public string Title { get; set; }
        public string Detail { get; set; }
    }

}
