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
        int Count();

        Product Get(int id);
        List<Product> GetAll();
        List<Product> GetLatest(int qt);
        List<Product> GetAllIsUseTrue();
    }
}
