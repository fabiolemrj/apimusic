using AutoMapper;
using devmusic.api.Models;
using devmusic.api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.Data.ProfileMaps
{
    public class ProfileMapEntity: Profile
    {
        public ProfileMapEntity()
        {
            CreateMap<Music, MusicViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<MusicAuthor, AuthorViewModel>();
        }
    }
}
