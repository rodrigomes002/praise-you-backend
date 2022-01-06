using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Application.Escalas;
using PraiseYou.Domain.Escalas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseYou.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiEscala : ControllerBase
    {
        private readonly EscalaFacade escalaFacade;

        public ApiEscala(EscalaFacade escalaFacade)
        {
            this.escalaFacade = escalaFacade;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(this.escalaFacade.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Escala> Listar(int id)
        {
            var escala = this.escalaFacade.ListarPorId(id);

            if (escala == null)
            {
                return NotFound();
            }

            return escala;
        }

        // PUT: api/Escalas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Escala escala)
        {
            if (id != escala.Id)
            {
                return BadRequest();
            }

            _context.Entry(escala).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();

        }

        // POST: api/Escalas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Escala>> Post([FromBody] Escala escala)
        {
            _context.Escalas.Add(escala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = escala.Id }, escala);
        }

        // DELETE: api/Escalas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var escala = await _context.Escalas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            _context.Escalas.Remove(escala);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
