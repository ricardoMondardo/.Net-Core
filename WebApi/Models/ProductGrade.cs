using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductGrade
    {
        public int Id { get; set; }
        public string Description { get; set; }

        private ICollection<Product> Products { get; set; }
    }
}
