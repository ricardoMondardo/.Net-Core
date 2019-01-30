using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models.Product;

namespace Web.Api.Dtos
{
    public class ProductInvoicesDTO
    {
        public ProductDetail ProductDetail { get; set; }
        public ProductGrade ProductGrade { get; set; }
        public IList<ProductItemDTO> ProdutItems { get; set; }
    }
}
