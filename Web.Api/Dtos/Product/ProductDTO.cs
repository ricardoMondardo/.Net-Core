using System.ComponentModel.DataAnnotations;

namespace Web.Api.Dtos
{
    public class ProductDTO
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
