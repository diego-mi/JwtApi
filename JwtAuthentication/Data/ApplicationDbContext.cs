using JwtAuthentication.DTO.Configuracoes;
using JwtAuthentication.Entities;
using JwtAuthentication.Entities.Categorias;
using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Entities.Planejamentos;
using JwtAuthentication.Entities.Tagueamentos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Planejamento> Planejamentos { get; set; }
        public DbSet<Tagueamento> Tagueamentos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<SubLancamento> SubLancamento { get; set; }
        public DbQuery<MesAnoComLancamentos> MesAnoComLancamentos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region "Seed Data"

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            builder.Entity<Categoria>().HasData(
                // Categorizar
                new Categoria() { Id = 1, Icone = "simple-icon-exclamation", Nome = "A Categorizar", Grupo = CategoriaGrupoEnum.NaoCategorizado, AutorId = null },
                // Contas Residenciais
                new Categoria() { Id = 2, Icone = "iconsmind-Warehouse", Nome = "Aluguel", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 3, Icone = "iconsmind-Light-Bulb", Nome = "Luz", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 4, Icone = "iconsmind-Glass-Water", Nome = "Água", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 5, Icone = "iconsmind-Old-TV", Nome = "TV/Internet/Telefone Residêncial", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 6, Icone = "iconsmind-Repair", Nome = "Manutenção/Melhorias", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 7, Icone = "iconsmind-Security-Block", Nome = "Seguros", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 8, Icone = "iconsmind-Security-Camera", Nome = "Segurança", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                // Alimentação
                new Categoria() { Id = 9, Icone = "iconsmind-Add-Cart", Nome = "Mercado Dispensa/Essencial", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                new Categoria() { Id = 10, Icone = "iconsmind-Add-Cart", Nome = "Mercado Filhas", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                new Categoria() { Id = 11, Icone = "iconsmind-Add-Cart", Nome = "Mercado não essencial", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                // Saúde
                new Categoria() { Id = 12, Icone = "iconsmind-Rain-Drop", Nome = "Higiêne Geral", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 13, Icone = "iconsmind-Rain-Drop", Nome = "Higiêne Filhas", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 14, Icone = "iconsmind-Medical-Sign", Nome = "Plano de saúde", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 15, Icone = "iconsmind-Medicine-3", Nome = "Farmácia", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 16, Icone = "iconsmind-Medicine-3", Nome = "Farmácia Filhas", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                // Transporte
                new Categoria() { Id = 17, Icone = "iconsmind-Motorcycle", Nome = "Moto - Abastecimento", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 18, Icone = "iconsmind-Motorcycle", Nome = "Moto - Manutenção/Melhorias", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 19, Icone = "iconsmind-Taxi-Sign", Nome = "Uber - Essencial", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 20, Icone = "iconsmind-Taxi-Sign", Nome = "Uber - Escola Laura", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 21, Icone = "iconsmind-Taxi-Sign", Nome = "Uber - Saidinhas e Outros", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 22, Icone = "iconsmind-Taxi-2", Nome = "Outros", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                // Gastos Essenciais
                new Categoria() { Id = 23, Icone = "simple-icon-notebook", Nome = "Educação", Grupo = CategoriaGrupoEnum.GastosEssenciais, AutorId = null },
                // Gastos Gerais
                new Categoria() { Id = 24, Icone = "iconsmind-Coffee", Nome = "Lanches / Saidinhas", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 25, Icone = "iconsmind-Car-Coins", Nome = "Compras", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 26, Icone = "simple-icon-exclamation", Nome = "Cuidados Pessoais", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 27, Icone = "simple-icon-exclamation", Nome = "Despesas do Trabalho", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 28, Icone = "simple-icon-present", Nome = "Presentes/Doações", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                // Familia
                new Categoria() { Id = 29, Icone = "simple-icon-exclamation", Nome = "Pensão Mariah", Grupo = CategoriaGrupoEnum.Familia, AutorId = null },
                // Servicos Bancários
                new Categoria() { Id = 30, Icone = "simple-icon-exclamation", Nome = "Impostos", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 31, Icone = "simple-icon-exclamation", Nome = "Multa/Juros", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 32, Icone = "simple-icon-exclamation", Nome = "Taxas Bancárias", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 33, Icone = "simple-icon-exclamation", Nome = "Cheque Especial", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 34, Icone = "simple-icon-exclamation", Nome = "Pagamento de Empréstimo", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                // Renda
                new Categoria() { Id = 35, Icone = "simple-icon-exclamation", Nome = "Remuneração", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 36, Icone = "simple-icon-exclamation", Nome = "Bônus", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 37, Icone = "simple-icon-exclamation", Nome = "Rendimento", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 38, Icone = "simple-icon-exclamation", Nome = "Empréstimo", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 48, Icone = "simple-icon-exclamation", Nome = "Vale Refeição", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 39, Icone = "simple-icon-exclamation", Nome = "Outras Rendas", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 40, Icone = "simple-icon-exclamation", Nome = "Indenização - Despesa do Trabalho", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                // Movimentação entre contas
                new Categoria() { Id = 42, Icone = "simple-icon-exclamation", Nome = "Saque", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 43, Icone = "simple-icon-exclamation", Nome = "Aplicação", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 44, Icone = "simple-icon-exclamation", Nome = "Resgate", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 45, Icone = "simple-icon-exclamation", Nome = "Transfência", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 46, Icone = "simple-icon-exclamation", Nome = "Pagamento de cartão", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                // Lançamentos subdivididos
                new Categoria() { Id = 47, Icone = "simple-icon-exclamation", Nome = "Lançamento subcategorizado", Grupo = CategoriaGrupoEnum.Registro, AutorId = null }
            );

            #endregion
        }
    }

}
