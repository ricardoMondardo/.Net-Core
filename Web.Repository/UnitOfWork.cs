using System;
using System.Threading.Tasks;
using Web.Repository.Context;
using Web.Core.Interfaces;
using Web.Core.Models;
using Web.Core.Models.Product;
using Web.Core.Models.User;

namespace Web.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataBaseContext _context;
        private bool _disposed = false;
        private IGerericRepository<Product> _products;
        private IGerericRepository<User> _users;
        private IGerericRepository<Todo> _todo;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public IGerericRepository<Product> Products
        {
            get { return _products ?? (_products = new GenericRepository<Product>(_context)); }
        }
        public IGerericRepository<User> Users
        {
            get { return _users ?? (_users = new GenericRepository<User>(_context)); }
        }

        public IGerericRepository<Todo> Todos
        {
            get { return _todo ?? (_todo = new GenericRepository<Todo>(_context));}
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
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
