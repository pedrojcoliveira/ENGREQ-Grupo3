using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fea21ef-6dbb-4992-b393-23076ab274a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d5f4ed-5863-49e5-a27e-5ce172673bdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa96e97c-046a-4bc5-be43-69de72230d8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9a0507-f8e5-4e4b-8bf8-7e8d5a5dfba0");

            migrationBuilder.CreateTable(
                name: "SubscriptionPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    SelectedProductOfferId = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPayment_SelectedProductOffer_SelectedProductOff~",
                        column: x => x.SelectedProductOfferId,
                        principalTable: "SelectedProductOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionPayment_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b0258a8-5972-4509-9db9-710fec76e2b8", null, "CoProducer", "COPR" },
                    { "3f43205d-b6fc-4ad2-a485-8f341805009b", null, "Administrator", "ADMIN" },
                    { "dfadb40a-ddd4-4658-ba2b-6dbb7f369643", null, "Producer", "PROD" },
                    { "f2ea557a-0c43-4c2e-ab9c-9228d43697d3", null, "Amap", "AMAP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayment_SelectedProductOfferId",
                table: "SubscriptionPayment",
                column: "SelectedProductOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayment_SubscriptionId",
                table: "SubscriptionPayment",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b0258a8-5972-4509-9db9-710fec76e2b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f43205d-b6fc-4ad2-a485-8f341805009b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfadb40a-ddd4-4658-ba2b-6dbb7f369643");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2ea557a-0c43-4c2e-ab9c-9228d43697d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fea21ef-6dbb-4992-b393-23076ab274a6", null, "CoProducer", "COPR" },
                    { "a5d5f4ed-5863-49e5-a27e-5ce172673bdf", null, "Producer", "PROD" },
                    { "aa96e97c-046a-4bc5-be43-69de72230d8c", null, "Amap", "AMAP" },
                    { "ec9a0507-f8e5-4e4b-8bf8-7e8d5a5dfba0", null, "Administrator", "ADMIN" }
                });
        }
    }
}
