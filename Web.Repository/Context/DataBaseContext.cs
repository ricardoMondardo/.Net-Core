using Microsoft.EntityFrameworkCore;
using Web.Core.Models;
using Web.Core.Models.Product;
using Web.Core.Models.User;

namespace Web.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }

    }
}
