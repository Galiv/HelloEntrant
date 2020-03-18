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
            builder.ToTable("Applications");
            builder.HasKey(a => a.ApplicationId);
            builder.Property(a => a.UserId)
                .IsRequired();
            builder.Property(a => a.SpecialityId)
                .IsRequired();
        }
    }
}
