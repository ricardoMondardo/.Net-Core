using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        private Repository<Product> _products;

        public Repository<Product> Products
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

        public void Dispose()
        {
            _context.Dispose();
        }

        #region EnsureCreated and Delete for tests goals
        public void EnsureCreated()
        {
            _context.Database.EnsureCreated();
        }

        public void EnsureDelete()
        {
            _context.Database.EnsureDeleted();
        }
        #endregion
    }
}
