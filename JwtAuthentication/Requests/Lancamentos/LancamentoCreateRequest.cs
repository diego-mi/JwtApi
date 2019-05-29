using JwtAuthentication.Entities.Enums;
using JwtAuthentication.Entities.Lancamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Requests.Lancamentos
{
    public class LancamentoCreateRequest
    {
        [StringLength(200)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime? Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Display(Name = "Tipo")]
        [Required]
        public string Tipo { get; set; }

        [Required]
        [EnumDataType(typeof(TipoMovimentacaoEnum))]
        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        [Required]
        [EnumDataType(typeof(LancamentoSituacaoEnum))]
        public LancamentoSituacaoEnum Situacao { get; set; }

        [Required]
        [EnumDataType(typeof(TipoOperacaoEnum))]
        public TipoOperacaoEnum TipoOperacao { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public int QuantidadeDeParcelas { get; set; } = 1;

        public int ParcelaAtual { get; set; } = 1;
    }
}
