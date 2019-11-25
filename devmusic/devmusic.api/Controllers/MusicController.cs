using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using devmusic.api.Data;
using devmusic.api.Models;
using devmusic.api.Service;
using devmusic.api.ViewModels;

namespace devmusic.api.Controllers
{
    [Route("v1/Music")]
    public class MusicController:ControllerBase
    {
         private ServiceMusic _service;

         public MusicController(ServiceMusic service)
         {
            _service = service;
         }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var lista = _service.GetMusic();
            return Ok(lista);
        }

        //[HttpGet]
        //[Route("getauthorsbymusic")]
        //public async Task<IActionResult> GetAuthorByMusic([FromServices] DBMusicContext context)
        //{
        //    var lista = await context.Musics.Include(music => music.MusicAuthor)
        //    .ThenInclude(x => x.Author)
        //    .AsNoTracking()
        //    .ToListAsync();

        //    return Ok(lista);
        //}

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById( string id)
        {
            try{
                var _idGuid = new Guid(id);
                var music = _service.GetMusicById(_idGuid);
                
                return Ok(music);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);      
            }
        }

        [HttpGet]
        [Route("getbyname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var music = _service.GetMusicByName(name);
                    
                return Ok(music);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);      
            }                
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MusicViewModel model)
        {
            try 
{ 
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _service.Post(model);
            
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] DBMusicContext context, [FromBody]MusicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var music = _service.Put(model);

                return Ok(music);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] DBMusicContext context, [FromBody]string id)
        {
            try
            {
                var objeto =_service.Delete(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (objeto != null)
                {
                    return BadRequest("Registro não localizado!");
                }

                return Ok(objeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}