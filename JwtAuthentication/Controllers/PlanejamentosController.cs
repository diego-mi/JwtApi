using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtAuthentication.Data;
using JwtAuthentication.Entities.Planejamentos;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthentication.Controllers
{
    [Route("api/v1/planejamentos")]
    [ApiController]
    [Authorize]
    public class PlanejamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlanejamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Planejamentos
        [HttpGet]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public IEnumerable<Planejamento> GetPlanejamentos()
        {
            return _context.Planejamentos;
        }

        // GET: api/Planejamentos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> GetPlanejamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planejamento = await _context.Planejamentos.FindAsync(id);

            if (planejamento == null)
            {
                return NotFound();
            }

            return Ok(planejamento);
        }

        // PUT: api/Planejamentos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> PutPlanejamento([FromRoute] int id, [FromBody] Planejamento planejamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planejamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(planejamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanejamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Planejamentos
        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> PostPlanejamento([FromBody] Planejamento planejamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Planejamentos.Add(planejamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanejamento", new { id = planejamento.Id }, planejamento);
        }

        // DELETE: api/Planejamentos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> DeletePlanejamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planejamento = await _context.Planejamentos.FindAsync(id);
            if (planejamento == null)
            {
                return NotFound();
            }

            _context.Planejamentos.Remove(planejamento);
            await _context.SaveChangesAsync();

            return Ok(planejamento);
        }

        private bool PlanejamentoExists(int id)
        {
            return _context.Planejamentos.Any(e => e.Id == id);
        }
    }
}