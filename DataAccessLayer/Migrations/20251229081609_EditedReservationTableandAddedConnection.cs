using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditedReservationTableandAddedConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DestinationID",
                table: "Reservation",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Destinations_DestinationID",
                table: "Reservation",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Destinations_DestinationID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_DestinationID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Reservation");
        }
    }
}
