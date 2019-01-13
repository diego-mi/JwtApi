using JwtAuthentication.Data;
using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Entities.Tagueamentos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JwtAuthentication.Services
{
    public class TagueamentoService
    {

        private readonly ApplicationDbContext _context;

        public TagueamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Taguear(Lancamento lancamento)
        {
            Tagueamento tagueamento = _context.Tagueamentos.AsNoTracking().SingleOrDefault(m => m.CategoriaId == lancamento.CategoriaId);

            string novoTagueamento = lancamento.Nome;

            if (tagueamento == null)
            {
                tagueamento = new Tagueamento { CategoriaId = lancamento.CategoriaId };
                string novoTagueamentoDistinct = string.Join(" ", novoTagueamento.Split().Where(x => x != string.Empty).Distinct());

                tagueamento.Tags = novoTagueamentoDistinct;

                _context.Add(tagueamento);
                //_context.Entry(categoriaTag).CurrentValues.SetValues(new { CategoriaId = lancamento.CategoriaId });
            }
            else
            {
                novoTagueamento += " " + tagueamento.Tags;
                string novoTagueamentoDistinct = string.Join(" ", novoTagueamento.Split().Where(x => x != string.Empty).Distinct());

                tagueamento.Tags = novoTagueamentoDistinct;

                _context.Update(tagueamento);
            }
        }

    }
}
