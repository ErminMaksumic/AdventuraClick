using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class addServReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REFERENCE_8",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "AdditionalServiceReservation");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalServiceAddServiceId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalServiceReservations",
                columns: table => new
                {
                    AdditionalServiceReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServiceReservations", x => x.AdditionalServiceReservationId);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceReservations_AdditionalService_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalService",
                        principalColumn: "addServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceReservations_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "reservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServiceReservations_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_AdditionalServiceAddServiceId",
                table: "Reservation",
                column: "AdditionalServiceAddServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PaymentId",
                table: "Reservation",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceReservations_AdditionalServiceId",
                table: "AdditionalServiceReservations",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceReservations_ReservationId",
                table: "AdditionalServiceReservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServiceReservations_TravelId",
                table: "AdditionalServiceReservations",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AdditionalService_AdditionalServiceAddServiceId",
                table: "Reservation",
                column: "AdditionalServiceAddServiceId",
                principalTable: "AdditionalService",
                principalColumn: "addServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Payment_PaymentId",
                table: "Reservation",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Travel_travelId",
                table: "Reservation",
                column: "travelId",
                principalTable: "Travel",
                principalColumn: "travelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AdditionalService_AdditionalServiceAddServiceId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Payment_PaymentId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Travel_travelId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "AdditionalServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_AdditionalServiceAddServiceId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_PaymentId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "AdditionalServiceAddServiceId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservation");

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

            migrationBuilder.AddForeignKey(
                name: "FK_REFERENCE_8",
                table: "Reservation",
                column: "travelId",
                principalTable: "Travel",
                principalColumn: "travelId");
        }
    }
}
