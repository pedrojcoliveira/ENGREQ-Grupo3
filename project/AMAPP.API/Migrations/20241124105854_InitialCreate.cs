using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosSubscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeliveryDates = table.Column<List<DateTime>>(type: "timestamp without time zone[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosSubscricao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coprodutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coprodutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coprodutores_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtores_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertasProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodSubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDates = table.Column<List<DateTime>>(type: "timestamp without time zone[]", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertasProdutos_PeriodosSubscricao_PeriodSubscriptionId",
                        column: x => x.PeriodSubscriptionId,
                        principalTable: "PeriodosSubscricao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Coprodutores_Id",
                        column: x => x.Id,
                        principalTable: "Coprodutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    ReferencePrice = table.Column<double>(type: "double precision", nullable: false),
                    DeliveryUnit = table.Column<string>(type: "text", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProducerInfoId = table.Column<int>(type: "integer", nullable: true),
                    ProductOfferId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_OfertasProdutos_ProductOfferId",
                        column: x => x.ProductOfferId,
                        principalTable: "OfertasProdutos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_Produtores_ProducerInfoId",
                        column: x => x.ProducerInfoId,
                        principalTable: "Produtores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_TiposProdutos_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "TiposProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscricoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoproducerId = table.Column<int>(type: "integer", nullable: false),
                    ProductOfferId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscricoes_Coprodutores_CoproducerId",
                        column: x => x.CoproducerId,
                        principalTable: "Coprodutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscricoes_OfertasProdutos_ProductOfferId",
                        column: x => x.ProductOfferId,
                        principalTable: "OfertasProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoCompostoProdutos",
                columns: table => new
                {
                    CompoundProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCompostoProdutos", x => new { x.CompoundProductId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProdutoCompostoProdutos_Produtos_CompoundProductId",
                        column: x => x.CompoundProductId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoCompostoProdutos_Produtos_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntregasProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    QuantitySubscribed = table.Column<int>(type: "integer", nullable: false),
                    QuantityDelivered = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregasProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntregasProdutos_Produtos_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntregasProdutos_Subscricoes_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscricoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedProduct_Produtos_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedProduct_Subscricoes_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscricoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bf957b4-29d7-4b71-a906-dfadff9543f0", null, "Producer", "PROD" },
                    { "41b034d7-c952-4af6-bbe0-a25679384d16", null, "Amap", "AMAP" },
                    { "7f06f7ec-5faf-4010-b14e-e39dd9755664", null, "Administrator", "ADMIN" },
                    { "9fdcc702-c92d-43fc-8243-fa1729630b7d", null, "CoProducer", "COPR" }
                });

            migrationBuilder.InsertData(
                table: "TiposProdutos",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Produto individual sem composição", "Simples" },
                    { 2, "Produto composto por outros produtos", "Composto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coprodutores_UserId",
                table: "Coprodutores",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntregasProdutos_ProductId",
                table: "EntregasProdutos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregasProdutos_SubscriptionId",
                table: "EntregasProdutos",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasProdutos_PeriodSubscriptionId",
                table: "OfertasProdutos",
                column: "PeriodSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCompostoProdutos_ProductId",
                table: "ProdutoCompostoProdutos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtores_UserId",
                table: "Produtores",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProducerInfoId",
                table: "Produtos",
                column: "ProducerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProductOfferId",
                table: "Produtos",
                column: "ProductOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProductTypeId",
                table: "Produtos",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProduct_ProductId",
                table: "SelectedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProduct_SubscriptionId",
                table: "SelectedProduct",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscricoes_CoproducerId",
                table: "Subscricoes",
                column: "CoproducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscricoes_ProductOfferId",
                table: "Subscricoes",
                column: "ProductOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");

            migrationBuilder.DropTable(
                name: "EntregasProdutos");

            migrationBuilder.DropTable(
                name: "ProdutoCompostoProdutos");

            migrationBuilder.DropTable(
                name: "SelectedProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Subscricoes");

            migrationBuilder.DropTable(
                name: "Produtores");

            migrationBuilder.DropTable(
                name: "TiposProdutos");

            migrationBuilder.DropTable(
                name: "Coprodutores");

            migrationBuilder.DropTable(
                name: "OfertasProdutos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PeriodosSubscricao");
        }
    }
}
