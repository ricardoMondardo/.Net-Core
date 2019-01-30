﻿using System;
using System.Threading.Tasks;
using Web.Repository.Context;
using Web.Repository.Implementations;
using Web.Repository.Interfaces;
using Web.Repository.Models;

namespace Web.Api.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataBaseContext _context;

        private bool _disposed = false;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        private IGerericRepository<Product> _products;

        public IGerericRepository<Product> Products
        {
            get
            {
                if (this._products == null)
                    this._products = new GenericRepository<Product>(_context);
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