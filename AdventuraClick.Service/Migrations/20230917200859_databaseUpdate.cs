using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class databaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                columns: table => new
                {
                    addServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_9", x => x.addServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_7", x => x.locationId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_2", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "TravelType",
                columns: table => new
                {
                    travelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_8", x => x.travelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdAt = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_1", x => x.userId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_1",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    travelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    travelTypeId = table.Column<int>(type: "int", nullable: true),
                    locationId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_5", x => x.travelId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_3",
                        column: x => x.travelTypeId,
                        principalTable: "TravelType",
                        principalColumn: "travelTypeId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_4",
                        column: x => x.locationId,
                        principalTable: "Location",
                        principalColumn: "locationId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    travelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_6", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_5",
                        column: x => x.travelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ratingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    travelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_3", x => x.ratingId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_2",
                        column: x => x.travelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    reservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    travelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_4", x => x.reservationId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_8",
                        column: x => x.travelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                });

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
                name: "IX_Payment_travelId",
                table: "Payment",
                column: "travelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_travelId",
                table: "Rating",
                column: "travelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_travelId",
                table: "Reservation",
                column: "travelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_locationId",
                table: "Travel",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_travelTypeId",
                table: "Travel",
                column: "travelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAddService_addServiceId",
                table: "TravelAddService",
                column: "addServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleId",
                table: "User",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "TravelAddService");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Travel");

            migrationBuilder.DropTable(
                name: "AdditionalService");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TravelType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });
        }
    }
}
