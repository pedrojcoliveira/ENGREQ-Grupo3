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
        public DbSet<DeliveryDate> DeliveryDates { get; set; }
        public DbSet<SelectedProductOffer> SelectedProductOffers { get; set; }
        public DbSet<SelectedDeliveryDate> SelectedDeliveryDates { get; set; }
        public DbSet<Payment> SubscriptionPayments { get; set; }
        public DbSet<ProductOfferPaymentMethod> ProductOfferPaymentMethod { get; set; }
        public DbSet<ProductOfferPaymentMode> ProductOfferPaymentMode { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            #region PRODUCER INFO
            // Relacionamentos para ProducerInfo
            modelBuilder.Entity<ProducerInfo>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<ProducerInfo>(p => p.UserId);

            #endregion

            #region COPRODUCER INFO
            // Relacionamentos para CoproducerInfo
            modelBuilder.Entity<CoproducerInfo>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<CoproducerInfo>(c => c.UserId);
            #endregion

            #region PRODUCT
            modelBuilder.Entity<Product>()
                .Property(p => p.Photo)
                .HasColumnType("BYTEA") // Map to BYTEA column in PostgreSQL
                .IsRequired(false);     // Mark as optional

            // Configure one-to-many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProducerInfo)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.ProducerInfoId)
                .OnDelete(DeleteBehavior.SetNull);
    
            // Configuração para Produto -> TipoProduto
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region COMPOUNDPRODUCT
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
            #endregion

            #region SUBSCRIPTION PERIOD
            modelBuilder.Entity<SubscriptionPeriod>()
                .HasMany(sp => sp.DeliveryDates)
                .WithOne()
                .HasForeignKey(ps => ps.SubscriptionPeriodId).IsRequired();
            #endregion

            #region PRODUCT OFFER

            // One-to-many relationship between ProductOffer and Product
            modelBuilder.Entity<ProductOffer>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOffers)
                .HasForeignKey(po => po.ProductId);

            // One-to-many relationship between ProductOffer and SubscriptionPeriod
            modelBuilder.Entity<ProductOffer>()
                .HasOne(po => po.SubscriptionPeriod)
                .WithMany(sp => sp.ProductOffers)
                .HasForeignKey(po => po.SubscriptionPeriodId);

            #endregion

            #region SELECT DELIVERY DATE

            // One-to-many relationship between DeliveryDate and SelectDeliveryDate
            modelBuilder.Entity<SelectedDeliveryDate>()
                .HasKey(sdd => new { sdd.DeliveryDateId, sdd.ProductOfferId });

            modelBuilder.Entity<SelectedDeliveryDate>()
                .HasOne(sdd => sdd.DeliveryDate)
                .WithMany(dd => dd.SelectDeliveryDates)
                .HasForeignKey(sdd => sdd.DeliveryDateId);

            // Configuração para ProdutoOferta -> SelectedDeliveryDate
            modelBuilder.Entity<SelectedDeliveryDate>()
                .HasOne(sdd => sdd.ProductOffer)
                .WithMany(po => po.SelectedDeliveryDates)
                .HasForeignKey(sdd => sdd.ProductOfferId);

            #endregion

            #region PRODUCT OFFER PAYMENT METHOD

            // One-to-many relationship between ProductOffer and PaymentMethod (via ProductOfferPaymentMethods)
            modelBuilder.Entity<ProductOfferPaymentMethod>()
                .HasKey(popm => new { popm.ProductOfferId, popm.PaymentMethod });

            modelBuilder.Entity<ProductOfferPaymentMethod>()
                .HasOne(popm => popm.ProductOffer)
                .WithMany(po => po.ProductOfferPaymentMethods)
                .HasForeignKey(popm => popm.ProductOfferId);

            #endregion

            #region PRODUCT OFFER PAYMENT MODE

            // One-to-many relationship between ProductOffer and PaymentMode (via ProductOfferPaymentModes)
            modelBuilder.Entity<ProductOfferPaymentMode>()
                .HasKey(popm => new { popm.ProductOfferId, popm.PaymentMode });

            modelBuilder.Entity<ProductOfferPaymentMode>()
                .HasOne(popm => popm.ProductOffer)
                .WithMany(po => po.ProductOfferPaymentModes)
                .HasForeignKey(popm => popm.ProductOfferId);

            #endregion

            #region SUBSCRIPTION
            // Relationship between Subscription and CoproducerInfo
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.CoproducerInfo)
                .WithMany(ci => ci.Subscriptions)
                .HasForeignKey(s => s.CoproducerInfoId);

            // Relationship between Subscription and SubscriptionPeriod
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.SubscriptionPeriod)
                .WithMany(sp => sp.Subscriptions)
                .HasForeignKey(s => s.SubscriptionPeriodId);
            #endregion

            #region SELECTED PRODUCT OFFER

            // One-to-many relationship between SelectedProductOffer and Subscription
            modelBuilder.Entity<SelectedProductOffer>()
                .HasOne(spo => spo.Subscription)
                .WithMany(s => s.SelectedProductOffers)
                .HasForeignKey(spo => spo.SubscriptionId);

            // One-to-many relationship between SelectedProductOffer and ProductOffer
            modelBuilder.Entity<SelectedProductOffer>()
                .HasOne(spo => spo.ProductOffer)
                .WithMany(po => po.SelectedProductOffers)
                .HasForeignKey(spo => spo.ProductOfferId);

            #endregion

            #region SELECTED PRODUCT OFFER DELIVERY

            // Relationship between SelectedProductOffer and SelectedProductOfferDelivery
            modelBuilder.Entity<SelectedProductOfferDelivery>()
                .HasOne(spod => spod.SelectedProductOffer)
                .WithMany(spo => spo.SelectedProductOfferDeliveries)
                .HasForeignKey(spod => spod.SelectedProductOfferId);

            #endregion

            #region PAYMENT

            // Relationship between Payment and SelectedProductOffer
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.SelectedProductOffer)
                .WithMany(spo => spo.Payments)
                .HasForeignKey(p => p.SelectedProductOfferId);

            #endregion

            #region CHECKING ACCOUNT
            // Configuração para ContaCorrente
            modelBuilder.Entity<CheckingAccount>()
                .HasOne(c => c.Coproducer)
                .WithOne(c => c.CheckingAccount)
                .HasForeignKey<CheckingAccount>(c => c.Id);
            #endregion



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
