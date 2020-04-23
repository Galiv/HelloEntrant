using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable("Universities");
            builder.HasKey(u => u.UniversityId);
            builder.Property(u => u.Name)
                .IsRequired();
            builder.HasOne(u => u.User)
                .WithOne(u => u.University)
                .HasForeignKey<University>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
