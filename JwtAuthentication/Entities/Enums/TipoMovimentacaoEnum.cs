using System.ComponentModel;

namespace JwtAuthentication.Entities.Enums
{
    public enum TipoMovimentacaoEnum
    {
        [Description("Categorizar")]
        Categorizar = 0,
        [Description("Entrada")]
        Entrada = 1,
        [Description("Saída")]
        Saida = 2
    }
}
