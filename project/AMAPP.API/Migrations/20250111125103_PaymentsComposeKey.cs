using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsComposeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOfferPaymentMode",
                table: "ProductOfferPaymentMode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOfferPaymentMethod",
                table: "ProductOfferPaymentMethod");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18f253db-afe9-4695-8932-5f694282c1b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39cb0c53-a2a6-4940-b73a-f88395e957e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "675a270c-a771-4ff0-a5ae-6ac83850d79b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b2145d-7c7d-485e-a4ba-8e7ad3eecabe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOfferPaymentMode",
                table: "ProductOfferPaymentMode",
                columns: new[] { "ProductOfferId", "PaymentMode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOfferPaymentMethod",
                table: "ProductOfferPaymentMethod",
                columns: new[] { "ProductOfferId", "PaymentMethod" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "131ceb02-2ba1-499a-abb6-41ffe28561f1", null, "Producer", "PROD" },
                    { "4d7bfd7c-49d8-4306-b1d3-b57ca62f3f07", null, "CoProducer", "COPR" },
                    { "55bad5d2-b442-4b57-8a3c-6d1f238591a2", null, "Administrator", "ADMIN" },
                    { "ec902aa0-c5b6-43e7-84e7-4d46feb1f0b4", null, "Amap", "AMAP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOfferPaymentMode",
                table: "ProductOfferPaymentMode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOfferPaymentMethod",
                table: "ProductOfferPaymentMethod");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131ceb02-2ba1-499a-abb6-41ffe28561f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d7bfd7c-49d8-4306-b1d3-b57ca62f3f07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55bad5d2-b442-4b57-8a3c-6d1f238591a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec902aa0-c5b6-43e7-84e7-4d46feb1f0b4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOfferPaymentMode",
                table: "ProductOfferPaymentMode",
                column: "ProductOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOfferPaymentMethod",
                table: "ProductOfferPaymentMethod",
                column: "ProductOfferId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18f253db-afe9-4695-8932-5f694282c1b5", null, "CoProducer", "COPR" },
                    { "39cb0c53-a2a6-4940-b73a-f88395e957e3", null, "Amap", "AMAP" },
                    { "675a270c-a771-4ff0-a5ae-6ac83850d79b", null, "Administrator", "ADMIN" },
                    { "c7b2145d-7c7d-485e-a4ba-8e7ad3eecabe", null, "Producer", "PROD" }
                });
        }
    }
}
