using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoMovimentacaoEnum
    {
        [EnumMember(Value = "0")]
        [Description("Categorizar")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        [Description("Entrada")]
        Entrada = 1,
        [EnumMember(Value = "2")]
        [Description("Saída")]
        Saida = 2
    }
}
