using System.ComponentModel;

namespace JwtAuthentication.Entities.Enums
{
    public enum TipoOperacaoEnum
    {
        [Description("Categorizar")]
        Categorizar = 0,
        [Description("Cartão de Crédito")]
        CartaoCredito = 1,
        [Description("Débito em Conta")]
        DebitoEmConta = 2,
        [Description("Dinheiro")]
        Dinheiro = 3,
        [Description("Vale")]
        ValeRefeicao = 4
    }
}
