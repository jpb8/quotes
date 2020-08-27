using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    class ResourceTypeConfiguration : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.Property(p => p.Rate).HasColumnType("decimal(18,2)");
        }
    }
}
