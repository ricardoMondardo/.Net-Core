using System.Collections.Generic;

namespace Web.Core.Models.Product
{
    public class ProductGrade : IEntityBase
    {
        public string Id { get; set; }
        public string Description { get; set; }
        private ICollection<Product> Products { get; set; }
    }
}
