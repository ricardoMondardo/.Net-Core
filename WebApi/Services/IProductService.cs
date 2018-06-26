using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);

        void Add(Product product);
        Product Get(int id);
        List<Product> GetAll();
        int Count();
    }
}
