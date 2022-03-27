﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraiseYou.Application.Escalas;
using PraiseYou.Domain.Escalas;
using System;
using System.Collections.Generic;

namespace PraiseYou.API.Controllers
{
    [Route("api/escalas")]
    [ApiController]
    [Authorize]
    public class ApiEscala : AbstractApi
    {
        private readonly EscalaFacade escalaFacade;

        public ApiEscala(EscalaFacade escalaFacade)
        {
            this.escalaFacade = escalaFacade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Escala>> Listar()
        {
            try
            {
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
                var escala = this.escalaFacade.ListarPorId(id);
                return Success(escala);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }      
    }
}
