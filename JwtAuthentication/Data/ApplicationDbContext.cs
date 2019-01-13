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

            #endregion
        }
    }

}
