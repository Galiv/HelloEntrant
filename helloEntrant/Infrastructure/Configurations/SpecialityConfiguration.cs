using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("Speciality");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired();                
            builder.Property(u => u.Description)
                .IsRequired();
            builder.Property(u => u.PaidPlace)
                  .IsRequired();
            builder.Property(u => u.BudgetPlace)
                  .IsRequired();
            builder.Property(u => u.testNeeded1)
                  .IsRequired();
            builder.Property(u => u.testNeeded2)
                  .IsRequired();
            builder.Property(u => u.testNeeded3)
                  .IsRequired();

        }
    }
}
