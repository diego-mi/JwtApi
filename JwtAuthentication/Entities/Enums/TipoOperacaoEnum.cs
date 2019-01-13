using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoOperacaoEnum
    {
        [EnumMember(Value = "0")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        CartaoCredito = 1,
        [EnumMember(Value = "2")]
        DebitoEmConta = 2,
        [EnumMember(Value = "3")]
        Dinheiro = 3,
        [EnumMember(Value = "4")]
        ValeRefeicao = 4
    }
}
