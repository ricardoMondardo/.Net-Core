using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Repository.Models.Product
{
    public class ProdutItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
