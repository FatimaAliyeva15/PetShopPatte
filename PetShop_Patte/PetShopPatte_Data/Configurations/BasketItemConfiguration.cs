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
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasKey(bi => bi.Id);

            builder.HasOne(bi => bi.Basket)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(bi => bi.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bi => bi.Product)
                .WithMany()
                .HasForeignKey(bi => bi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(bi => bi.Quantity)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
