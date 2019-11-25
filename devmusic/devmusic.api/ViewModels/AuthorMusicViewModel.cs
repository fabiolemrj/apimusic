using devmusic.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.ViewModels
{
    public class AuthorMusicViewModel
    {
        public Guid MusicId { get; set; }
        public Guid AuthorId { get; set; }
        
    }
}
