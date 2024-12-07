using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMAPP.API.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionPeriodIdINSelectedProductOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer");

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

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionPeriodId",
                table: "SelectedProductOffer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer",
                column: "SubscriptionPeriodId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer");

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

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionPeriodId",
                table: "SelectedProductOffer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProductOffer_SubscriptionPeriods_SubscriptionPeriod~",
                table: "SelectedProductOffer",
                column: "SubscriptionPeriodId",
                principalTable: "SubscriptionPeriods",
                principalColumn: "Id");
        }
    }
}
