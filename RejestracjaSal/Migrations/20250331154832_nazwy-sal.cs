using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class nazwysal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 15,
                column: "Name",
                value: "Klasyczna aula wykładowa");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 16,
                column: "Name",
                value: "Kameralna sala warsztatowa");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Name",
                value: "Nowoczesna sala komputerowa");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 18,
                column: "Name",
                value: "Przestrzeń kreatywna");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegancka, przestronna sala idealna na zebrania, prelekcje i spotkania biznesowe. Duże okna wychodzą na wewnętrzny dziedziniec, zapewniając piękny widok i dużo światła dziennego. Pomieszczenie wyposażone jest w ekran, projektor oraz system nagłośnienia.", "Sala konferencyjna z widokiem na dziedziniec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 15,
                column: "Name",
                value: "Sala 11");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 16,
                column: "Name",
                value: "Sala 12");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Name",
                value: "Sala 13");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 18,
                column: "Name",
                value: "Sala 14");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegancka, przestronna sala idealna na zebrania, prelekcje i spotkania biznesowe. Duże okna wychodzą na wewnętrzny dziedziniec, zapewniając piękny widok i dużo światła dziennego. Pomieszczenie wyposażone jest w ekran, projektor oraz system nagłośnienia.\r\n\r\n", "Sala 15" });
        }
    }
}
