using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Repository.Models.Product
{
    public class ProductDetail : IEntityBase
    {
        public string Id { get; set; }
        public string ComeFrom { get; set; }
        public string MadeFor { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
