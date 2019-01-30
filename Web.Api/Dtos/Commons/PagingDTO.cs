using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Helpers.Pagging;

namespace Web.Api.Dtos.Commons
{
    public class PagingDTO<TEntity>
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<TEntity> Items { get; set; }
    }
}
