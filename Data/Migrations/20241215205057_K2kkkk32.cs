using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class K2kkkk32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "UżytkownikId",
                table: "UserProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UżytkownikId",
                table: "UserProfiles",
                column: "UżytkownikId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AspNetUsers_UżytkownikId",
                table: "UserProfiles",
                column: "UżytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AspNetUsers_UżytkownikId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UżytkownikId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UżytkownikId",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
