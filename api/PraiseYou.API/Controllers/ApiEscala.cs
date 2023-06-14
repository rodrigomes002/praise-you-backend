using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PraiseYou.Application.Escalas;
using PraiseYou.Application.Musicas;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Musicos;
using System;
using System.Collections.Generic;

namespace PraiseYou.API.Controllers
{
    [Route("api/escalas")]
    [ApiController]
    //[Authorize]
    public class ApiEscala : AbstractApi
    {
        private readonly EscalaFacade escalaFacade;
        private readonly ILogger<ApiEscala> logger;

        public ApiEscala(EscalaFacade escalaFacade, ILogger<ApiEscala> logger)
        {
            this.escalaFacade = escalaFacade;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EscalaResponse>> Listar()
        {
            try
            {
                logger.LogInformation("REQUISICAO - Buscando todas as escalas.");
                var escalas = this.escalaFacade.Listar();                
                return Success(escalas);
            }
            catch (Exception e)
            {
                return Error(e);
            }            
        }

        [HttpGet("{id}")]
        public ActionResult<Escala> Listar(int id)
        {
            try
            {
                logger.LogInformation("REQUISICAO - Buscando escala por id: "+ id);
                var escala = this.escalaFacade.ListarPorId(id);
                return Success(escala);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] EscalaRequisicao requisicao)
        {
            try
            {
                logger.LogInformation("REQUISICAO - Cadastrando uma escala");
                this.escalaFacade.Cadastrar(requisicao);
                return Success();

            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {

            try
            {
                logger.LogInformation("REQUISICAO - Buscando escala por id: " + id);
                this.escalaFacade.Deletar(id);
                return Success();
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
    }
}
