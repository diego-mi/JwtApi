﻿// <auto-generated />
using System;
using JwtAuthentication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JwtAuthentication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190315205446_updatesituacao2")]
    partial class updatesituacao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JwtAuthentication.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Thumbnail");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Categorias.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AutorId");

                    b.Property<int>("Grupo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new { Id = 1, Grupo = 0, Nome = "A Categorizar" },
                        new { Id = 2, Grupo = 1, Nome = "Aluguel" },
                        new { Id = 3, Grupo = 1, Nome = "Luz" },
                        new { Id = 4, Grupo = 1, Nome = "Água" },
                        new { Id = 5, Grupo = 1, Nome = "TV/Internet/Telefone Residêncial" },
                        new { Id = 6, Grupo = 1, Nome = "Manutenção/Melhorias" },
                        new { Id = 7, Grupo = 1, Nome = "Seguros" },
                        new { Id = 8, Grupo = 1, Nome = "Segurança" },
                        new { Id = 9, Grupo = 2, Nome = "Mercado Dispensa/Essencial" },
                        new { Id = 10, Grupo = 2, Nome = "Mercado Filhas" },
                        new { Id = 11, Grupo = 2, Nome = "Mercado não essencial" },
                        new { Id = 12, Grupo = 3, Nome = "Higiêne Geral" },
                        new { Id = 13, Grupo = 3, Nome = "Higiêne Filhas" },
                        new { Id = 14, Grupo = 3, Nome = "Plano de saúde" },
                        new { Id = 15, Grupo = 3, Nome = "Farmácia" },
                        new { Id = 16, Grupo = 3, Nome = "Farmácia Filhas" },
                        new { Id = 17, Grupo = 5, Nome = "Moto - Abastecimento" },
                        new { Id = 18, Grupo = 5, Nome = "Moto - Manutenção/Melhorias" },
                        new { Id = 19, Grupo = 5, Nome = "Uber - Essencial" },
                        new { Id = 20, Grupo = 5, Nome = "Uber - Escola Laura" },
                        new { Id = 21, Grupo = 5, Nome = "Uber - Saidinhas e Outros" },
                        new { Id = 22, Grupo = 5, Nome = "Outros" },
                        new { Id = 23, Grupo = 4, Nome = "Educação" },
                        new { Id = 24, Grupo = 6, Nome = "Lanches / Saidinhas" },
                        new { Id = 25, Grupo = 6, Nome = "Compras" },
                        new { Id = 26, Grupo = 6, Nome = "Cuidados Pessoais" },
                        new { Id = 27, Grupo = 6, Nome = "Despesas do Trabalho" },
                        new { Id = 28, Grupo = 6, Nome = "Presentes/Doações" },
                        new { Id = 29, Grupo = 7, Nome = "Pensão Mariah" },
                        new { Id = 30, Grupo = 8, Nome = "Impostos" },
                        new { Id = 31, Grupo = 8, Nome = "Multa/Juros" },
                        new { Id = 32, Grupo = 8, Nome = "Taxas Bancárias" },
                        new { Id = 33, Grupo = 8, Nome = "Cheque Especial" },
                        new { Id = 34, Grupo = 8, Nome = "Pagamento de Empréstimo" },
                        new { Id = 35, Grupo = 9, Nome = "Remuneração" },
                        new { Id = 36, Grupo = 9, Nome = "Bônus" },
                        new { Id = 37, Grupo = 9, Nome = "Rendimento" },
                        new { Id = 38, Grupo = 9, Nome = "Empréstimo" },
                        new { Id = 48, Grupo = 9, Nome = "Vale Refeição" },
                        new { Id = 39, Grupo = 9, Nome = "Outras Rendas" },
                        new { Id = 40, Grupo = 9, Nome = "Indenização - Despesa do Trabalho" },
                        new { Id = 42, Grupo = 10, Nome = "Saque" },
                        new { Id = 43, Grupo = 10, Nome = "Aplicação" },
                        new { Id = 44, Grupo = 10, Nome = "Resgate" },
                        new { Id = 45, Grupo = 10, Nome = "Transfência" },
                        new { Id = 46, Grupo = 10, Nome = "Pagamento de cartão" },
                        new { Id = 47, Grupo = 11, Nome = "Lançamento subcategorizado" }
                    );
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Lancamentos.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AutorId");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime?>("Data")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .HasMaxLength(200);

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Tipo");

                    b.Property<int>("TipoMovimentacao");

                    b.Property<int>("TipoOperacao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Lancamentos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Lancamento");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Planejamentos.Planejamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AutorId")
                        .IsRequired();

                    b.Property<int>("CategoriaId");

                    b.Property<int>("TipoMovimentacao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Planejamentos");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Tagueamentos.Tagueamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tagueamentos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Lancamentos.SubLancamento", b =>
                {
                    b.HasBaseType("JwtAuthentication.Entities.Lancamentos.Lancamento");

                    b.Property<int?>("LancamentoId");

                    b.Property<int>("LancamentoPaiId");

                    b.HasIndex("LancamentoId");

                    b.ToTable("Lancamentos");

                    b.HasDiscriminator().HasValue("SubLancamento");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Categorias.Categoria", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId");
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Lancamentos.Lancamento", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId");

                    b.HasOne("JwtAuthentication.Entities.Categorias.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Planejamentos.Planejamento", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JwtAuthentication.Entities.Categorias.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Tagueamentos.Tagueamento", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.Categorias.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JwtAuthentication.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JwtAuthentication.Entities.Lancamentos.SubLancamento", b =>
                {
                    b.HasOne("JwtAuthentication.Entities.Lancamentos.Lancamento", "Lancamento")
                        .WithMany()
                        .HasForeignKey("LancamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
