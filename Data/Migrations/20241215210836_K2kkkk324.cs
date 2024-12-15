using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class K2kkkk324 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "UżytkownikId",
                table: "product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product",
                column: "UżytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_UserProfiles_UserProfileId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_UserProfileId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "UżytkownikId",
                table: "product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product",
                column: "UżytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
