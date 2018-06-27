using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Dtos
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }        
        public string Description { get; set; }
        public string MadeFor { get; set; }
        public string Gride { get; set; }
        public IList<ProductItemDTO> ProdutItems { get; set; }
    }
}
