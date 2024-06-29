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
    public class PetDetailConfiguration : IEntityTypeConfiguration<PetDetail>
    {
        public void Configure(EntityTypeBuilder<PetDetail> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Breed).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Age).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Price).IsRequired().HasMaxLength(18);
        }
    }
}
