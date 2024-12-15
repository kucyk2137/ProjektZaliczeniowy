using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class K2K2k : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserProfiles",
                newName: "Nazwisko");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "UserProfiles",
                newName: "Imię");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "UserProfiles",
                newName: "Adres");

            migrationBuilder.AddColumn<string>(
                name: "KodPocztowy",
                table: "UserProfiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodPocztowy",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "UserProfiles",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Imię",
                table: "UserProfiles",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "UserProfiles",
                newName: "Address");
        }
    }
}
