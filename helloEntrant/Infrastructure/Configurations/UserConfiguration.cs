using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.Email)
                .IsRequired();
            builder.HasOne(u => u.Test)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
