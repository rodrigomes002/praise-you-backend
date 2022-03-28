using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PraiseYou.Application.Escalas;
using PraiseYou.Application.Musicos;
using PraiseYou.Domain.Musicos;
using System;
using System.Collections.Generic;

namespace PraiseYou.API.Controllers
{
    [Route("api/musicos")]
    [ApiController]
    [Authorize]
    public class ApiMusico : AbstractApi
    {
        private readonly MusicoFacade musicoFacade;
        private readonly ILogger<ApiMusico> logger;

        public ApiMusico(MusicoFacade musicoFacade, ILogger<ApiMusico> logger)
        {
            this.musicoFacade = musicoFacade;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musico>> Listar()
        {
            try
            {
                logger.LogInformation("REQUISICAO - Buscando todos os musicos.");
                var resultado = this.musicoFacade.Listar();
                return Success(resultado);
            }
            catch (Exception e)
            {
                return Error(e);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Musico> Listar(int id)
        {

            try
            {
                logger.LogInformation("REQUISICAO - Buscando musico por id: " + id);
                var resultado = this.musicoFacade.ListarPorId(id);
                return Success(resultado);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] MusicoRequisicao requisicao)
        {
            try
            {
                logger.LogInformation("REQUISICAO - Atualizando um musico");
                this.musicoFacade.Atualizar(requisicao);
                return Success();

            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] MusicoRequisicao requisicao)
        {
            try
            {
                logger.LogInformation("REQUISICAO - Cadastrando um musico");
                this.musicoFacade.Cadastrar(requisicao);
                return Success();

            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
    }
}
