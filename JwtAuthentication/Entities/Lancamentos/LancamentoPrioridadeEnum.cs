using System.ComponentModel;

namespace JwtAuthentication.Entities.Lancamentos
{
    public enum LancamentoPrioridadeEnum
    {
        [Description("Categorizar")]
        Categorizar = 0,
        [Description("Fixa")]
        Fixa = 1,
        [Description("Variável")]
        Variavel = 2
    }
}
