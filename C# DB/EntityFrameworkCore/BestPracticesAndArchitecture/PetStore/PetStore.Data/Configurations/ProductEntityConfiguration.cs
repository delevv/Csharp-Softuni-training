using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Name
            builder.Property(b => b.Name)
                .HasMaxLength(GlobalConstants.ProductNameMaxLength)
                .IsUnicode(false);
        }
    }
}
