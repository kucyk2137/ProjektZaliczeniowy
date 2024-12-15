using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class K2kkkk3243 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_UserProfiles_UserProfileId",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "UżytkownikId",
                table: "product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_AspNetUsers_UżytkownikId",
                table: "product",
                column: "UżytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_UserProfiles_UserProfileId",
                table: "product",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<string>(
                name: "UżytkownikId",
                table: "product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
