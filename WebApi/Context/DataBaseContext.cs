using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Description = "abc", Active = true},
                new Product() { Id = 2, Description = "bca", Active = false},
                new Product() { Id = 3, Description = "bcba", Active = false},
                new Product() { Id = 4, Description = "dcba", Active = false },
                new Product() { Id = 5, Description = "rcba", Active = false },
                new Product() { Id = 6, Description = "xcba", Active = false },
                new Product() { Id = 7, Description = "hcba", Active = false },
                new Product() { Id = 8, Description = "ecba", Active = false },
                new Product() { Id = 9, Description = "wcba", Active = false },
                new Product() { Id = 10, Description = "qcba", Active = false }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }

        private static List<Product> SeedProduct()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Description = "abc",
                    ProductDetail = new ProductDetail() {
                        ComeFrom = "Brazil",
                        MadeFor = "Brazil"
                    },
                    ProductGrade = new ProductGrade()
                    {
                        Description = "Grade F"
                    },
                    ProdutItens = new List<ProdutItem>()
                    {
                        new ProdutItem() { Description = "P I 1"},
                        new ProdutItem() { Description = "P I 2"}
                    }
                },
                new Product()
                {
                    Description = "bca"
                },
                new Product()
                {
                    Description = "cba"
                }
            };
        }

        
    }
}
