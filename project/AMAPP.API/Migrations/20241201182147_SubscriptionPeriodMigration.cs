using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionPeriodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36f73c3f-24a9-4f2d-925f-c0748990e6df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3741b316-eeff-4755-b6fa-124c47bdb617");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81352cc0-a70f-421f-a3e7-91a63f86ef15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "979f3b02-6149-4fff-b2d4-d1294a658325");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36f73c3f-24a9-4f2d-925f-c0748990e6df", null, "Producer", "PROD" },
                    { "3741b316-eeff-4755-b6fa-124c47bdb617", null, "CoProducer", "COPR" },
                    { "81352cc0-a70f-421f-a3e7-91a63f86ef15", null, "Administrator", "ADMIN" },
                    { "979f3b02-6149-4fff-b2d4-d1294a658325", null, "Amap", "AMAP" }
                });
        }
    }
}
