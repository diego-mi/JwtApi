using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JwtAuthentication.Entities.Categorias
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum CategoriaGrupoEnum
    {
        [Description("Não Categorizado")]
        [EnumMember(Value = "0")]
        NaoCategorizado = 0,
        [Description("Contas Residênciais")]
        [EnumMember(Value = "1")]
        ContasResidenciais = 1,
        [Description("Alimentação")]
        [EnumMember(Value = "0")]
        Alimentacao = 2,
        [Description("Saúde")]
        [EnumMember(Value = "3")]
        Saude = 3,
        [Description("Gastos Essenciais")]
        [EnumMember(Value = "4")]
        GastosEssenciais = 4,
        [Description("Transporte")]
        [EnumMember(Value = "5")]
        Transporte = 5,
        [Description("Gastos Gerais")]
        [EnumMember(Value = "6")]
        GastosGerais = 6,
        [Description("Família")]
        [EnumMember(Value = "7")]
        Familia = 7,
        [Description("Servicos Bancários")]
        [EnumMember(Value = "8")]
        ServicosBancarios = 8,
        [Description("Renda")]
        [EnumMember(Value = "9")]
        Renda = 9,
        [Description("Movimentação entre contas")]
        [EnumMember(Value = "10")]
        MovimentacaoEntreContas = 10,
        [Description("Lancamento Registro")]
        [EnumMember(Value = "11")]
        Registro = 11
    }
}
