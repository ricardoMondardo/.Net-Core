using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Interfaces;
using Web.Repository.Models.Product;
using Web.Api.Helpers.Pagging;

namespace Web.Api.Services
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
                    new Product() { Description = "Abc"},
                    new Product() { Description = "Bac"},
                    new Product() { Description = "Caa"},
                    new Product() { Description = "Da1"},
                    new Product() { Description = "Ea5"},
                    new Product() { Description = "Fac"}
                });
            }

        }

        public int Count()
        {
            return _unitOfWork.Products.Count();
        }

        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public Product GetInvoices(int id)
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
            _unitOfWork.SaveAsync();
        }
        
        public async Task<Product> GetAsync(int id)
        {
            return await _unitOfWork.Products.GetAsync(id);
        }

        public PagedList<Product> GetAll(PagingParams pagingParams)
        {
            var query = _unitOfWork.Products.Find().AsQueryable();
            return new PagedList<Product>(
                query, pagingParams.PageNumber, pagingParams.PageSize);
        }

    }
}
