using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class Payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010da128-a5a2-4c75-bf6b-1e22ab7fa5cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a56c8c9c-413b-4d27-b13a-b75a6b732b48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddbc04c3-858f-47f7-892f-80c5471c85b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffdea180-7651-450f-9661-b42bf5c6db99");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "ProductOffers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMode",
                table: "ProductOffers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a7a70df-7eaa-4780-a378-b87c76e9b62b", null, "Producer", "PROD" },
                    { "348dabb3-fcf9-486f-af86-3e7a2e84d2d1", null, "Amap", "AMAP" },
                    { "41690b65-2745-4874-aa1e-4cb2cfe508af", null, "CoProducer", "COPR" },
                    { "adaf4bdf-a200-4234-8098-00e4e08cd5e3", null, "Administrator", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7a70df-7eaa-4780-a378-b87c76e9b62b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348dabb3-fcf9-486f-af86-3e7a2e84d2d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41690b65-2745-4874-aa1e-4cb2cfe508af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adaf4bdf-a200-4234-8098-00e4e08cd5e3");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "ProductOffers");

            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "ProductOffers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "010da128-a5a2-4c75-bf6b-1e22ab7fa5cc", null, "Administrator", "ADMIN" },
                    { "a56c8c9c-413b-4d27-b13a-b75a6b732b48", null, "Producer", "PROD" },
                    { "ddbc04c3-858f-47f7-892f-80c5471c85b5", null, "CoProducer", "COPR" },
                    { "ffdea180-7651-450f-9661-b42bf5c6db99", null, "Amap", "AMAP" }
                });
        }
    }
}
