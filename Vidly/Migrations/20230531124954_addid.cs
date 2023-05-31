using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class addid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipIdId",
                table: "Customers",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipIdId",
                table: "Customers",
                column: "MembershipIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipIdId",
                table: "Customers",
                column: "MembershipIdId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipIdId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipIdId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipIdId",
                table: "Customers");
        }
    }
}
