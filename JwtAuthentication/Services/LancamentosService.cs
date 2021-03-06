﻿using JwtAuthentication.Data;
using JwtAuthentication.DTO.Lancamentos;
using JwtAuthentication.Entities.Enums;
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

        public object ListagemPaginada (LancamentosListagemQueryParams lancamentosListagemQueryParams)
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
    }
}
