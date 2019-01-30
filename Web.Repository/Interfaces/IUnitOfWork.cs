using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models;

namespace Web.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGerericRepository<Product> Products { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
