using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
