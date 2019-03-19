using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.DTO.Lancamentos
{
    public class LancamentosListagemQueryParams
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "Data";
        public int Mes { get; set; } = DateTime.Now.Month;
        public int Ano { set; get; } = DateTime.Now.Year;
        public string TextoPesquisa { set; get; }
        public string TipoMovimentacao { set; get; }
        public string Situacao { set; get; }
        public string TipoOperacao { set; get; }
        public string CategoriaId { set; get; }
    }
}
