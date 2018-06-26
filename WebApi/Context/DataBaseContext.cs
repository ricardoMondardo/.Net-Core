using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repository
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
