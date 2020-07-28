using Microsoft.EntityFrameworkCore;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            //Username
            builder.Property(b => b.Username)
                .HasMaxLength(GlobalConstants.UsernameMaxLength)
                .IsUnicode(false);

            //Email
            builder.Property(b => b.Email)
                .HasMaxLength(GlobalConstants.UsernameMaxLength)
                .IsUnicode(false);

            //FirstName
            builder.Property(b => b.FirstName)
                .HasMaxLength(GlobalConstants.ClientNameMaxLength)
                .IsUnicode(true);

            //LastName
            builder.Property(b => b.LastName)
                .HasMaxLength(GlobalConstants.ClientNameMaxLength)
                .IsUnicode(true);
        }
    }
}
