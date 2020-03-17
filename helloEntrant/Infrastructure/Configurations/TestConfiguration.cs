using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("Test");
            builder.HasKey(u => u.TestId);
            //builder.HasOne(u => u.User)
            //    .WithOne(u => u.Test)
            //    .HasForeignKey<Test>(u => u.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
