using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    destination = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(38,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tour__3213E83F1670238E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Booking__3213E83F77C48CA8", x => x.id);
                    table.ForeignKey(
                        name: "FK_booking_tourId",
                        column: x => x.tourId,
                        principalTable: "Tour",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_tourId",
                table: "Booking",
                column: "tourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
