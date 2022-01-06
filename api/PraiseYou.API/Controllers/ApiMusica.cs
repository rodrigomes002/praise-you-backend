using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Application.Escalas;
using PraiseYou.Domain.Musicas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseYou.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiMusica : ControllerBase
    {
        private readonly MusicaFacade musicaFacade;

        public ApiMusica(MusicaFacade musicaFacade)
        {
            this.musicaFacade = musicaFacade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> Listar()
        {
            return Ok(this.musicaFacade.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Musica> Listar(int id)
        {
            var musica = this.musicaFacade.ListarPorId(id);

            if (musica == null)
            {
                return NotFound();
            }

            return musica;
        }

        // PUT: api/Musicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Musica musica)
        {
            if (id != musica.Id)
            {
                return BadRequest();
            }

            _context.Entry(musica).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Musicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musica>> Post([FromBody] Musica musica)
        {
            _context.Musicas.Add(musica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = musica.Id }, musica);
        }

        // DELETE: api/Musicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var musica = await _context.Musicas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (musica == null)
            {
                return NotFound();
            }

            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
