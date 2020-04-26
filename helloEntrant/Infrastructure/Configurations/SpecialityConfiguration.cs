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
            builder.ToTable("Specialities");
            builder.HasKey(s => s.SpecialityId);
            builder.Property(s => s.Name)
                .IsRequired();                
            //builder.Property(s => s.Description)
            //    .IsRequired();
            builder.Property(s => s.PaidPlaceNumber)
                  .IsRequired();
            builder.Property(s => s.BudgetPlaceNumber)
                  .IsRequired();
            builder.Property(s => s.testNeeded1)
                  .IsRequired();
            builder.Property(s => s.testNeeded2)
                  .IsRequired();
            builder.Property(s => s.testNeeded3)
                  .IsRequired();
            builder.HasOne(s => s.Faculty)
                .WithMany(s => s.Specialities)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
