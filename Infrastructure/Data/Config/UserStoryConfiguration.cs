using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    class UserStoryConfiguration : IEntityTypeConfiguration<UserStory>
    {
        public void Configure(EntityTypeBuilder<UserStory> builder)
        {
            builder.Property(p => p.Discovery).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Design).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Implementation).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Test).HasColumnType("decimal(18,2)");
        }
    }
}
