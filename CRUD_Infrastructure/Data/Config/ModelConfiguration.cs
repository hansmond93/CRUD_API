using CRUD_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Infrastructure.Data.Config
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.Property(p => p.IsCompleted).IsRequired();
            builder.ToTable("Models");
        }
    }
}
