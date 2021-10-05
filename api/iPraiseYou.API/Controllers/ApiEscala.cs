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
    public class ApiEscala : ControllerBase
    {
        private readonly DataContext _context;

        public ApiEscala(DataContext context)
        {
            _context = context;
        }        

        // GET: api/Escalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escala>>> Get()
        {
            return await _context.Escalas.AsNoTracking()
                .Include(m => m.Musicos)
                .Include(m => m.Musicas)
                .ToListAsync();
        }

        // GET: api/Escalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escala>> Get(int id)
        {
            var escala = await _context.Escalas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

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
