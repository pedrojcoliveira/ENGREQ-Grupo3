﻿// <auto-generated />
using System;
using AMAPP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AMAPP.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250111125103_PaymentsComposeKey")]
    partial class PaymentsComposeKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AMAPP.API.Models.CheckingAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<int>("ResourceStatus")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionPeriodId");

                    b.ToTable("DeliveryDates");
                });

            modelBuilder.Entity("AMAPP.API.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("integer");

                    b.Property<int?>("SelectedProductOfferDeliveryId")
                        .HasColumnType("integer");

                    b.Property<int>("SelectedProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SelectedProductOfferDeliveryId");

                    b.HasIndex("SelectedProductOfferId");

                    b.ToTable("SubscriptionPayments");
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

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SubscriptionPeriodId");

                    b.ToTable("ProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOfferPaymentMethod", b =>
                {
                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.HasKey("ProductOfferId", "PaymentMethod");

                    b.ToTable("ProductOfferPaymentMethod");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOfferPaymentMode", b =>
                {
                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("integer");

                    b.HasKey("ProductOfferId", "PaymentMode");

                    b.ToTable("ProductOfferPaymentMode");
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
                    b.Property<int>("DeliveryDateId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.HasKey("DeliveryDateId", "ProductOfferId");

                    b.HasIndex("ProductOfferId");

                    b.ToTable("SelectedDeliveryDates");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductOfferId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductOfferId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SelectedProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOfferDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DeliveredAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeliveryDateId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SelectedProductOfferId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SelectedProductOfferId");

                    b.ToTable("SelectedProductOfferDelivery");
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

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResourceStatus")
                        .HasColumnType("integer");

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
                            Id = "55bad5d2-b442-4b57-8a3c-6d1f238591a2",
                            Name = "Administrator",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "ec902aa0-c5b6-43e7-84e7-4d46feb1f0b4",
                            Name = "Amap",
                            NormalizedName = "AMAP"
                        },
                        new
                        {
                            Id = "131ceb02-2ba1-499a-abb6-41ffe28561f1",
                            Name = "Producer",
                            NormalizedName = "PROD"
                        },
                        new
                        {
                            Id = "4d7bfd7c-49d8-4306-b1d3-b57ca62f3f07",
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

            modelBuilder.Entity("AMAPP.API.Models.Payment", b =>
                {
                    b.HasOne("AMAPP.API.Models.SelectedProductOfferDelivery", "SelectedProductOfferDelivery")
                        .WithMany()
                        .HasForeignKey("SelectedProductOfferDeliveryId");

                    b.HasOne("AMAPP.API.Models.SelectedProductOffer", "SelectedProductOffer")
                        .WithMany("Payments")
                        .HasForeignKey("SelectedProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectedProductOffer");

                    b.Navigation("SelectedProductOfferDelivery");
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
                        .OnDelete(DeleteBehavior.SetNull)
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
                    b.HasOne("AMAPP.API.Models.Product", "Product")
                        .WithMany("ProductOffers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", "SubscriptionPeriod")
                        .WithMany("ProductOffers")
                        .HasForeignKey("SubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SubscriptionPeriod");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOfferPaymentMethod", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany("ProductOfferPaymentMethods")
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProductOfferPaymentMode", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany("ProductOfferPaymentModes")
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedDeliveryDate", b =>
                {
                    b.HasOne("AMAPP.API.Models.DeliveryDate", "DeliveryDate")
                        .WithMany("SelectDeliveryDates")
                        .HasForeignKey("DeliveryDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany("SelectedDeliveryDates")
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryDate");

                    b.Navigation("ProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.HasOne("AMAPP.API.Models.ProductOffer", "ProductOffer")
                        .WithMany("SelectedProductOffers")
                        .HasForeignKey("ProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Subscription", "Subscription")
                        .WithMany("SelectedProductOffers")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductOffer");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOfferDelivery", b =>
                {
                    b.HasOne("AMAPP.API.Models.SelectedProductOffer", "SelectedProductOffer")
                        .WithMany("SelectedProductOfferDeliveries")
                        .HasForeignKey("SelectedProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectedProductOffer");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscription", b =>
                {
                    b.HasOne("AMAPP.API.Models.CoproducerInfo", "CoproducerInfo")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CoproducerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.SubscriptionPeriod", "SubscriptionPeriod")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriptionPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoproducerInfo");

                    b.Navigation("SubscriptionPeriod");
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

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("AMAPP.API.Models.DeliveryDate", b =>
                {
                    b.Navigation("SelectDeliveryDates");
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
                    b.Navigation("ProductOfferPaymentMethods");

                    b.Navigation("ProductOfferPaymentModes");

                    b.Navigation("SelectedDeliveryDates");

                    b.Navigation("SelectedProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.SelectedProductOffer", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("SelectedProductOfferDeliveries");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscription", b =>
                {
                    b.Navigation("SelectedProductOffers");
                });

            modelBuilder.Entity("AMAPP.API.Models.SubscriptionPeriod", b =>
                {
                    b.Navigation("DeliveryDates");

                    b.Navigation("ProductOffers");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
