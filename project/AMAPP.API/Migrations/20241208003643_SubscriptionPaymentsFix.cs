using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionPaymentsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffer_ProductOffers_ProductOfferId",
                table: "SelectedProductOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffer_Subscriptions_SubscriptionId",
                table: "SelectedProductOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayment_SelectedProductOffer_SelectedProductOff~",
                table: "SubscriptionPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayment_Subscriptions_SubscriptionId",
                table: "SubscriptionPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPayment",
                table: "SubscriptionPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedProductOffer",
                table: "SelectedProductOffer");

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

            migrationBuilder.RenameTable(
                name: "SubscriptionPayment",
                newName: "SubscriptionPayments");

            migrationBuilder.RenameTable(
                name: "SelectedProductOffer",
                newName: "SelectedProductOffers");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionPayment_SubscriptionId",
                table: "SubscriptionPayments",
                newName: "IX_SubscriptionPayments_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionPayment_SelectedProductOfferId",
                table: "SubscriptionPayments",
                newName: "IX_SubscriptionPayments_SelectedProductOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffer_SubscriptionPeriodId",
                table: "SelectedProductOffers",
                newName: "IX_SelectedProductOffers_SubscriptionPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffer_SubscriptionId",
                table: "SelectedProductOffers",
                newName: "IX_SelectedProductOffers_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffer_ProductOfferId",
                table: "SelectedProductOffers",
                newName: "IX_SelectedProductOffers_ProductOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPayments",
                table: "SubscriptionPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedProductOffers",
                table: "SelectedProductOffers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffers_ProductOffers_ProductOfferId",
                table: "SelectedProductOffers",
                column: "ProductOfferId",
                principalTable: "ProductOffers",
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
                name: "FK_SelectedProductOffers_Subscriptions_SubscriptionId",
                table: "SelectedProductOffers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPayments_SelectedProductOffers_SelectedProductO~",
                table: "SubscriptionPayments",
                column: "SelectedProductOfferId",
                principalTable: "SelectedProductOffers",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffers_ProductOffers_ProductOfferId",
                table: "SelectedProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffers_SubscriptionPeriods_SubscriptionPerio~",
                table: "SelectedProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffers_Subscriptions_SubscriptionId",
                table: "SelectedProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayments_SelectedProductOffers_SelectedProductO~",
                table: "SubscriptionPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPayments_Subscriptions_SubscriptionId",
                table: "SubscriptionPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPayments",
                table: "SubscriptionPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedProductOffers",
                table: "SelectedProductOffers");

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

            migrationBuilder.RenameTable(
                name: "SubscriptionPayments",
                newName: "SubscriptionPayment");

            migrationBuilder.RenameTable(
                name: "SelectedProductOffers",
                newName: "SelectedProductOffer");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionPayments_SubscriptionId",
                table: "SubscriptionPayment",
                newName: "IX_SubscriptionPayment_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionPayments_SelectedProductOfferId",
                table: "SubscriptionPayment",
                newName: "IX_SubscriptionPayment_SelectedProductOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffers_SubscriptionPeriodId",
                table: "SelectedProductOffer",
                newName: "IX_SelectedProductOffer_SubscriptionPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffers_SubscriptionId",
                table: "SelectedProductOffer",
                newName: "IX_SelectedProductOffer_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedProductOffers_ProductOfferId",
                table: "SelectedProductOffer",
                newName: "IX_SelectedProductOffer_ProductOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPayment",
                table: "SubscriptionPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedProductOffer",
                table: "SelectedProductOffer",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffer_ProductOffers_ProductOfferId",
                table: "SelectedProductOffer",
                column: "ProductOfferId",
                principalTable: "ProductOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer",
                column: "SubscriptionPeriodId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffer_Subscriptions_SubscriptionId",
                table: "SelectedProductOffer",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPayment_SelectedProductOffer_SelectedProductOff~",
                table: "SubscriptionPayment",
                column: "SelectedProductOfferId",
                principalTable: "SelectedProductOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPayment_Subscriptions_SubscriptionId",
                table: "SubscriptionPayment",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
