using AMAPP.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMAPP.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Configurar os DbSets
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoSimples> ProdutosSimples { get; set; }
        public DbSet<ProdutoComposto> ProdutosCompostos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



            // Configuração da tabela intermediária ProdutoCompostoProduto
            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasKey(pc => new { pc.ProdutoCompostoId, pc.ProdutoId });

            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasOne(pc => pc.ProdutoComposto)
                .WithMany(p => p.ProdutoCompostoProdutos)
                .HasForeignKey(pc => pc.ProdutoCompostoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.ProdutoCompostoProdutos)
                .HasForeignKey(pc => pc.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Produto -> TipoProduto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.TipoProduto)
                .WithMany()
                .HasForeignKey(p => p.TipoProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações adicionais (exemplo: comprimento de campos)
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Produto>()
                .Property(p => p.DescricaoBreve)
                .HasMaxLength(500);



            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Administrator", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Amap", NormalizedName = "AMAP" },
                new IdentityRole { Name = "Producer", NormalizedName = "PROD" },
                new IdentityRole { Name = "CoProducer", NormalizedName = "COPR" }
            );

            // Inserir dados iniciais para TipoProduto
            modelBuilder.Entity<TipoProduto>().HasData(
                new TipoProduto { Id = 1, Nome = "Simples", Descricao = "Produto individual sem composição" },
                new TipoProduto { Id = 2, Nome = "Composto", Descricao = "Produto composto por outros produtos" }
            );




        }
    }
}
