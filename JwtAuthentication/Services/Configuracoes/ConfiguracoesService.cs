using JwtAuthentication.Data;
using JwtAuthentication.DTO.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Services.Configuracoes
{
    public class ConfiguracoesService
    {
        private readonly ApplicationDbContext _context;
        private readonly EnumService _enumService;
        private readonly CategoriasService _categoriasService;

        public ConfiguracoesService(ApplicationDbContext context, EnumService enumService, CategoriasService categoriasService)
        {
            _context = context;
            _enumService = enumService;
            _categoriasService = categoriasService;
        }

        public object GetConfiguracoes()
        {
            return new {
                tiposOperacoes = _enumService.GetOperacoesEnum(),
                tiposMovimentacoes = _enumService.GetMovimentacoesEnum(),
                LancamentosSituacoes = _enumService.GetLancamentosSituacoesEnum(),
                Categorias = _categoriasService.GetCategorias(),
                mesAnoComLancamentos = GetMesAnoComLancamentos(),
                mesAnoComLancamentosDefault = GetMesAnoComLancamentoDefault()
            };
        }

        public IEnumerable<MesAnoComLancamentos> GetMesAnoComLancamentos()
        {
            return _context.MesAnoComLancamentos.AsNoTracking().FromSql(@"select Distinct month(l.data) Mes, year(l.data) Ano
                From Lancamentos l group by l.data order by Ano DESC, Mes DESC").ToList();

        }

        public MesAnoComLancamentos GetMesAnoComLancamentoDefault()
        {
            return new MesAnoComLancamentos() {
                Mes = DateTime.Now.Month,
                Ano = DateTime.Now.Year
            };
        }
    }
}