using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductApi.Models;

namespace Restaurant.Services.ProductApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId =2,
                Name = "asus r565",
                CategoryName="laptop",
                Description= "new laptop",
                ImageUrl="1d54f5ds4fsd54f",
                Price=23.3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "asus tuf",
                CategoryName = "laptop",
                Description = "new gaming laptop",
                ImageUrl = "1d5452hjjhs4fsd54f",
                Price = 451.3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "apple macbook m1",
                CategoryName = "laptop",
                Description = "work laptop",
                ImageUrl = "1d54f5dpp12"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "apple macbook m1",
                CategoryName = "laptop",
                Description = "work laptop",
                ImageUrl = "1d54f5dpp12"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "lenovo ideapad 5 ",
                CategoryName = "laptop",
                Description = "student laptop",
                ImageUrl = "1d522pp12"
            });
        }

    }
}
