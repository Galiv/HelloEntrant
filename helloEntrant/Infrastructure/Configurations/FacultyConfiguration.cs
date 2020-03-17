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
            builder.ToTable("Faculty");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired();
            builder.Property(u => u.Address)
                .IsRequired();
            builder.Property(u => u.Description)
                .IsRequired();
            builder.Property(u => u.DocumentId)
                .IsRequired();
            builder.Property(u => u.UniversityId)
                .IsRequired();
            builder.HasOne(u => u.University)
                .WithMany(u => u.Faculties)
                .HasForeignKey(u => u.UniversityId)
                .OnDelete(DeleteBehavior.NoAction);
           // builder.HasOne(u => u.Document);
        }
    }
}
