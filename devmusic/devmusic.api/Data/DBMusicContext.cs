
using Microsoft.EntityFrameworkCore;
using devmusic.api.Models;
using devmusic.api.Data.Maps;
namespace devmusic.api.Data
{
    public class DBMusicContext:DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MusicAuthor> MusicAuthors { get; set; }

        public DBMusicContext(DbContextOptions<DBMusicContext> opt)
        :base(opt)
        {
            
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MusicMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new MusicAuthorMap());
            
           //modelBuilder.Entity<MusicAuthor>().HasKey(o => new { o.MusicId, o.AuthorId });

        // modelBuilder.Entity<MusicAuthor>() 
        //.HasOne(ma => ma.Music)
        //.WithMany(m => m.MusicAuthor)
        //.HasForeignKey(ma => ma.MusicId);

        //  modelBuilder.Entity<MusicAuthor>() 
        //.HasOne(ma => ma.Author)
        //.WithMany(m => m.MusicAuthor)
        //.HasForeignKey(ma => ma.AuthorId); 
        }

     
    }
}