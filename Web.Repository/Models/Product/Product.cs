using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Repository.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public bool Active { get; set; }        
        public int? ProductGradeId { get; set; }
        public ProductGrade ProductGrade { get; set; }
        public ProductDetail ProductDetail { get; set; } //one-to-one
        public ICollection<ProdutItem> ProdutItens { get; set; }

    }
}
