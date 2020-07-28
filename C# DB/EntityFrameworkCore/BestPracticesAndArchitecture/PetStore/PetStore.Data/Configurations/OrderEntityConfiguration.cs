using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Town
            builder.Property(b => b.Town)
                 .HasMaxLength(GlobalConstants.TownNameMaxLength)
                 .IsUnicode(true);

            //Address
            builder.Property(b => b.Address)
                 .HasMaxLength(GlobalConstants.AddressTextMaxLength)
                 .IsUnicode(true);

            //TotalPrice
            builder.Ignore(b => b.TotalPrice);
        }
    }
}
