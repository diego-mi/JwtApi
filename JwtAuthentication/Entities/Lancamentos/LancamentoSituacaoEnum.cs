using System.ComponentModel;

namespace JwtAuthentication.Entities.Lancamentos
{
    public enum LancamentoSituacaoEnum
    {
        [Description("Categorizar")]
        Categorizar = 0,
        [Description("Aberta")]
        Aberta = 1,
        [Description("Fechada")]
        Fechada = 2
    }
}
