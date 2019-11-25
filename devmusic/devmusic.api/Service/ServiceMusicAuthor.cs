using AutoMapper;
using devmusic.api.Data;
using devmusic.api.Models;
using devmusic.api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.Service
{
    public class ServiceMusicAuthor
    {
        private DBMusicContext _context;
        private readonly IMapper _mapper;
        public ServiceMusicAuthor(DBMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorMusicViewModel Post(MusicAuthor musicauthor)
        {
            _context.MusicAuthors.Add(musicauthor);
            _context.SaveChangesAsync();
            var musicauthorvm = _mapper.Map<AuthorMusicViewModel>(musicauthor);
            return musicauthorvm;
        }

        public AuthorMusicViewModel Delete(Guid musicid, Guid authorid)
        {
            var objeto = _context.MusicAuthors.Find(musicid,authorid);

            if (objeto == null)
            {
                return null;
            }
            _context.MusicAuthors.Remove(objeto);

            _context.SaveChangesAsync();

            var musicauthorvm = _mapper.Map<AuthorMusicViewModel>(objeto);
            return musicauthorvm;
        }

    }
}
