using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Count()
        {
            return _unitOfWork.Products.Count();
        }

        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public Product GetWithIncludes(int id)
        {
            return _unitOfWork.Products.Find( x => x.Id == id, x => x.ProductDetail, x => x.ProductGrade, x => x.ProdutItens)
                .FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public List<Product> GetLatest(int qt)
        {
            return _unitOfWork.Products.GetAll();
        }

        public List<Product> GetAllIsUseTrue()
        {
            return _unitOfWork.Products.Find(p => p.IsUse == true).ToList();
        }        
        
        public void Add(Product obj)
        {
            _unitOfWork.Products.Add(obj);
            _unitOfWork.Save();
        }
        
        public async Task<Product> GetAsync(int id)
        {
            return await _unitOfWork.Products.GetAsync(id);
        }        

    }
}
