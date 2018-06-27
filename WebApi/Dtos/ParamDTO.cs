using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ParamDTO
    {
        public int Id { get; set; }
        public bool WithInclude { get; set; }
        public int Page { get; set; }
        public bool HasNext { get; set; }
    }
}
