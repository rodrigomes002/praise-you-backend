using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Application.Escalas;
using PraiseYou.Domain.Musicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseYou.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiMusico : ControllerBase
    {
        private readonly MusicoFacade musicoFacade;

        public ApiMusico(MusicoFacade musicoFacade)
        {
            this.musicoFacade = musicoFacade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musico>> Listar()
        {
            return Ok(this.musicoFacade.Listar());
        }

        // GET: api/Musicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musico>> Get(int id)
        {
            var musico = await _context.Musicos.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (musico == null)
            {
                return NotFound();
            }

            return musico;
        }

        // PUT: api/Musicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Musico musico)
        {
            if (id != musico.Id)
            {
                return BadRequest();
            }

            _context.Entry(musico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();

        }

        // POST: api/Musicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musico>> Post(Musico musico)
        {
            _context.Musicos.Add(musico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = musico.Id }, musico);
        }

        // DELETE: api/Musicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var musico = await _context.Musicos.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (musico == null)
            {
                return NotFound();
            }

            _context.Musicos.Remove(musico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
