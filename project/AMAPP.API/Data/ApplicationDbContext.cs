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
        public DbSet<ProdutorInfo> Produtores { get; set; }
        public DbSet<CoprodutorInfo> Coprodutores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TiposProdutos { get; set; }
        public DbSet<ProdutoCompostoProduto> ProdutoCompostoProdutos { get; set; }
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<PeriodoSubscricao> PeriodosSubscricao { get; set; }
        public DbSet<OfertaProduto> OfertasProdutos { get; set; }
        public DbSet<Subscricao> Subscricoes { get; set; }
        public DbSet<EntregaProduto> EntregasProdutos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Relacionamentos para ProdutorInfo
            modelBuilder.Entity<ProdutorInfo>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<ProdutorInfo>(p => p.UserId);

            // Relacionamentos para CoprodutorInfo
            modelBuilder.Entity<CoprodutorInfo>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<CoprodutorInfo>(c => c.UserId);

            // Configuração para Produto -> TipoProduto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.TipoProduto)
                .WithMany()
                .HasForeignKey(p => p.TipoProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para ProdutoCompostoProduto (M:N)
            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasKey(pc => new { pc.ProdutoCompostoId, pc.ProdutoId });

            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasOne(pc => pc.ProdutoComposto)
                .WithMany(p => p.ProdutoCompostoProdutos)
                .HasForeignKey(pc => pc.ProdutoCompostoId);

            modelBuilder.Entity<ProdutoCompostoProduto>()
                .HasOne(pc => pc.Produto)
                .WithMany()
                .HasForeignKey(pc => pc.ProdutoId);


            // Configuração para ContaCorrente
            modelBuilder.Entity<ContaCorrente>()
                .HasOne(c => c.Coprodutor)
                .WithOne(c => c.ContaCorrente)
                .HasForeignKey<ContaCorrente>(c => c.Id);

            // Configuração para PeriodoSubscricao -> OfertaProduto
            modelBuilder.Entity<OfertaProduto>()
                .HasOne(o => o.PeriodoSubscricao)
                .WithMany(p => p.OfertasProdutos)
                .HasForeignKey(o => o.PeriodoSubscricaoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Subscricao -> Coprodutor
            modelBuilder.Entity<Subscricao>()
                .HasOne(s => s.Coprodutor)
                .WithMany()
                .HasForeignKey(s => s.CoprodutorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Subscricao -> OfertaProduto
            modelBuilder.Entity<Subscricao>()
                .HasOne(s => s.OfertaProduto)
                .WithMany()
                .HasForeignKey(s => s.OfertaProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para ProdutoSelecionado
            modelBuilder.Entity<ProdutoSelecionado>()
                .HasOne(ps => ps.Produto)
                .WithMany()
                .HasForeignKey(ps => ps.ProdutoId);

            modelBuilder.Entity<ProdutoSelecionado>()
                .HasOne(ps => ps.Subscricao)
                .WithMany(s => s.ProdutosSelecionados)
                .HasForeignKey(ps => ps.SubscricaoId);

            // Configuração para EntregaProduto
            modelBuilder.Entity<EntregaProduto>()
                .HasOne(e => e.Produto)
                .WithMany()
                .HasForeignKey(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EntregaProduto>()
                .HasOne(e => e.Subscricao)
                .WithMany()
                .HasForeignKey(e => e.SubscricaoId)
                .OnDelete(DeleteBehavior.Cascade);



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
