using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Models.Product;

namespace Web.Server.Services
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
        IQueryable<Product> GetAllQueryable();

    }
}
