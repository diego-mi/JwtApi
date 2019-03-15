using JwtAuthentication.Entities.Categorias;
using JwtAuthentication.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthentication.Entities.Lancamentos
{
    [Table("Lancamentos")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Display(Name = "Data")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Data { get; set; }

        [Display(Name = "Valor R$")]
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        //[Display(Name = "Prioridade")]
        //[EnumDataType(typeof(LancamentoPrioridadeEnum))]
        //public LancamentoPrioridadeEnum Prioridade { get; set; }

        [Display(Name = "Tipo de Movimentação")]
        [Required]
        [EnumDataType(typeof(TipoMovimentacaoEnum))]
        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        [NotMapped]
        public string TipoMovimentacaoNome => TipoMovimentacao.ToString("g");

        [Display(Name = "Situação")]
        [Required]
        [EnumDataType(typeof(LancamentoSituacaoEnum))]
        [Column(TypeName = "nvarchar(24)")]
        public LancamentoSituacaoEnum Situacao { get; set; }

        [NotMapped]
        public string SituacaoNome => Situacao.ToString("g");

        [Display(Name = "Tipo de Operação")]
        [Required]
        [EnumDataType(typeof(TipoOperacaoEnum))]
        public TipoOperacaoEnum TipoOperacao { get; set; }

        [NotMapped]
        public string TipoOperacaoNome => TipoOperacao.ToString("g");

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [Display(Name = "Autor")]
        public string AutorId { get; set; }

        public ApplicationUser Autor { get; set; }
    }
}
