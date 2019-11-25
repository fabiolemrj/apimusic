using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using devmusic.api.ETypes;
using Newtonsoft.Json;

namespace devmusic.api.Models
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; set; }
        public ETypeAuthor Category { get; set; }

        [NotMapped]
        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public ICollection<MusicAuthor> MusicAuthor { get; set; }

        public Author(){
             MusicAuthor = new Collection<MusicAuthor>();
        }
    }
}