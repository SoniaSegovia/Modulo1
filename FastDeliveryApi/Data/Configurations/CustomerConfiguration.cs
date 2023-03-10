using FastDeliveryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDeliveryApi.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    private const string TypeName = "text";

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
       builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
              .HasMaxLength(100)
              .HasColumnType("text")
              .IsRequired();

        builder.Property(b => b.PhoneNumber)
                     .HasMaxLength(9)
                     .HasColumnType("text")
                     .HasColumnName("phoneNumberCustomer");

        builder.Property(b => b.Email)
                .HasMaxLength(120)
                .HasColumnType("text")
                .IsRequired();

        builder.Property(b => b.Address)
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(120);

        builder.Property(b => b.CreditLimit)
                .HasColumnType("decimal(19, 2)")
                .IsRequired();

        builder.HasData(
                new Customer
                {
                  Id = 1,
                  Name ="Suleyma Lopez",
                  Email = "suleyma@univo.edu.sv",
                  Address = "San Miguel",
                  PhoneNumber = "0000-0000",
                  Status = true 
                },

                 new Customer
                {
                  Id = 2,
                  Name ="Kevin Vasquez",
                  Email = "kvasquez@univo.edu.sv",
                  Address = "San Salvador",
                  PhoneNumber = "2200-5500",
                  Status = true 
                }
        );
               
    }
}
