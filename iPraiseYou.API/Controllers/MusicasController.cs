using iPraiseYou.API.Data;
using iPraiseYou.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPraiseYou.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly DataContext _context;

        public MusicasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Musicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musica>>> Get()
        {
            return await _context.Musicas.AsNoTracking().ToListAsync();
        }

        // GET: api/Musicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> Get(int id)
        {
            var musica = await _context.Musicas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

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
