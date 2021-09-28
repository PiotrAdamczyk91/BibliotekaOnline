using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaOnline.Migrations
{
    public partial class DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_IdentityUserId",
                table: "Rezerwacjas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_UserIDId",
                table: "Rezerwacjas");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacjas_IdentityUserId",
                table: "Rezerwacjas");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacjas_UserIDId",
                table: "Rezerwacjas");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Rezerwacjas");

            migrationBuilder.DropColumn(
                name: "UserIDId",
                table: "Rezerwacjas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Rezerwacjas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIDId",
                table: "Rezerwacjas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacjas_IdentityUserId",
                table: "Rezerwacjas",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacjas_UserIDId",
                table: "Rezerwacjas",
                column: "UserIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_IdentityUserId",
                table: "Rezerwacjas",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_UserIDId",
                table: "Rezerwacjas",
                column: "UserIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
