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
                new Categoria() { Id = 1, Nome = "A Categorizar", Grupo = CategoriaGrupoEnum.NaoCategorizado, AutorId = null },
                // Contas Residenciais
                new Categoria() { Id = 2, Nome = "Aluguel", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 3, Nome = "Luz", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 4, Nome = "Água", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 5, Nome = "TV/Internet/Telefone Residêncial", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 6, Nome = "Manutenção/Melhorias", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 7, Nome = "Seguros", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                new Categoria() { Id = 8, Nome = "Segurança", Grupo = CategoriaGrupoEnum.ContasResidenciais, AutorId = null },
                // Alimentação
                new Categoria() { Id = 9, Nome = "Mercado Dispensa/Essencial", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                new Categoria() { Id = 10, Nome = "Mercado Filhas", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                new Categoria() { Id = 11, Nome = "Mercado não essencial", Grupo = CategoriaGrupoEnum.Alimentacao, AutorId = null },
                // Saúde
                new Categoria() { Id = 12, Nome = "Higiêne Geral", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 13, Nome = "Higiêne Filhas", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 14, Nome = "Plano de saúde", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 15, Nome = "Farmácia", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                new Categoria() { Id = 16, Nome = "Farmácia Filhas", Grupo = CategoriaGrupoEnum.Saude, AutorId = null },
                // Transporte
                new Categoria() { Id = 17, Nome = "Moto - Abastecimento", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 18, Nome = "Moto - Manutenção/Melhorias", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 19, Nome = "Uber - Essencial", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 20, Nome = "Uber - Escola Laura", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 21, Nome = "Uber - Saidinhas e Outros", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                new Categoria() { Id = 22, Nome = "Outros", Grupo = CategoriaGrupoEnum.Transporte, AutorId = null },
                // Gastos Essenciais
                new Categoria() { Id = 23, Nome = "Educação", Grupo = CategoriaGrupoEnum.GastosEssenciais, AutorId = null },
                // Gastos Gerais
                new Categoria() { Id = 24, Nome = "Lanches / Saidinhas", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 25, Nome = "Compras", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 26, Nome = "Cuidados Pessoais", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 27, Nome = "Despesas do Trabalho", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                new Categoria() { Id = 28, Nome = "Presentes/Doações", Grupo = CategoriaGrupoEnum.GastosGerais, AutorId = null },
                // Familia
                new Categoria() { Id = 29, Nome = "Pensão Mariah", Grupo = CategoriaGrupoEnum.Familia, AutorId = null },
                // Servicos Bancários
                new Categoria() { Id = 30, Nome = "Impostos", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 31, Nome = "Multa/Juros", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 32, Nome = "Taxas Bancárias", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 33, Nome = "Cheque Especial", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                new Categoria() { Id = 34, Nome = "Pagamento de Empréstimo", Grupo = CategoriaGrupoEnum.ServicosBancarios, AutorId = null },
                // Renda
                new Categoria() { Id = 35, Nome = "Remuneração", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 36, Nome = "Bônus", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 37, Nome = "Rendimento", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 38, Nome = "Empréstimo", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 48, Nome = "Vale Refeição", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 39, Nome = "Outras Rendas", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                new Categoria() { Id = 40, Nome = "Indenização - Despesa do Trabalho", Grupo = CategoriaGrupoEnum.Renda, AutorId = null },
                // Movimentação entre contas
                new Categoria() { Id = 42, Nome = "Saque", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 43, Nome = "Aplicação", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 44, Nome = "Resgate", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 45, Nome = "Transfência", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                new Categoria() { Id = 46, Nome = "Pagamento de cartão", Grupo = CategoriaGrupoEnum.MovimentacaoEntreContas, AutorId = null },
                // Lançamentos subdivididos
                new Categoria() { Id = 47, Nome = "Lançamento subcategorizado", Grupo = CategoriaGrupoEnum.Registro, AutorId = null }
            );

            #endregion
        }
    }

}
