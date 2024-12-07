using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class RevertDeliveryDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryDateBase");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2668a188-2bcb-43dc-927e-d93510f58577");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e79c406-9476-483d-a9e1-3ea3f97ccbdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a487c26-f7ba-45ff-bb38-0320d9a5cd3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e68a30-2ce2-4a41-8545-d0ef118777cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8546c049-6605-46af-b72c-4c4c440bae6f", null, "Administrator", "ADMIN" },
                    { "99f18f81-8eda-4e17-a34d-22eb5cbb549c", null, "Amap", "AMAP" },
                    { "d4139b00-1445-4c5e-b0c1-b5969b043bdc", null, "CoProducer", "COPR" },
                    { "e2f60f3d-70f1-44db-a9b8-cdf0dd0f6a3a", null, "Producer", "PROD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8546c049-6605-46af-b72c-4c4c440bae6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99f18f81-8eda-4e17-a34d-22eb5cbb549c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4139b00-1445-4c5e-b0c1-b5969b043bdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f60f3d-70f1-44db-a9b8-cdf0dd0f6a3a");

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
                    { "2668a188-2bcb-43dc-927e-d93510f58577", null, "Producer", "PROD" },
                    { "2e79c406-9476-483d-a9e1-3ea3f97ccbdc", null, "CoProducer", "COPR" },
                    { "9a487c26-f7ba-45ff-bb38-0320d9a5cd3f", null, "Administrator", "ADMIN" },
                    { "e8e68a30-2ce2-4a41-8545-d0ef118777cc", null, "Amap", "AMAP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDateBase_SubscriptionPeriodId",
                table: "DeliveryDateBase",
                column: "SubscriptionPeriodId");
        }
    }
}
