using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_Construsys.Models;
using ApiServico.Models;

namespace api_Construsys.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Construcao> Construcoes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<MaoDeObra> Mao_De_Obras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConstrucaoMaterial> ConstrucaoMateriais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConstrucaoMaterial>()
                .HasKey(cm => new { cm.IdConstrucao, cm.IdMaterial });


            modelBuilder.Entity<ConstrucaoMaterial>()
                .HasOne(cm => cm.Construcao)
                .WithMany(c => c.ConstrucaoMateriais)
                .HasForeignKey(cm => cm.IdConstrucao);

            modelBuilder.Entity<ConstrucaoMaterial>()
                .HasOne(cm => cm.Material)
                .WithMany(m => m.ConstrucaoMateriais)
                .HasForeignKey(cm => cm.IdMaterial);
        }

    }

}

