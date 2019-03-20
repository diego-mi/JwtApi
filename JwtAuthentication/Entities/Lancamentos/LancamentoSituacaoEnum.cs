using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JwtAuthentication.Entities.Lancamentos
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum LancamentoSituacaoEnum
    {
        [EnumMember(Value = "0")]
        [Description("Categorizar")]
        Categorizar,
        [EnumMember(Value = "1")]
        [Description("Aberta")]
        Aberta,
        [EnumMember(Value = "2")]
        [Description("Fechada")]
        Fechada
    }
}
