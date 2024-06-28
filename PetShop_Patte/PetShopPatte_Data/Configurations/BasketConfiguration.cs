using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopPatte_Core.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.AppUser)
                .WithMany()
                .HasForeignKey(b => b.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BasketItems)
                .WithOne(bi => bi.Basket)
                .HasForeignKey(bi => bi.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.AppUserId).IsRequired();
        }
    }
}
