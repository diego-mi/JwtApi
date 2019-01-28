using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Enums
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum TipoOperacaoEnum
    {
        [EnumMember(Value = "0")]
        [Description("Categorizar")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        [Description("Cartão de Crédito")]
        CartaoCredito = 1,
        [EnumMember(Value = "2")]
        [Description("Débito em Conta")]
        DebitoEmConta = 2,
        [EnumMember(Value = "3")]
        [Description("Dinheiro")]
        Dinheiro = 3,
        [EnumMember(Value = "4")]
        [Description("Vale")]
        ValeRefeicao = 4
    }
}
