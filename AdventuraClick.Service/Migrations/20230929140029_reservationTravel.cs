using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class reservationTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelInformationId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TravelInformationId",
                table: "Reservation",
                column: "TravelInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_TravelInformations_TravelInformationId",
                table: "Reservation",
                column: "TravelInformationId",
                principalTable: "TravelInformations",
                principalColumn: "TravelInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_TravelInformations_TravelInformationId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_TravelInformationId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "TravelInformationId",
                table: "Reservation");
        }
    }
}
