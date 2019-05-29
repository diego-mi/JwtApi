using JwtAuthentication.Data;
using JwtAuthentication.DTO.Lancamentos;
using JwtAuthentication.Entities.Enums;
using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Factories.Lancamentos;
using JwtAuthentication.Requests.Lancamentos;
using JwtAuthentication.Responses.Lancamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Services
{
    public class LancamentosService
    {
        private readonly ApplicationDbContext _context;

        public LancamentosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object ListagemPaginada(LancamentosListagemQueryParams lancamentosListagemQueryParams)
        {
            try
            {
                var query = _context.Lancamentos.Include(l => l.Categoria).AsNoTracking();

                // Mes de referencia
                if (lancamentosListagemQueryParams.Mes != 0)
                {
                    var startDate = new DateTime(lancamentosListagemQueryParams.Ano, lancamentosListagemQueryParams.Mes, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);

                    query = query.Where(l => l.Data >= startDate && l.Data <= endDate);
                }

                // Pesquisa por texto
                if (!string.IsNullOrWhiteSpace(lancamentosListagemQueryParams.TextoPesquisa))
                {
                    query = query.Where(l => l.Nome.Contains(lancamentosListagemQueryParams.TextoPesquisa));
                }

                // Pesquisa por situacao
                if (!string.IsNullOrWhiteSpace(lancamentosListagemQueryParams.Situacao))
                {
                    query = query.Where(l => l.Situacao.ToString() == lancamentosListagemQueryParams.Situacao);
                }

                // Pesquisa por operacao
                if (!string.IsNullOrWhiteSpace(lancamentosListagemQueryParams.TipoOperacao))
                {
                    int tipoOperacaoInt = Convert.ToInt32(lancamentosListagemQueryParams.TipoOperacao);
                    query = query.Where(l => l.TipoOperacao == (TipoOperacaoEnum)tipoOperacaoInt);
                }

                // Pesquisa por movimentacao
                if (!string.IsNullOrWhiteSpace(lancamentosListagemQueryParams.TipoMovimentacao))
                {
                    int tipoMovimentacaoInt = Convert.ToInt32(lancamentosListagemQueryParams.TipoMovimentacao);
                    query = query.Where(l => l.TipoMovimentacao == (TipoMovimentacaoEnum)tipoMovimentacaoInt);
                }

                // OrderBys
                if (lancamentosListagemQueryParams.OrderBy == "Nome")
                {
                    query = query.OrderBy(l => l.Nome);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "Valor")
                {
                    query = query.OrderBy(l => l.Valor);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "Data")
                {
                    query = query.OrderByDescending(l => l.Data);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "CategoriaId")
                {
                    query = query.OrderBy(l => l.CategoriaId);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "Situacao")
                {
                    query = query.OrderBy(l => l.Situacao);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "TipoMovimentacao")
                {
                    query = query.OrderBy(l => l.TipoMovimentacao);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "TipoOperacao")
                {
                    query = query.OrderBy(l => l.TipoOperacao);
                }
                else if (lancamentosListagemQueryParams.OrderBy == "Tipo")
                {
                    query = query.OrderBy(l => l.Tipo);
                }
                else
                {
                    query = query.OrderByDescending(l => l.Data);
                }

                return new
                {
                    TotalItems = query.Count(),
                    TotalPages = (int)Math.Ceiling(query.Count() / (double)lancamentosListagemQueryParams.PageSize.Value),
                    items = query.Skip(lancamentosListagemQueryParams.PageSize.Value * (lancamentosListagemQueryParams.CurrentPage.Value - 1)).Take(lancamentosListagemQueryParams.PageSize.Value).ToList()
                };
            }
            catch (Exception exception)
            {
                return new
                {
                    MensagemErro = exception.Message
                };
            }
        }

        public async Task<LancamentoCreateResponse> CreateAsync(LancamentoCreateRequest lancamentoRequest)
        {
            if (lancamentoRequest.QuantidadeDeParcelas == 1)
            {
                return await CreateOneAsync(lancamentoRequest);
            }
            else
            {
                return await CreateManyAsync(lancamentoRequest);
            }
        }

        public async Task<LancamentoCreateResponse> CreateOneAsync(LancamentoCreateRequest lancamentoRequest)
        {
            try
            {
                Lancamento lancamento = LancamentoCreateEntityFactory.CreateOneByRequest(lancamentoRequest);

                _context.Lancamentos.Add(lancamento);
                await _context.SaveChangesAsync();

                return LancamentoCreateResponseFactory.CreatedOneSuccess(lancamento);
            }
            catch (Exception exception)
            {
                return LancamentoCreateResponseFactory.CreateOneFailedWithServerError(exception.Message);
            }
        }

        public async Task<LancamentoCreateResponse> CreateManyAsync(LancamentoCreateRequest lancamentoRequest)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int quantidadeParcelaACriar = lancamentoRequest.QuantidadeDeParcelas - lancamentoRequest.ParcelaAtual - 1;

                    IList<Lancamento> lancamentos = CriarLancamentosParcelados(lancamentoRequest, quantidadeParcelaACriar);
                    AddLancamentosToSave(lancamentos);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return LancamentoCreateResponseFactory.CreatedManySuccess(lancamentos);
                }
                catch (Exception exception)
                {
                    return LancamentoCreateResponseFactory.CreateManyFailedWithServerError(exception.Message);
                }
            }
        }

        private void AddLancamentosToSave(IList<Lancamento> lancamentos)
        {
            foreach (Lancamento lancamentoParcela in lancamentos)
            {
                _context.Lancamentos.Add(lancamentoParcela);
            }
        }

        private IList<Lancamento> CriarLancamentosParcelados(LancamentoCreateRequest lancamentoRequest, int quantidadeParcelaACriar)
        {
            IList<Lancamento> lancamentos = new List<Lancamento>();

            for (int i = 0; i < quantidadeParcelaACriar; i++)
            {
                lancamentos.Add(LancamentoCreateEntityFactory.CreateOneByRequest(lancamentoRequest));
            }

            return lancamentos;
        }
    }
}
