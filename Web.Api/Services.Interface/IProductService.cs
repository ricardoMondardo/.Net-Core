using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models.Product;
using Web.Api.Helpers.Pagging;

namespace Web.Api.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(string id);

        void Add(Product product);
        void Add(List<Product> products);
        int Count();

        Product Get(string id);
        Product GetInvoices(string id);

        List<Product> GetAll();
        PagedList<Product> GetAllPagging(PagingParams pagingParams);

    }
}
