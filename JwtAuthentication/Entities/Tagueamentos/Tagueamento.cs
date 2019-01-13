using JwtAuthentication.Entities.Categorias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthentication.Entities.Tagueamentos
{
    [Table("Tagueamentos")]
    public class Tagueamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tags")]
        [Column(TypeName = "text")]
        public string Tags { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
