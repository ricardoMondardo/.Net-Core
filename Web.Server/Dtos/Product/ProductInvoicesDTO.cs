using System.Collections.Generic;
using Web.Repository.Models.Product;

namespace Web.Server.Dtos
{
    public class ProductInvoicesDTO
    {
        public ProductDetail ProductDetail { get; set; }
        public ProductGrade ProductGrade { get; set; }
        public IList<ProductItemDTO> ProdutItems { get; set; }
    }
}
