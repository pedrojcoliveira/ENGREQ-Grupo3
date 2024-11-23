﻿// <auto-generated />
using System;
using System.Collections.Generic;
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

            modelBuilder.Entity("AMAPP.API.Models.ContaCorrente", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Saldo")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ContasCorrentes");
                });

            modelBuilder.Entity("AMAPP.API.Models.CoprodutorInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Coprodutores");
                });

            modelBuilder.Entity("AMAPP.API.Models.EntregaProduto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeEntregue")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeSubscrita")
                        .HasColumnType("integer");

                    b.Property<long>("SubscricaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SubscricaoId");

                    b.ToTable("EntregasProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.OfertaProduto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<DateTime>>("DatasEntrega")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone[]");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("integer");

                    b.Property<long>("PeriodoSubscricaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PeriodoSubscricaoId");

                    b.ToTable("OfertasProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.PeriodoSubscricao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<List<DateTime>>("DatasEntregas")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone[]");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PeriodosSubscricao");
                });

            modelBuilder.Entity("AMAPP.API.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DescricaoBreve")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fotografia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("OfertaProdutoId")
                        .HasColumnType("bigint");

                    b.Property<double>("PrecoReferencia")
                        .HasColumnType("double precision");

                    b.Property<long?>("ProdutorInfoId")
                        .HasColumnType("bigint");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("UnidadesEntrega")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OfertaProdutoId");

                    b.HasIndex("ProdutorInfoId");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutoCompostoProduto", b =>
                {
                    b.Property<long>("ProdutoCompostoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.HasKey("ProdutoCompostoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoCompostoProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutoSelecionado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<long>("SubscricaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SubscricaoId");

                    b.ToTable("ProdutoSelecionado");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutorInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Produtores");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscricao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CoprodutorId")
                        .HasColumnType("bigint");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("integer");

                    b.Property<long>("OfertaProdutoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CoprodutorId");

                    b.HasIndex("OfertaProdutoId");

                    b.ToTable("Subscricoes");
                });

            modelBuilder.Entity("AMAPP.API.Models.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TiposProdutos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Produto individual sem composição",
                            Nome = "Simples"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Produto composto por outros produtos",
                            Nome = "Composto"
                        });
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
                            Id = "5c3c12f1-d9a5-4b9f-9362-26d5ffdc9710",
                            Name = "Administrator",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3b9271ec-4436-4db5-9cb6-f92e1e609890",
                            Name = "Amap",
                            NormalizedName = "AMAP"
                        },
                        new
                        {
                            Id = "c7a8a05f-68a1-4458-a788-7f6bd758531f",
                            Name = "Producer",
                            NormalizedName = "PROD"
                        },
                        new
                        {
                            Id = "021a6da2-4710-4fa2-b25b-fd6f000c01ed",
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

            modelBuilder.Entity("AMAPP.API.Models.ContaCorrente", b =>
                {
                    b.HasOne("AMAPP.API.Models.CoprodutorInfo", "Coprodutor")
                        .WithOne("ContaCorrente")
                        .HasForeignKey("AMAPP.API.Models.ContaCorrente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coprodutor");
                });

            modelBuilder.Entity("AMAPP.API.Models.CoprodutorInfo", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("AMAPP.API.Models.CoprodutorInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AMAPP.API.Models.EntregaProduto", b =>
                {
                    b.HasOne("AMAPP.API.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Subscricao", "Subscricao")
                        .WithMany()
                        .HasForeignKey("SubscricaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Subscricao");
                });

            modelBuilder.Entity("AMAPP.API.Models.OfertaProduto", b =>
                {
                    b.HasOne("AMAPP.API.Models.PeriodoSubscricao", "PeriodoSubscricao")
                        .WithMany("OfertasProdutos")
                        .HasForeignKey("PeriodoSubscricaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeriodoSubscricao");
                });

            modelBuilder.Entity("AMAPP.API.Models.Produto", b =>
                {
                    b.HasOne("AMAPP.API.Models.OfertaProduto", null)
                        .WithMany("Produtos")
                        .HasForeignKey("OfertaProdutoId");

                    b.HasOne("AMAPP.API.Models.ProdutorInfo", null)
                        .WithMany("CatalogoProdutos")
                        .HasForeignKey("ProdutorInfoId");

                    b.HasOne("AMAPP.API.Models.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutoCompostoProduto", b =>
                {
                    b.HasOne("AMAPP.API.Models.Produto", "ProdutoComposto")
                        .WithMany("ProdutoCompostoProdutos")
                        .HasForeignKey("ProdutoCompostoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("ProdutoComposto");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutoSelecionado", b =>
                {
                    b.HasOne("AMAPP.API.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.Subscricao", "Subscricao")
                        .WithMany("ProdutosSelecionados")
                        .HasForeignKey("SubscricaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Subscricao");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutorInfo", b =>
                {
                    b.HasOne("AMAPP.API.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("AMAPP.API.Models.ProdutorInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscricao", b =>
                {
                    b.HasOne("AMAPP.API.Models.CoprodutorInfo", "Coprodutor")
                        .WithMany()
                        .HasForeignKey("CoprodutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMAPP.API.Models.OfertaProduto", "OfertaProduto")
                        .WithMany()
                        .HasForeignKey("OfertaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coprodutor");

                    b.Navigation("OfertaProduto");
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

            modelBuilder.Entity("AMAPP.API.Models.CoprodutorInfo", b =>
                {
                    b.Navigation("ContaCorrente")
                        .IsRequired();
                });

            modelBuilder.Entity("AMAPP.API.Models.OfertaProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("AMAPP.API.Models.PeriodoSubscricao", b =>
                {
                    b.Navigation("OfertasProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.Produto", b =>
                {
                    b.Navigation("ProdutoCompostoProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.ProdutorInfo", b =>
                {
                    b.Navigation("CatalogoProdutos");
                });

            modelBuilder.Entity("AMAPP.API.Models.Subscricao", b =>
                {
                    b.Navigation("ProdutosSelecionados");
                });
#pragma warning restore 612, 618
        }
    }
}
