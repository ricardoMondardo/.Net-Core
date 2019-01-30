using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Helpers.Pagging
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
