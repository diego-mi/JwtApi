using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthentication.Entities.Categorias
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public CategoriaGrupoEnum Grupo { get; set; }

        public string AutorId { get; set; }

        public ApplicationUser Autor { get; set; }
    }
}
