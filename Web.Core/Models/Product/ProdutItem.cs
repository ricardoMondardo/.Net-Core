namespace Web.Core.Models.Product
{
    public class ProdutItem : IEntityBase
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
