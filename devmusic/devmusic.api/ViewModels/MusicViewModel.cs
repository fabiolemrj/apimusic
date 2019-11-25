using devmusic.api.ETypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.ViewModels
{
    public class MusicViewModel
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Code { get; set; }
        public ETypeGenreMusic Genre { get; set; }

        public string GenreDescription
        {
            get { return Genre.ToString(); }
            
        }

    }
}
