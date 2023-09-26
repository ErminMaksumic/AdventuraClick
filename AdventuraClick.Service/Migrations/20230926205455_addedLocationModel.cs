using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class addedLocationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REFERENCE_4",
                table: "Travel");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Travel_Location_locationId",
                table: "Travel",
                column: "locationId",
                principalTable: "Location",
                principalColumn: "locationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travel_Location_locationId",
                table: "Travel");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Location",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_REFERENCE_4",
                table: "Travel",
                column: "locationId",
                principalTable: "Location",
                principalColumn: "locationId");
        }
    }
}
