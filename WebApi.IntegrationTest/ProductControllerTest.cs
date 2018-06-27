using Newtonsoft.Json;
using Moq;
using System.Threading.Tasks;
using Xunit;
using WebApi.Services;
using WebApi.Models;
using System.Collections.Generic;
using WebApi.Repository;
using WebApi.Controllers;

namespace WebApi.IntegrationTest
{
    public class ProductControllerTest
    {

        private Mock<IGerericRepository<Product>> _mockRepo = new Mock<IGerericRepository<Product>>();
        private Mock<IUnitOfWork>  _mockUnit = new Mock<IUnitOfWork>();

        [Fact]
        public void Test_GetLastestFive()
        {
            _mockRepo.Setup(foo => foo.GetAll()).Returns(Seed());
            _mockUnit.Setup(foo => foo.Products).Returns(_mockRepo.Object);

            var productService = new ProductService(_mockUnit.Object);

            var ctor = new ProductController(productService);
            var resul = ctor.GetLatest(5);

            Assert.Equal(5, resul.Count);
        }

        [Fact]
        public void Test_Post()
        {
            //Assert.
        }

        private List<Product> Seed()
        {
            return new List<Product>
            {
                new Product() { Id = 1, Description = "P 1" },
                new Product() { Id = 2, Description = "P 2" },
                new Product() { Id = 3, Description = "P 3" },
                new Product() { Id = 4, Description = "P 4" },
                new Product() { Id = 5, Description = "P 5" },
                new Product() { Id = 6, Description = "P 6" },
                new Product() { Id = 7, Description = "P 7" }
            };
        }
    }
}
