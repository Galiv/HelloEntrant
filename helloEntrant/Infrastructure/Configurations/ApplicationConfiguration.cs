using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Core.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Application> builder)
        {
            builder.ToTable("Application");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserId)
                .IsRequired();
            builder.Property(u => u.SpecialityId)
                .IsRequired();
        }
    }
}
