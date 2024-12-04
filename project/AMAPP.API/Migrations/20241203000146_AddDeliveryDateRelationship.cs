using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryDateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343dfab0-5e0d-4106-96fc-071100f5a1ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d4e4dab-7904-4e2d-a29f-8b47bf8eb07d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5cff79f-7ade-4256-9817-5932a60bba46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2d556b3-d904-4545-a935-d041c750b99d");

            migrationBuilder.CreateTable(
                name: "DeliveryDateBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SubscriptionPeriodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDateBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDateBase_SubscriptionPeriods_SubscriptionPeriodId",
                        column: x => x.SubscriptionPeriodId,
                        principalTable: "SubscriptionPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDateBase_SubscriptionPeriodId",
                table: "DeliveryDateBase",
                column: "SubscriptionPeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryDateBase");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "343dfab0-5e0d-4106-96fc-071100f5a1ba", null, "CoProducer", "COPR" },
                    { "9d4e4dab-7904-4e2d-a29f-8b47bf8eb07d", null, "Producer", "PROD" },
                    { "c5cff79f-7ade-4256-9817-5932a60bba46", null, "Amap", "AMAP" },
                    { "e2d556b3-d904-4545-a935-d041c750b99d", null, "Administrator", "ADMIN" }
                });
        }
    }
}
