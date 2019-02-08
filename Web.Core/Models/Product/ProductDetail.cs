namespace Web.Core.Models.Product
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
