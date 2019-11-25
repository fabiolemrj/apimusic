using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using devmusic.api.Models;

namespace devmusic.api.Data.Maps
{
    public class MusicMap: IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Music");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Code).IsRequired().HasMaxLength(6).HasColumnType("varchar(6)");
            builder.Property(x => x.Genre).IsRequired().HasColumnType("int");
        }
    }
}