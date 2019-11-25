using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using devmusic.api.Data;
using devmusic.api.Models;
using System;
using devmusic.api.Service;

namespace devmusic.api.Controllers
{
    [Route("v1/author")]
    public class AuthorController:ControllerBase
    {
        private ServiceAuthor _service;

        public AuthorController(DBMusicContext context, ServiceAuthor service)
        {
          
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromServices] DBMusicContext context)
        {
            try
            {
                var lista = _service.GetAuthor();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromServices] DBMusicContext context, string id)
        {
            try
            {
                var _idGuid = new Guid(id);
                var author = _service.GetById(_idGuid);                
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getbyname/{name}")]
        public async Task<IActionResult> GetByName([FromServices] DBMusicContext context, string name)
        {
            try
            {
                var author = _service.GetByName(name);

                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] DBMusicContext context, [FromBody]Author model)
        {
            try
            { 
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var author = _service.Post(model);
            
            return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] DBMusicContext context, [FromBody]Author model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var objeto = _service.Put(model);

                return Ok(objeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] DBMusicContext context, [FromBody]string id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var objeto = _service.Delete(id);

                if (objeto != null)
                {
                    return BadRequest(ModelState);
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