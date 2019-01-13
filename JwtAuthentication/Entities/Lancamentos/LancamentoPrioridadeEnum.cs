using System.ComponentModel;
using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Lancamentos
{
    public enum LancamentoPrioridadeEnum
    {
        [EnumMember(Value = "0")]
        [Description("Categorizar")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        [Description("Fixa")]
        Fixa = 1,
        [EnumMember(Value = "2")]
        [Description("Variável")]
        Variavel = 2
    }
}