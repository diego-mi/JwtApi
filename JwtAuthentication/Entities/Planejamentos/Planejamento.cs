using JwtAuthentication.Entities.Categorias;
using JwtAuthentication.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthentication.Entities.Planejamentos
{
    [Table("Planejamentos")]
    public class Planejamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Valor R$")]
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }


        [Display(Name = "Tipo de Movimentação")]
        [Required]
        [EnumDataType(typeof(TipoMovimentacaoEnum))]
        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public string AutorId { get; set; }

        public ApplicationUser Autor { get; set; }
    }
}
