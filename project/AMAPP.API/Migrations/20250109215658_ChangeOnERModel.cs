using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnERModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOffers_SubscriptionPeriods_PeriodSubscriptionId",
                table: "ProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducersInfo_ProducerInfoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffers_SubscriptionPeriods_SubscriptionPerio~",
                table: "SelectedProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayments_Subscriptions_SubscriptionId",
                table: "SubscriptionPayments");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPayments_SubscriptionId",
                table: "SubscriptionPayments");

            migrationBuilder.DropIndex(
                name: "IX_SelectedProductOffers_SubscriptionPeriodId",
                table: "SelectedProductOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedDeliveryDates",
                table: "SelectedDeliveryDates");

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
                name: "DeliveryDate",
                table: "SelectedProductOffers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SelectedProductOffers");

            migrationBuilder.DropColumn(
                name: "SubscriptionPeriodId",
                table: "SelectedProductOffers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SelectedDeliveryDates");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "ProductOffers");

            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "ProductOffers");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "SubscriptionPayments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "SubscriptionPayments",
                newName: "PaymentMode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SelectedDeliveryDates",
                newName: "DeliveryDateId");

            migrationBuilder.RenameColumn(
                name: "PeriodSubscriptionId",
                table: "ProductOffers",
                newName: "SubscriptionPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOffers_PeriodSubscriptionId",
                table: "ProductOffers",
                newName: "IX_ProductOffers_SubscriptionPeriodId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "SubscriptionPayments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "SubscriptionPayments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedProductOfferDeliveryId",
                table: "SubscriptionPayments",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDateId",
                table: "SelectedDeliveryDates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedDeliveryDates",
                table: "SelectedDeliveryDates",
                columns: new[] { "DeliveryDateId", "ProductOfferId" });

            migrationBuilder.CreateTable(
                name: "ProductOfferPaymentMethod",
                columns: table => new
                {
                    ProductOfferId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOfferPaymentMethod", x => x.ProductOfferId);
                    table.ForeignKey(
                        name: "FK_ProductOfferPaymentMethod_ProductOffers_ProductOfferId",
                        column: x => x.ProductOfferId,
                        principalTable: "ProductOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOfferPaymentMode",
                columns: table => new
                {
                    ProductOfferId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOfferPaymentMode", x => x.ProductOfferId);
                    table.ForeignKey(
                        name: "FK_ProductOfferPaymentMode_ProductOffers_ProductOfferId",
                        column: x => x.ProductOfferId,
                        principalTable: "ProductOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedProductOfferDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectedProductOfferId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDateId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveredAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedProductOfferDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedProductOfferDelivery_SelectedProductOffers_Selected~",
                        column: x => x.SelectedProductOfferId,
                        principalTable: "SelectedProductOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayments_SelectedProductOfferDeliveryId",
                table: "SubscriptionPayments",
                column: "SelectedProductOfferDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProductOfferDelivery_SelectedProductOfferId",
                table: "SelectedProductOfferDelivery",
                column: "SelectedProductOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOffers_SubscriptionPeriods_SubscriptionPeriodId",
                table: "ProductOffers",
                column: "SubscriptionPeriodId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducersInfo_ProducerInfoId",
                table: "Products",
                column: "ProducerInfoId",
                principalTable: "ProducersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedDeliveryDates_DeliveryDates_DeliveryDateId",
                table: "SelectedDeliveryDates",
                column: "DeliveryDateId",
                principalTable: "DeliveryDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPayments_SelectedProductOfferDelivery_SelectedP~",
                table: "SubscriptionPayments",
                column: "SelectedProductOfferDeliveryId",
                principalTable: "SelectedProductOfferDelivery",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOffers_SubscriptionPeriods_SubscriptionPeriodId",
                table: "ProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducersInfo_ProducerInfoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedDeliveryDates_DeliveryDates_DeliveryDateId",
                table: "SelectedDeliveryDates");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayments_SelectedProductOfferDelivery_SelectedP~",
                table: "SubscriptionPayments");

            migrationBuilder.DropTable(
                name: "ProductOfferPaymentMethod");

            migrationBuilder.DropTable(
                name: "ProductOfferPaymentMode");

            migrationBuilder.DropTable(
                name: "SelectedProductOfferDelivery");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPayments_SelectedProductOfferDeliveryId",
                table: "SubscriptionPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedDeliveryDates",
                table: "SelectedDeliveryDates");

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

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "SubscriptionPayments");

            migrationBuilder.DropColumn(
                name: "SelectedProductOfferDeliveryId",
                table: "SubscriptionPayments");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SubscriptionPayments",
                newName: "SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "PaymentMode",
                table: "SubscriptionPayments",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "DeliveryDateId",
                table: "SelectedDeliveryDates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubscriptionPeriodId",
                table: "ProductOffers",
                newName: "PeriodSubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOffers_SubscriptionPeriodId",
                table: "ProductOffers",
                newName: "IX_ProductOffers_PeriodSubscriptionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "SubscriptionPayments",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "SelectedProductOffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SelectedProductOffers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionPeriodId",
                table: "SelectedProductOffers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SelectedDeliveryDates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SelectedDeliveryDates",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedDeliveryDates",
                table: "SelectedDeliveryDates",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayments_SubscriptionId",
                table: "SubscriptionPayments",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProductOffers_SubscriptionPeriodId",
                table: "SelectedProductOffers",
                column: "SubscriptionPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOffers_SubscriptionPeriods_PeriodSubscriptionId",
                table: "ProductOffers",
                column: "PeriodSubscriptionId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducersInfo_ProducerInfoId",
                table: "Products",
                column: "ProducerInfoId",
                principalTable: "ProducersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffers_SubscriptionPeriods_SubscriptionPerio~",
                table: "SelectedProductOffers",
                column: "SubscriptionPeriodId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPayments_Subscriptions_SubscriptionId",
                table: "SubscriptionPayments",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
