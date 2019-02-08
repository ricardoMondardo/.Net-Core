using System.Threading.Tasks;
using Web.Core.Models;
using Web.Core.Models.Product;
using Web.Core.Models.User;

namespace Web.Core.Interfaces
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
