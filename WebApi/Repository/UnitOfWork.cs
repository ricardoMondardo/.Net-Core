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

        private Repository<Image> _image;

        public Repository<Image> Image
        {
            get
            {
                if (this._image == null)
                    this._image = new Repository<Image>(_context);
                return this._image;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
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
