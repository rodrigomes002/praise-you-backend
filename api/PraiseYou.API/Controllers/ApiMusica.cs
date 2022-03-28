using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ApiMusica> logger;

        public ApiMusica(MusicaFacade musicaFacade, ILogger<ApiMusica> logger)
        {
            this.musicaFacade = musicaFacade;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> Listar()
        {
            try
            {
                logger.LogInformation("REQUISICAO - Buscando todas as musicas.");
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
                logger.LogInformation("REQUISICAO - Buscando musica por id: " + id);
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
                logger.LogInformation("REQUISICAO - Atualizando uma musica");
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
                logger.LogInformation("REQUISICAO - Cadastrando uma musica");
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
