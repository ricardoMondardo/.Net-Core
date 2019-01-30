using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models;
using Web.Api.Helpers.Pagging;

namespace Web.Api.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);

        void Add(Product product);
        void Add(List<Product> products);
        int Count();

        Product Get(int id);
        Product GetInvoices(int id);

        List<Product> GetAll();
        PagedList<Product> GetAll(PagingParams pagingParams);

    }
}
