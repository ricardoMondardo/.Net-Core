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

        [Fact]
        public void Test_GetLastestFive()
        {

            var mockRepo = new Mock<IRepository<Product>>();
            var mockUnit = new Mock<IUnitOfWork>();

            mockRepo.Setup(foo => foo.GetAll()).Returns(Seed());
            mockUnit.Setup(foo => foo.Products).Returns(mockRepo.Object);

            var productService = new ProductService(mockUnit.Object);

            var ctor = new ProductController(productService);
            var resul = ctor.GetLatest(5);

            Assert.Equal(5, resul.Count);

            //Check result and responses....

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
