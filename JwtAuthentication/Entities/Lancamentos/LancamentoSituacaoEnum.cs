using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JwtAuthentication.Entities.Lancamentos
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LancamentoSituacaoEnum
    {
        [EnumMember(Value = "0")]
        [Description("Categorizar")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        [Description("Aberta")]
        Aberta = 1,
        [EnumMember(Value = "2")]
        [Description("Fechada")]
        Fechada = 2
    }
}
