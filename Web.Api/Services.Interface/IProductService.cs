using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers.Pagging;
using WebApi.Models;

namespace WebApi.Services
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
