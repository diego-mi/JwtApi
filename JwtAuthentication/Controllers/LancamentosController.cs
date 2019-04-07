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
using JwtAuthentication.Entities.Categorias;
using Microsoft.AspNetCore.Authorization;
using JwtAuthentication.Helpers.Paging;
using JwtAuthentication.DTO.Lancamentos;

namespace JwtAuthentication.Controllers
{
    [Route("api/v1/lancamentos")]
    [ApiController]
    [Authorize]
    public class LancamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly LancamentosService _lancamentosService;
        //private readonly TagueamentoService _tagueamentoService;

        public LancamentosController(ApplicationDbContext context, LancamentosService lancamentosService)
        {
            _context = context;
            _lancamentosService = lancamentosService;
            //_tagueamentoService = tagueamentoService;
        }

        // GET: api/v1/Lancamentos
        [HttpGet()]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public Object GetLancamentos([FromQuery] LancamentosListagemQueryParams lancamentosListagemQueryParams)
        {
            return _lancamentosService.ListagemPaginada(lancamentosListagemQueryParams);
        }

        // GET: api/v1/Lancamentos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> GetLancamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lancamento = await _context.Lancamentos.Include(l => l.Categoria).AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);

            if (lancamento == null)
            {
                return NotFound("Lancamento não encontrado");
            }

            return Ok(lancamento);
        }

        // PUT: api/v1/Lancamentos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 204)]
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
                return BadRequest("O parâmetro Id na url não corresponde ao informado no lançamento");
            }

            _context.Entry(lancamento).State = EntityState.Modified;

            try
            {
                //_tagueamentoService.Taguear(lancamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoExists(id))
                {
                    return NotFound("Lançamento não encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Lancamentos
        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<IActionResult> PostLancamento([FromBody] Lancamento lancamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Lancamentos.Add(lancamento);
                //_tagueamentoService.Taguear(lancamento);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction("GetLancamento", new { id = lancamento.Id }, lancamento);
        }

        // DELETE: api/v1/Lancamentos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
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
                return NotFound("Lançamento não encontrado");
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