using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.Models;
using WebApi.Repository;
using Xunit;

namespace WebApi.xUnitTest
{
    public class UnitTest1 : IDisposable
    {

        private UnitOfWork _unitOfWork;

        [Fact]
        public void ResultACountList()
        {

            ImageConstructorController();

            Seed();

            var result = _unitOfWork.Image.GetAll();

            Assert.Equal(4, result.Count());

        }

        private void ImageConstructorController()
        {

            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _unitOfWork = new UnitOfWork(new DataBaseContext(options));
            _unitOfWork.EnsureCreated();

        }

        private void Seed()
        {
            var images = new[]
            {
                new Image { Id = 1, Name = "Image 1" },
                new Image { Id = 2, Name = "Image 2" },
                new Image { Id = 3, Name = "Image 3" },
                new Image { Id = 4, Name = "Image 4" }
            };

            _unitOfWork.Image.AddRange(images);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.EnsureDelete();
            _unitOfWork.Dispose();
        }
    }
}
