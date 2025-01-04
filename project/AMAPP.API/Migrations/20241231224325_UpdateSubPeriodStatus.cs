using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubPeriodStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "657f1b92-3b72-4d8c-ae4f-6eabc2e415bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728c2e4e-c9fa-4899-a9ea-35c7d50231c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "890ca466-5c45-4dea-826a-54fd0e19a9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e14c43-9485-44da-8d9a-5c9b11f21af8");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "SubscriptionPeriods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourceStatus",
                table: "SubscriptionPeriods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourceStatus",
                table: "DeliveryDates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8454e0e5-c71e-4c51-9ec6-6c52a2e52ad8", null, "Producer", "PROD" },
                    { "c26e8058-f1d1-46aa-bb10-ca815ddefcbe", null, "Administrator", "ADMIN" },
                    { "d8d7d7a7-383d-4ab9-b2d1-2c32c7770926", null, "CoProducer", "COPR" },
                    { "f318aa3e-9248-4aeb-898f-528cff4b0b41", null, "Amap", "AMAP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8454e0e5-c71e-4c51-9ec6-6c52a2e52ad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26e8058-f1d1-46aa-bb10-ca815ddefcbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d7d7a7-383d-4ab9-b2d1-2c32c7770926");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f318aa3e-9248-4aeb-898f-528cff4b0b41");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SubscriptionPeriods");

            migrationBuilder.DropColumn(
                name: "ResourceStatus",
                table: "SubscriptionPeriods");

            migrationBuilder.DropColumn(
                name: "ResourceStatus",
                table: "DeliveryDates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "657f1b92-3b72-4d8c-ae4f-6eabc2e415bc", null, "Producer", "PROD" },
                    { "728c2e4e-c9fa-4899-a9ea-35c7d50231c2", null, "Amap", "AMAP" },
                    { "890ca466-5c45-4dea-826a-54fd0e19a9e9", null, "CoProducer", "COPR" },
                    { "f7e14c43-9485-44da-8d9a-5c9b11f21af8", null, "Administrator", "ADMIN" }
                });
        }
    }
}
