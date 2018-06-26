using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.Models;
using WebApi.Repository;
using Xunit;


namespace WebApi.IntegrationTest
{
    public class RepositoryTest : IDisposable
    {
        private UnitOfWork _unitOfWork;

        private void ImageConstructorController()
        {

            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _unitOfWork = new UnitOfWork(new DataBaseContext(options));
            _unitOfWork.EnsureCreated();

        }

        [Fact]
        public void ResultACountList()
        {

            ImageConstructorController();

            Seed();

            var result = _unitOfWork.Products.GetAll();

            Assert.Equal(4, result.Count());

        }

        private void Seed()
        {
            var products = new[]
            {
                new Product { Id = 1, Description = "P 1" },
                new Product { Id = 2, Description = "P 2" },
                new Product { Id = 3, Description = "P 3" },
                new Product { Id = 4, Description = "P 4" }
            };

            _unitOfWork.Products.AddRange(products);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.EnsureDelete();
            _unitOfWork.Dispose();
        }
    }
}
