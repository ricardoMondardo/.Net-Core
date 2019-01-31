using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models;
using Web.Repository.Models.Product;
using Web.Repository.Models.User;

namespace Web.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGerericRepository<Product> Products { get; }
        IGerericRepository<User> Users { get; }
        IGerericRepository<Todo> Todos { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
