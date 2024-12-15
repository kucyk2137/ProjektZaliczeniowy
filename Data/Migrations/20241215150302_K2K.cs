using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class K2K : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_AspNetUsers_DaneUżytkownikaId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_DaneUżytkownikaId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "DaneUżytkownikaId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Imie",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DaneUżytkownikaId",
                table: "product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telefon",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_DaneUżytkownikaId",
                table: "product",
                column: "DaneUżytkownikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_AspNetUsers_DaneUżytkownikaId",
                table: "product",
                column: "DaneUżytkownikaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
