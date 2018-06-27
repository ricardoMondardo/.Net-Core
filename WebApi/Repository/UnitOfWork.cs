using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        private IRepository<Product> _products;

        public IRepository<Product> Products
        {
            get
            {
                if (this._products == null)
                    this._products = new Repository<Product>(_context);
                return this._products;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            int rowsAffected = 0;

            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
