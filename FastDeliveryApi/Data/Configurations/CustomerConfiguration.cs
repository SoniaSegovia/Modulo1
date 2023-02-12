using FastDeliveryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDeliveryApi.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
       builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
              .HasMaxLength(100)
              .HasColumnType("nvarchar")
              .IsRequired();

        builder.Property(b => b.PhoneNumber)
                     .HasMaxLength(9)
                     .HasColumnType("nvarchar")
                     .HasColumnName("phoneNumberCustomer");

        builder.Property(b => b.Email)
                .HasMaxLength(9)
                .HasColumnType("nvarchar")
                .IsRequired();

        builder.Property(b => b.Address)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(120);

               
    }
}
