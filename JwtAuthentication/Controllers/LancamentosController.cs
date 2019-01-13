using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtAuthentication.Data;
using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Services;

namespace JwtAuthentication.Controllers
{
    [Route("api/v1/lancamentos")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TagueamentoService _tagueamentoService;

        public LancamentosController(ApplicationDbContext context, TagueamentoService tagueamentoService)
        {
            _context = context;
            _tagueamentoService = tagueamentoService;
        }

        // GET: api/Lancamentos
        [HttpGet]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public IEnumerable<Lancamento> GetLancamentos()
        {
            return _context.Lancamentos;
        }

        // GET: api/Lancamentos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> GetLancamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lancamento = await _context.Lancamentos.FindAsync(id);

            if (lancamento == null)
            {
                return NotFound();
            }

            return Ok(lancamento);
        }

        // PUT: api/Lancamentos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> PutLancamento([FromRoute] int id, [FromBody] Lancamento lancamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lancamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(lancamento).State = EntityState.Modified;

            try
            {
                _tagueamentoService.Taguear(lancamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoExists(id))
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

        // POST: api/Lancamentos
        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> PostLancamento([FromBody] Lancamento lancamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lancamentos.Add(lancamento);
            _tagueamentoService.Taguear(lancamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLancamento", new { id = lancamento.Id }, lancamento);
        }

        // DELETE: api/Lancamentos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> DeleteLancamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }

            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();

            return Ok(lancamento);
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.Id == id);
        }
    }
}