using Microsoft.EntityFrameworkCore;
using Web.Repository.Models;
using Web.Repository.Models.Product;
using Web.Repository.Models.User;

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
