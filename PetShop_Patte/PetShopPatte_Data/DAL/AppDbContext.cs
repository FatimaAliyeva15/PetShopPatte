using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShopPatte_Core.Entities.Cart;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Core.Entities.UserModel;
using PetShopPatte_Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetDetail> PetDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimalTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof (PetConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SizeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubcategoryConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketItemConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
