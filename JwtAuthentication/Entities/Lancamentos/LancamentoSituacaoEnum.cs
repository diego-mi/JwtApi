using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JwtAuthentication.Entities.Lancamentos
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum LancamentoSituacaoEnum
    {
        Categorizar,
        Aberta,
        Fechada
    }
}
