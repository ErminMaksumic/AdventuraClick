using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    /// <inheritdoc />
    public partial class addedIncludedItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncludedItem",
                columns: table => new
                {
                    IncludedItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedItem", x => x.IncludedItemId);
                });

            migrationBuilder.CreateTable(
                name: "IncludedItemTravels",
                columns: table => new
                {
                    IncludedItemTravelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncludedItemId = table.Column<int>(type: "int", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedItemTravels", x => x.IncludedItemTravelId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_25",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "travelId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_26",
                        column: x => x.IncludedItemId,
                        principalTable: "IncludedItem",
                        principalColumn: "IncludedItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncludedItemTravels_IncludedItemId",
                table: "IncludedItemTravels",
                column: "IncludedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedItemTravels_TravelId",
                table: "IncludedItemTravels",
                column: "TravelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncludedItemTravels");

            migrationBuilder.DropTable(
                name: "IncludedItem");
        }
    }
}
