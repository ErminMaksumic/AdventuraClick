using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class updatedLocationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
