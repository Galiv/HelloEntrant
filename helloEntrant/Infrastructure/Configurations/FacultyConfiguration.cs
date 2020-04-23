using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculties");
            builder.HasKey(f => f.FacultyId);
            builder.Property(f => f.Name)
                .IsRequired();
            builder.Property(f => f.Address)
                .IsRequired();                
            builder.Property(f => f.UniversityId)
                .IsRequired();
            builder.HasOne(f => f.University)
                .WithMany(f => f.Faculties)
                .HasForeignKey(f => f.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);
           // builder.HasOne(u => u.Document);
        }
    }
}
