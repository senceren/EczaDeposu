using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShippingAddress, ba =>
            {
                ba.WithOwner();

                ba.Property(a => a.Street)
                .HasMaxLength(180);

                ba.Property(a => a.City)
                .HasMaxLength(180);

                ba.Property(a => a.District)
                .HasMaxLength(180);

                ba.Property(a => a.Country)
                .HasMaxLength(180);

                ba.Property(a => a.ZipCode)
                .HasMaxLength(180);


            });
        }
    }
}
