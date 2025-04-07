using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class rezerwacje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Total_price = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsRooms",
                columns: table => new
                {
                    ReservationRoom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_id = table.Column<int>(type: "int", nullable: false),
                    Reservation_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_price = table.Column<float>(type: "real", nullable: false),
                    Room_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsRooms", x => x.ReservationRoom_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationsRooms");
        }
    }
}
