using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ComercialNumber)
                .IsRequired();

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.ContactName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Phone)
                .IsRequired();

            builder.HasOne(b => b.City)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(b => b.Company)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
}
