using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaOnline.Migrations
{
    public partial class DB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rezerwacjas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacjas_UserId",
                table: "Rezerwacjas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_UserId",
                table: "Rezerwacjas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacjas_AspNetUsers_UserId",
                table: "Rezerwacjas");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacjas_UserId",
                table: "Rezerwacjas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rezerwacjas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
