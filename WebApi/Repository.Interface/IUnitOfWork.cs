using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IUnitOfWork
    {
        IGerericRepository<Product> Products { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
