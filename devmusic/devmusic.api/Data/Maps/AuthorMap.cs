using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using devmusic.api.Models;

namespace devmusic.api.Data.Maps
{
   public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {

            builder.ToTable("Author");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Code).IsRequired().HasMaxLength(6).HasColumnType("varchar(6)");
            builder.Property(x => x.Category).IsRequired().HasColumnType("int");
        }
    }
}