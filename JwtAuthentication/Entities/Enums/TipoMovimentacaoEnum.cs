using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Enums
{
    public enum TipoMovimentacaoEnum
    {
        [EnumMember(Value = "0")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        Entrada = 1,
        [EnumMember(Value = "2")]
        Saida = 2
    }
}
