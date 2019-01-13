using System.ComponentModel;

namespace JwtAuthentication.Entities.Categorias
{
    public enum CategoriaGrupoEnum
    {
        [Description("Não Categorizado")]
        NaoCategorizado = 0,
        [Description("Contas Residênciais")]
        ContasResidenciais = 1,
        [Description("Alimentação")]
        Alimentacao = 2,
        [Description("Saúde")]
        Saude = 3,
        [Description("Gastos Essenciais")]
        GastosEssenciais = 4,
        [Description("Transporte")]
        Transporte = 5,
        [Description("Gastos Gerais")]
        GastosGerais = 6,
        [Description("Família")]
        Familia = 7,
        [Description("Servicos Bancários")]
        ServicosBancarios = 8,
        [Description("Renda")]
        Renda = 9,
        [Description("Movimentação entre contas")]
        MovimentacaoEntreContas = 10,
        [Description("Lancamento Registro")]
        Registro = 11
    }
}
