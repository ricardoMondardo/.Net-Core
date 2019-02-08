using GraphQL.Types;
using Web.Core.Models.Product;

namespace Web.GraphQL.Model
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the product.");
            Field(x => x.Description).Description("The description of the product.");
        }
    }
}
