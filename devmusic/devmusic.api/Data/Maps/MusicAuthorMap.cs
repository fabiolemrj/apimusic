using devmusic.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devmusic.api.Data.Maps
{
    public class MusicAuthorMap : IEntityTypeConfiguration<MusicAuthor>
    {
        public void Configure(EntityTypeBuilder<MusicAuthor> builder)
        {
            builder.ToTable("MusicAuthor");
            builder.HasKey(x => new { x.MusicId, x.AuthorId });


        }
    }
}