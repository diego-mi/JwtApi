using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Lancamentos
{
    public enum LancamentoPrioridadeEnum
    {
        [EnumMember(Value = "0")]
        Categorizar = 0,
        [EnumMember(Value = "1")]
        Fixa = 1,
        [EnumMember(Value = "2")]
        Variavel = 2
    }
}
