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
        public DbSet<ProducerInfo> ProducersInfo { get; set; }
        public DbSet<CoproducerInfo> CoproducersInfo { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<CompoundProductProduct> CompoundProductProducts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
        public DbSet<ProductOffer> ProductOffers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductDelivery> ProductsDelivery { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Relacionamentos para ProdutorInfo
            modelBuilder.Entity<ProducerInfo>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<ProducerInfo>(p => p.UserId);

            // Relacionamentos para CoprodutorInfo
            modelBuilder.Entity<CoproducerInfo>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<CoproducerInfo>(c => c.UserId);


            // Configure one-to-many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProducerInfo)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.ProducerInfoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Produto -> TipoProduto
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para ProdutoCompostoProduto (M:N)
            modelBuilder.Entity<CompoundProductProduct>()
                .HasKey(pc => new { pc.CompoundProductId, pc.ProductId });

            modelBuilder.Entity<CompoundProductProduct>()
                .HasOne(pc => pc.CompoundProduct)
                .WithMany(p => p.CompoundProductProduct)
                .HasForeignKey(pc => pc.CompoundProductId);

            modelBuilder.Entity<CompoundProductProduct>()
                .HasOne(pc => pc.Product)
                .WithMany()
                .HasForeignKey(pc => pc.ProductId);


            // Configuração para ContaCorrente
            modelBuilder.Entity<CheckingAccount>()
                .HasOne(c => c.Coproducer)
                .WithOne(c => c.CheckingAccount)
                .HasForeignKey<CheckingAccount>(c => c.Id);

            // Configuração para PeriodoSubscricao -> OfertaProduto
            modelBuilder.Entity<ProductOffer>()
                .HasOne(o => o.PeriodSubscription)
                .WithMany(p => p.ProductOffers)
                .HasForeignKey(o => o.PeriodSubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Subscricao -> Coprodutor
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Coproducer)
                .WithMany()
                .HasForeignKey(s => s.CoproducerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Subscricao -> OfertaProduto
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.ProductOffer)
                .WithMany()
                .HasForeignKey(s => s.ProductOfferId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para ProdutoSelecionado
            modelBuilder.Entity<SelectedProduct>()
                .HasOne(ps => ps.Product)
                .WithMany()
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<SelectedProduct>()
                .HasOne(ps => ps.Subscription)
                .WithMany(s => s.SelectedProducts)
                .HasForeignKey(ps => ps.SubscriptionId);

            // Configuração para EntregaProduto
            modelBuilder.Entity<ProductDelivery>()
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductDelivery>()
                .HasOne(e => e.Subscription)
                .WithMany()
                .HasForeignKey(e => e.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Administrator", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Amap", NormalizedName = "AMAP" },
                new IdentityRole { Name = "Producer", NormalizedName = "PROD" },
                new IdentityRole { Name = "CoProducer", NormalizedName = "COPR" }
            );

            // Inserir dados iniciais para TipoProduto
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Simples", Description = "Produto individual sem composição" },
                new ProductType { Id = 2, Name = "Composto", Description = "Produto composto por outros produtos" }
            );




        }
    }
}
