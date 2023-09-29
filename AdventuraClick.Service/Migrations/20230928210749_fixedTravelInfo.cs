using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class fixedTravelInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "TravelInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TravelInformations_TravelId",
                table: "TravelInformations",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelInformations_Travel_TravelId",
                table: "TravelInformations",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "travelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelInformations_Travel_TravelId",
                table: "TravelInformations");

            migrationBuilder.DropIndex(
                name: "IX_TravelInformations_TravelId",
                table: "TravelInformations");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "TravelInformations");
        }
    }
}
