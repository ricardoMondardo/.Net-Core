using Microsoft.EntityFrameworkCore;
using Web.Repository.Implementations;
using Web.Repository.Context;


namespace Web.Tests
{
    public class DataContext
    {
        private readonly UnitOfWork _unitOfWork;
        public DataContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                            .UseInMemoryDatabase(databaseName: "teste")
                            .Options;

            _unitOfWork = new UnitOfWork(new DataBaseContext(options));
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }
    }
}
