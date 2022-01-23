using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraiseYou.Application.Escalas;
using PraiseYou.Application.Musicas;
using PraiseYou.Domain.Musicas;
using System;
using System.Collections.Generic;

namespace PraiseYou.API.Controllers
{
    [Route("api/musicas")]
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

        [HttpPut("atualziar")]
        public IActionResult Atualizar([FromBody] MusicaRequisicao requisicao)
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

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] MusicaRequisicao requisicao)
        {
            try
            {
                this.musicaFacade.Cadastrar(requisicao);
                return Success();

            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
    }
}
