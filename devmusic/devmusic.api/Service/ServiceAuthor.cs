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
    public class ServiceAuthor
    {
        private DBMusicContext _context;
        private readonly IMapper _mapper;

        public ServiceAuthor(DBMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> GetAuthor()
        {
            var result = _context.Authors
            .AsNoTracking()
            .ToList();

            var lista = new List<AuthorViewModel>();

            foreach (var item in result)
            {
                lista.Add(_mapper.Map<AuthorViewModel>(item));
            }
            return lista;
        }

        public AuthorViewModel GetById(Guid id)
        {
            var author = _context.Authors.AsNoTracking()
                                    .FirstOrDefault(x => x.Id == id);

            var authorvm = new AuthorViewModel();
            authorvm = _mapper.Map<AuthorViewModel>(author);
            return authorvm;
        }

        public List<AuthorViewModel> GetByName(string name)
        {
            var result = _context.Authors.AsNoTracking()
                                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                    .ToList();
            var lista = new List<AuthorViewModel>();

            foreach (var item in result)
            {
                lista.Add(_mapper.Map<AuthorViewModel>(item));
            }
            return lista;
        }

        public AuthorViewModel Post(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChangesAsync();
            var authorvm = _mapper.Map<AuthorViewModel>(author);
            return authorvm;
        }

        public AuthorViewModel Put(Author author)
        {
            var objeto = _context.Authors.Find(author.Id);

            if (objeto != null)
            {
                objeto.Name = author.Name;
                objeto.Code = author.Code;
                objeto.Category = author.Category;
            }

            _context.Authors.Update(objeto);

            _context.SaveChangesAsync();
            var authorvm = _mapper.Map<AuthorViewModel>(author);

            return authorvm;
        }

        public AuthorViewModel Delete(string id)
        {
            var _idGuid = new Guid(id);

            var objeto = _context.Authors.Find(_idGuid);

            if (objeto == null)
            {
                return null;
            }
            _context.Authors.Remove(objeto);

            _context.SaveChangesAsync();
            var authorvm = _mapper.Map<AuthorViewModel>(objeto);
            return authorvm;
        }
    }
}
