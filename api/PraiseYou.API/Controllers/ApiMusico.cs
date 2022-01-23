using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Application.Escalas;
using PraiseYou.Application.Musicos;
using PraiseYou.Domain.Musicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseYou.API.Controllers
{
    [Route("api/musicos")]
    [ApiController]
    [Authorize]
    public class ApiMusico : AbstractApi
    {
        private readonly MusicoFacade musicoFacade;

        public ApiMusico(MusicoFacade musicoFacade)
        {
            this.musicoFacade = musicoFacade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musico>> Listar()
        {
            try
            {
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
