using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class movedAddServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelAddService");

            migrationBuilder.CreateTable(
                name: "AdditionalServiceReservation",
                columns: table => new
                {
                    AddServicesAddServiceId = table.Column<int>(type: "int", nullable: false),
                    ReservationsReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServiceReservation", x => new { x.AddServicesAddServiceId, x.ReservationsReservationId });
                    table.ForeignKey(
                        name: "FK_AdditionalServiceReservation_AdditionalService_AddServicesAddServiceId",
                        column: x => x.AddServicesAddServiceId,
                        principalTable: "AdditionalService",
                        principalColumn: "addServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceReservation_Reservation_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservation",
                        principalColumn: "reservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceReservation_ReservationsReservationId",
                table: "AdditionalServiceReservation",
                column: "ReservationsReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServiceReservation");

            migrationBuilder.CreateTable(
                name: "TravelAddService",
                columns: table => new
                {
                    travelId = table.Column<int>(type: "int", nullable: false),
                    addServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_11", x => new { x.travelId, x.addServiceId });
                    table.ForeignKey(
                        name: "FK_REFERENCE_6",
                        column: x => x.travelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_7",
                        column: x => x.addServiceId,
                        principalTable: "AdditionalService",
                        principalColumn: "addServiceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelAddService_addServiceId",
                table: "TravelAddService",
                column: "addServiceId");
        }
    }
}
