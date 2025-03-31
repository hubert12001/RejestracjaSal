using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class nazwy_sal_i_opisy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Kameralna sala przeznaczona na seminaria, spotkania grupowe i zajęcia dydaktyczne. Układ stołów w podkowę sprzyja dyskusjom i interaktywnej pracy. Wyposażona w ekran projekcyjny, flipchart oraz system nagłośnienia.", "Sala dyskusyjna" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nowoczesna sala stworzona z myślą o nauce języków obcych. Każde stanowisko wyposażone jest w słuchawki i mikrofon, a centralny system audio umożliwia prowadzenie ćwiczeń z wymową i odsłuchami. Dodatkowo dostępna jest tablica interaktywna.\r\n\r\n", "Pracownia językowa" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sala dostosowana do zajęć wymagających dostępu do nowoczesnych technologii. Wyposażona w komputery, tablety oraz zestawy VR, pozwala na prowadzenie interaktywnych zajęć i warsztatów. Przestrzeń modułowa umożliwia różne ustawienia stanowisk.\r\n\r\n", "Multimedialne laboratorium" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Stylowa sala z wysokim sufitem i zachowanymi elementami architektonicznymi dawnego gimnazjum. Idealna na wykłady, prezentacje i spotkania formalne. Oferuje duży ekran projekcyjny, drewniane ławy i oryginalne zdobienia ścian, nadające jej wyjątkowy charakter.\r\n\r\n", "Historyczna aula konferencyjna" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Specjalistyczna sala przeznaczona dla osób zajmujących się nagrywaniem i obróbką dźwięku. Wyposażona w profesjonalny sprzęt nagraniowy, mikrofony, wygłuszone ściany oraz stanowiska montażowe. Idealna dla podcasterów, lektorów i realizatorów dźwięku.\r\n\r\n", "Studio nagraniowe i montażowe" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nowoczesna, otwarta sala dostosowana do pracy zespołowej i indywidualnej. Wyposażona w biurka, wygodne fotele oraz liczne punkty zasilania. Dostępna szybka sieć Wi-Fi, tablica magnetyczna oraz kącik relaksu z sofą i ekspresem do kawy.\r\n\r\n", "Przestrzeń coworkingowa\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Jasne, przestronne pomieszczenie z dużymi oknami i stołami przystosowanymi do pracy twórczej. Sala idealna dla zajęć plastycznych, warsztatów rzemieślniczych i projektów artystycznych. Wyposażona w sztalugi, tablicę korkową i szafki na materiały.\r\n\r\n", "Pracownia artystyczna" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nowoczesna sala z układem amfiteatralnym, idealna do prowadzenia wykładów, prelekcji i prezentacji. Wyposażona w projektor, ekran oraz stanowiska komputerowe, które umożliwiają interaktywne zajęcia. Wysokie okna zapewniają doskonałe doświetlenie naturalnym światłem.\r\n\r\n", "Sala wykładowa z komputerami\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Kameralna sala, która doskonale sprawdza się w roli miejsca do przeprowadzania seminariów, spotkań dyskusyjnych i zajęć w mniejszych grupach. Wyposażona w projektor, ekran oraz komfortowe krzesła i stoły, które można dowolnie ustawiać w zależności od potrzeb.\r\n\r\n", "Sala spotkań seminaryjnych" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sala specjalistyczna, przystosowana do zajęć laboratoryjnych z zakresu biologii. Wyposażona w stoły laboratoryjne, mikroskopy, szafy na odczynniki oraz system wentylacyjny. Idealna do przeprowadzania eksperymentów, badań i analiz.\r\n\r\n", "Pracownia biologiczna" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Idealna do spotkań projektowych i burz mózgów. Sala wyposażona w nowoczesną tablicę interaktywną, rzutnik oraz stoliki do pracy grupowej. Przestronna, z dużą ilością światła dziennego, sprzyja kreatywnej pracy i efektywnej wymianie pomysłów.\r\n\r\n", "Sala projektowa z tablicą interaktywną\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Dobrze wyposażona sala laboratoryjna, przeznaczona do zajęć chemicznych. Posiada specjalistyczne stoły z dostępem do wody, gazu i prądu, a także szafy na odczynniki chemiczne. Świetnie nadaje się do przeprowadzania eksperymentów i badań chemicznych.\r\n\r\n", "Pracownia chemiczna" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Aula z ustawieniem w układzie kinowym, idealna na projekcje filmowe, wykłady lub szkolenia. Posiada duży ekran, projektor, system nagłośnienia i komfortowe fotele. Doskonałe miejsce do nauki z elementami multimedialnymi.\r\n\r\n", "Sala dydaktyczna z układem kinowym\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "W pełni wyposażona sala komputerowa z dostępem do internetu. Każde stanowisko ma zainstalowane oprogramowanie edukacyjne, co czyni ją idealnym miejscem do zajęć informatycznych, szkoleń i warsztatów praktycznych. Sala jest przestronna i dobrze doświetlona.\r\n\r\n", "Sala komputerowa z dostępem do internetu" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 20,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegancka sala konferencyjna, wyposażona w duży telebim oraz system audio. Doskonała do przeprowadzania prezentacji, spotkań biznesowych i konferencji. Wysokiej jakości wykończenia wnętrz oraz wygodne fotele zapewniają komfort podczas długotrwałych spotkań.\r\n\r\n", "Sala konferencyjna z telebimem" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 21,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Przestronna sala z dużymi oknami, idealna dla osób zajmujących się sztuką. Wyposażona w sztalugi, stoły do malowania i drewno do rzeźbienia. Świetna do zajęć z zakresu malarstwa, rzeźby i innych dziedzin plastycznych.\r\n\r\n", "Pracownia plastyczna z przestrzenią do malowania\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 22,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegancka sala wykładowa o przestronnym układzie, wyposażona w projektor, ekran, system audio i klimatyzację. Wysokie sufity oraz przestronność sprawiają, że jest to doskonałe miejsce na większe wykłady, seminaria i kursy.\r\n\r\n", "Sala wykładowa z klimatyzacją" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 23,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sala z odpowiednim wyposażeniem do przeprowadzania eksperymentów z zakresu fizyki. Posiada stoły do eksperymentów, pomoce dydaktyczne oraz szafy do przechowywania sprzętu i materiałów. Idealna do naukowych zajęć praktycznych.\r\n\r\n", "Sala laboratoryjna fizyczna\r\n" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 24,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nowoczesna sala, idealna do zajęć matematycznych, posiadająca tablicę interaktywną, projektor oraz ergonomiczne krzesła i biurka. Świetna do prowadzenia wykładów, ćwiczeń i rozwiązywania zadań matematycznych w grupach.\r\n\r\n", "Pracownia matematyczna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 31" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 32" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 33" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 34" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 35" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Trzecie pietro", "Sala 36" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 21" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 22" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 23" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 24" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 25" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 26" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 27" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 28" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 20,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pierwsze pietro", "Sala 16" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 21,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pierwsze pietro", "Sala 17" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 22,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pierwsze pietro", "Sala 18" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 23,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pierwsze pietro", "Sala 19" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 24,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Drugie pietro", "Sala 20" });
        }
    }
}
