using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Application.Escalas;
using PraiseYou.Domain.Musicas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseYou.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApiMusica : AbstractApi
    {
        private readonly MusicaFacade musicaFacade;

        public ApiMusica(MusicaFacade musicaFacade)
        {
            this.musicaFacade = musicaFacade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> Listar()
        {
            try
            {
                var musicas = this.musicaFacade.Listar();
                return Success(musicas);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Musica> Listar(int id)
        {
            try
            {
                var musica = this.musicaFacade.ListarPorId(id);
                return Success(musica);
            }
            catch (Exception e)
            {
                return Error(e);
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Musica requisicao)
        {
            try
            {
                this.musicaFacade.Atualizar(requisicao);
                return Success();

            }
            catch (Exception e)
            {
                return Error(e);
            }
        }      
    }
}
