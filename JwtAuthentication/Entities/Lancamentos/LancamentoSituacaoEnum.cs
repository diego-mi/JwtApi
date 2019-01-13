using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Lancamentos
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LancamentoSituacaoEnum
    {
        [EnumMember(Value = "0")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        Aberta = 1,
        [EnumMember(Value = "2")]
        Fechada = 2
    }
}
