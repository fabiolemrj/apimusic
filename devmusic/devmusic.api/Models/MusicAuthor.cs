using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace devmusic.api.Models
{
    public class MusicAuthor
    {
        public Guid MusicId { get; set; }
        [NotMapped]
        public virtual Music Music { get; set; }

        public Guid AuthorId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }

    }
}