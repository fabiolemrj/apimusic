
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using devmusic.api.Data;
using devmusic.api.Models;
using System;
using devmusic.api.Service;

namespace devmusic.api.Controllers
{

    [Route("v1/musicauthor")]
    public class MusicAuthorController:ControllerBase
    {
        private readonly ServiceMusicAuthor _service;

        public MusicAuthorController(ServiceMusicAuthor service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] DBMusicContext context, [FromBody]MusicAuthor model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var musicauthor = _service.Post(model);
                return Ok(musicauthor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] DBMusicContext context, [FromBody]MusicAuthor musicauthor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var objeto = _service.Delete(musicauthor.MusicId,musicauthor.AuthorId);

                if (objeto != null)
                {
                    return BadRequest("Não foi encontrado registro");
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