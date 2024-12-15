using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Koniec2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_UserProfileId",
                table: "product",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_UserProfiles_UserProfileId",
                table: "product",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_UserProfiles_UserProfileId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_UserProfileId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "product");
        }
    }
}
