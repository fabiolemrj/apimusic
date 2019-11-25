using AutoMapper;
using devmusic.api.Data;
using devmusic.api.Models;
using devmusic.api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.Service
{
    public class ServiceMusic
    {
        private DBMusicContext _context;
        private readonly IMapper _mapper;
        public ServiceMusic(DBMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MusicViewModel> GetMusic()
        {
            var result = _context.Musics
            .AsNoTracking()
            .ToList();

            var lista = new List<MusicViewModel>();

            foreach (var item in result)
            {
                lista.Add(_mapper.Map<MusicViewModel>(item));
            }
            return lista;
        }

        public MusicViewModel GetMusicById(Guid id)
        {
            var music =  _context.Musics.AsNoTracking()
                                    .FirstOrDefault(x => x.Id == id);

            var musicvm = new MusicViewModel();
            musicvm =_mapper.Map<MusicViewModel>(music);
            return musicvm;
        }

        public List<MusicViewModel> GetMusicByName(string name)
        {
            var result = _context.Musics.AsNoTracking()
                                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                    .ToList();
            var lista = new List<MusicViewModel>();
            
            foreach (var item in result)
            {
                lista.Add(_mapper.Map<MusicViewModel>(item));
            }
            return lista;
        }

        public MusicViewModel Post(MusicViewModel model)
        {
            //var music =_mapper.Map<Music>(model);
            var music = new Music() {
                    Code = model.Code,
                    Genre = model.Genre,
                    Name = model.Name
            };
            _context.Musics.Add(music);
            _context.SaveChangesAsync();
            
            return model;
        }

        public MusicViewModel Put(MusicViewModel music)
        {
            var objeto = _context.Musics.Find(music.Id);
                        
            if (objeto != null)
            {
                objeto.Name = music.Name;
                objeto.Code = music.Code;
                objeto.Genre = music.Genre;
            }

            _context.Musics.Update(objeto);

            _context.SaveChangesAsync();
            var musicvm = _mapper.Map<MusicViewModel>(music);

            return musicvm;
        }

        public MusicViewModel Delete(string id)
        {
            var _idGuid = new Guid(id);

            var objeto = _context.Musics.Find(_idGuid);

            if (objeto == null)
            {
                return null;
            }
            _context.Musics.Remove(objeto);

            _context.SaveChangesAsync();
            var musicvm = _mapper.Map<MusicViewModel>(objeto);
            return musicvm;
        }
                
    }
}
