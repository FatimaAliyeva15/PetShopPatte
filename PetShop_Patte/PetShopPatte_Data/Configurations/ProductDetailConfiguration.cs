using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.StockQuantity).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Price).IsRequired().HasMaxLength(18);
        }
    }
}
