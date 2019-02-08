using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Core.Interfaces;
using Web.GraphQL.Model;
using System.Linq;

namespace Web.GraphQL.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IUnitOfWork unitOfWork)
        {
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the restaurant." }),
                resolve: context => 
                {
                    var id = context.GetArgument<Guid?>("id");
                    var product = unitOfWork
                        .Products
                        .Find(i => i.Id == id.ToString()) ;

                    return product.FirstOrDefault();
                }
                );

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context =>
                {
                    return unitOfWork.Products.GetAll();
                });                                
        }
    }
}
