using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeliveryDate : Migration
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
                    { "010da128-a5a2-4c75-bf6b-1e22ab7fa5cc", null, "Administrator", "ADMIN" },
                    { "a56c8c9c-413b-4d27-b13a-b75a6b732b48", null, "Producer", "PROD" },
                    { "ddbc04c3-858f-47f7-892f-80c5471c85b5", null, "CoProducer", "COPR" },
                    { "ffdea180-7651-450f-9661-b42bf5c6db99", null, "Amap", "AMAP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
