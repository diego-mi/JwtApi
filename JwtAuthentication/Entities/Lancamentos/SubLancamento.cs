using System.ComponentModel.DataAnnotations;

namespace JwtAuthentication.Entities.Lancamentos
{
    public class SubLancamento : Lancamento
    {
        [Display(Name = "Lançamento Pai")]
        public int LancamentoPaiId { get; set; }

        public Lancamento Lancamento { get; set; }
    }
}
