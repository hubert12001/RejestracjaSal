using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class migracjanowanowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 15,
                column: "Description",
                value: "Przestronna aula o klasycznym układzie, idealna na wykłady, seminaria i konferencje. Pomieszczenie wyposażone jest w projektor, duży ekran oraz nagłośnienie. Wysokie okna zapewniają dużo naturalnego światła, a zabytkowe drewniane ławki dodają wyjątkowego klimatu.\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 16,
                column: "Description",
                value: "Średniej wielkości sala doskonała na warsztaty, spotkania i zajęcia w mniejszych grupach. Wyposażona w tablicę suchościeralną, rzutnik oraz ruchome stoły i krzesła, umożliwiające dowolną aranżację przestrzeni. Klimatyczna ceglana ściana przypomina o historii budynku.\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Description",
                value: "Przystosowana do zajęć informatycznych sala z nowoczesnym sprzętem. Każde stanowisko wyposażone jest w komputer z szybkim dostępem do internetu. Dodatkowo sala oferuje tablicę interaktywną oraz ergonomiczne krzesła zapewniające komfort nawet podczas dłuższych zajęć.\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 18,
                column: "Description",
                value: "Nowoczesna sala przystosowana do spotkań projektowych i kreatywnych sesji. Posiada wygodne fotele, stoły konferencyjne oraz ściany pokryte farbą suchościeralną, umożliwiającą zapisywanie pomysłów. Dobre oświetlenie i industrialny charakter wnętrza sprzyjają twórczej pracy.");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Description",
                value: "Elegancka, przestronna sala idealna na zebrania, prelekcje i spotkania biznesowe. Duże okna wychodzą na wewnętrzny dziedziniec, zapewniając piękny widok i dużo światła dziennego. Pomieszczenie wyposażone jest w ekran, projektor oraz system nagłośnienia.\r\n\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 15,
                column: "Description",
                value: "Pierwsze pietro");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 16,
                column: "Description",
                value: "Pierwsze pietro");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Description",
                value: "Pierwsze pietro");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 18,
                column: "Description",
                value: "Pierwsze pietro");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Description",
                value: "Pierwsze pietro");
        }
    }
}
