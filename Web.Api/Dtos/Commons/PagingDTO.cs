using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers.Pagging;

namespace WebApi.Dtos.Commons
{
    public class PagingDTO<TEntity>
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<TEntity> Items { get; set; }
    }
}
