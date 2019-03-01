using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Interfaces;
using Web.Core.Models.Product;

namespace Web.Server.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            if (Count() == 0)
            {
                Add(new List<Product>()
                {
                    new Product() { Description = "Test 1"},
                    new Product() { Description = "Test 2"},
                    new Product() { Description = "Test 3"},
                    new Product() { Description = "Test 4"},
                    new Product() { Description = "Test 5"},
                    new Product() { Description = "Test 6"},
                    new Product() { Description = "Test 7"},
                    new Product() { Description = "Test 8"},
                    new Product() { Description = "Test 9"},
                    new Product() { Description = "Test 10"},
                    new Product() { Description = "Test 11"},
                    new Product() { Description = "Test 12"},
                    new Product() { Description = "Test 13"},
                    new Product() { Description = "Test 14"},
                    new Product() { Description = "Test 15"}
                });
            }

        }

        public int Count()
        {
            return _unitOfWork.Products.Count();
        }

        public Product Get(string id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public Product GetInvoices(string id)
        {
            return _unitOfWork.Products.Find( x => x.Id == id, x => x.ProductDetail, x => x.ProductGrade, x => x.ProdutItens)
                .FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }    
        
        public void Add(Product obj)
        {
            _unitOfWork.Products.Add(obj);
            _unitOfWork.Save();
        }

        public void Add(List<Product> products)
        {
            _unitOfWork.Products.AddRange(products);
            _unitOfWork.Save();
        }
        
        public async Task<Product> GetAsync(string id)
        {
            return await _unitOfWork.Products.GetAsync(id);
        }

        public IQueryable<Product> GetAllQueryable()
        {
            return _unitOfWork.Products
                    .Find()
                    .OrderBy(x => x.Description)
                    .AsQueryable();
        }

        public IQueryable<Product> GetAllQueryable(string query)
        {
            return _unitOfWork.Products.Find(x => x.Description.Contains(query)).AsQueryable();
        }
    }
}
