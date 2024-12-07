﻿// <auto-generated />
using System;
using AMAPP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AMAPP.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AMAPP.API.Models.CheckingAccount", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("CheckingAccounts");
                });

            modelBuilder.Entity("AMAPP.API.Models.CompoundProductProduct", b =>
                {
                    b.Property<int>("CompoundProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("CompoundProductId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CompoundProductProducts");
                });

            modelBuilder.Entity("AMAPP.API.Models.CoproducerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CoproducersInfo");
                });

            modelBuilder.Entity("AMAPP.API.Models.DeliveryDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SubscriptionPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionPeriodId");

                    b.ToTable("DeliveryDates");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProducerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProducersInfo");
                });

            modelBuilder.Entity("AMAPP.API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DeliveryUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BYTEA");

                    b.Property<int>("ProducerInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<double>("ReferencePrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProducerInfoId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("integer");

                    b.Property<int>("PeriodSubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PeriodSubscriptionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Produto individual sem composição",
                            Name = "Simples"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Produto composto por outros produtos",
                            Name = "Composto"
                        });
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedDeliveryDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductOfferId");

                    b.ToTable("SelectedDeliveryDates");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductOfferId");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("SubscriptionPeriodId");

                    b.ToTable("SelectedProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoproducerInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoproducerInfoId");

                    b.HasIndex("SubscriptionPeriodId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer");

                    b.Property<int>("SelectedProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SelectedProductOfferId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionPayment");
                });

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionPeriods");
                });

            modelBuilder.Entity("AMAPP.API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "adaf4bdf-a200-4234-8098-00e4e08cd5e3",
                            Name = "Administrator",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "348dabb3-fcf9-486f-af86-3e7a2e84d2d1",
                            Name = "Amap",
                            NormalizedName = "AMAP"
                        },
                        new
                        {
                            Id = "1a7a70df-7eaa-4780-a378-b87c76e9b62b",
                            Name = "Producer",
                            NormalizedName = "PROD"
                        },
                        new
                        {
                            Id = "41690b65-2745-4874-aa1e-4cb2cfe508af",
                            Name = "CoProducer",
                            NormalizedName = "COPR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AMAPP.API.Models.CheckingAccount", b =>
                {
                    b.HasOne("AMAPP.API.Models.CoproducerInfo", "Coproducer")
                        .WithOne("CheckingAccount")
                        .HasForeignKey("AMAPP.API.Models.CheckingAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coproducer");
                });

            modelBuilder.Entity("AMAPP.API.Models.CompoundProductProduct", b =>
                {
                    b.HasOne("AMAPP.API.Models.Product", "CompoundProduct")
                        .WithMany("CompoundProductProduct")
                        .HasForeignKey("CompoundProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompoundProduct");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AMAPP.API.Models.CoproducerInfo", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("AMAPP.API.Models.CoproducerInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AMAPP.API.Models.DeliveryDate", b =>
                {
                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", null)
                        .WithMany("DeliveryDates")
                        .HasForeignKey("SubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AMAPP.API.Models.ProducerInfo", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("AMAPP.API.Models.ProducerInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AMAPP.API.Models.Product", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProducerInfo", "ProducerInfo")
                        .WithMany("Products")
                        .HasForeignKey("ProducerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProducerInfo");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOffer", b =>
                {
                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", "PeriodSubscription")
                        .WithMany("ProductOffers")
                        .HasForeignKey("PeriodSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Product", "Product")
                        .WithMany("ProductOffers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeriodSubscription");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedDeliveryDate", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany("SelectedDeliveryDates")
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany()
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Subscription", "Subscription")
                        .WithMany("SelectedProducts")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", null)
                        .WithMany("SelectedProductOffers")
                        .HasForeignKey("SubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOffer");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscription", b =>
                {
                    b.HasOne("AMAPP.API.Models.CoproducerInfo", "CoproducerInfo")
                        .WithMany()
                        .HasForeignKey("CoproducerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", "SubscriptionPeriod")
                        .WithMany()
                        .HasForeignKey("SubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoproducerInfo");

                    b.Navigation("SubscriptionPeriod");
                });

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPayment", b =>
                {
                    b.HasOne("AMAPP.API.Models.SelectedProductOffer", "SelectedProductOffer")
                        .WithMany("SubscriptionPayments")
                        .HasForeignKey("SelectedProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Subscription", "Subscription")
                        .WithMany("SubscriptionPayments")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectedProductOffer");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AMAPP.API.Models.CoproducerInfo", b =>
                {
                    b.Navigation("CheckingAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("AMAPP.API.Models.ProducerInfo", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AMAPP.API.Models.Product", b =>
                {
                    b.Navigation("CompoundProductProduct");

                    b.Navigation("ProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOffer", b =>
                {
                    b.Navigation("SelectedDeliveryDates");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.Navigation("SubscriptionPayments");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscription", b =>
                {
                    b.Navigation("SelectedProducts");

                    b.Navigation("SubscriptionPayments");
                });

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPeriod", b =>
                {
                    b.Navigation("DeliveryDates");

                    b.Navigation("ProductOffers");

                    b.Navigation("SelectedProductOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
