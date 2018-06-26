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
        private UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Product obj)
        {
            _unitOfWork.Products.Add(obj);
            _unitOfWork.Save();
        }

        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }
    }
}
