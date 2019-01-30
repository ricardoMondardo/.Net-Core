using Microsoft.EntityFrameworkCore;
using Web.Repository.Models;

namespace Web.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
             
    }
}
