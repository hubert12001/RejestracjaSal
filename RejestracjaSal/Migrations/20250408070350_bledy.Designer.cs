﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RejestracjaSal.Models;

#nullable disable

namespace RejestracjaSal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250408070350_bledy")]
    partial class bledy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RejestracjaSal.Models.Locations", b =>
                {
                    b.Property<int>("Location_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Location_id"), 1L, 1);

                    b.Property<string>("Bulding_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location_id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Location_id = 1,
                            Bulding_code = "B01",
                            City = "Bydgoszcz",
                            Description = "Wejśćie tylnymi drzwiam",
                            Name = "Gimnazjum",
                            Street = "Kamienna 5",
                            Zip_code = "35-705"
                        });
                });

            modelBuilder.Entity("RejestracjaSal.Models.Reservations", b =>
                {
                    b.Property<int>("Reservation_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_id"), 1L, 1);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("Total_price")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Reservation_id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RejestracjaSal.Models.Reservations_Rooms", b =>
                {
                    b.Property<int>("ReservationRoom_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationRoom_Id"), 1L, 1);

                    b.Property<DateTime>("Reservation_end_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reservation_id")
                        .HasColumnType("int");

                    b.Property<float>("Reservation_price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Reservation_start_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Room_id")
                        .HasColumnType("int");

                    b.HasKey("ReservationRoom_Id");

                    b.ToTable("ReservationsRooms");
                });

            modelBuilder.Entity("RejestracjaSal.Models.Rooms", b =>
                {
                    b.Property<int>("Room_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Room_price")
                        .HasColumnType("real");

                    b.Property<int>("Type_id")
                        .HasColumnType("int");

                    b.HasKey("Room_id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Room_id = 1,
                            Capacity = 24,
                            Description = "Kameralna sala przeznaczona na seminaria, spotkania grupowe i zajęcia dydaktyczne. Układ stołów w podkowę sprzyja dyskusjom i interaktywnej pracy. Wyposażona w ekran projekcyjny, flipchart oraz system nagłośnienia.",
                            Image = "sala-lekcyjna1.jpg",
                            Location_id = 1,
                            Name = "Sala dyskusyjna",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 2,
                            Capacity = 24,
                            Description = "Nowoczesna sala stworzona z myślą o nauce języków obcych. Każde stanowisko wyposażone jest w słuchawki i mikrofon, a centralny system audio umożliwia prowadzenie ćwiczeń z wymową i odsłuchami. Dodatkowo dostępna jest tablica interaktywna.\r\n\r\n",
                            Image = "sala-lekcyjna2.jpg",
                            Location_id = 1,
                            Name = "Pracownia językowa",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 3,
                            Capacity = 24,
                            Description = "Sala dostosowana do zajęć wymagających dostępu do nowoczesnych technologii. Wyposażona w komputery, tablety oraz zestawy VR, pozwala na prowadzenie interaktywnych zajęć i warsztatów. Przestrzeń modułowa umożliwia różne ustawienia stanowisk.\r\n\r\n",
                            Image = "sala-lekcyjna3.jpg",
                            Location_id = 1,
                            Name = "Multimedialne laboratorium",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 4,
                            Capacity = 36,
                            Description = "Stylowa sala z wysokim sufitem i zachowanymi elementami architektonicznymi dawnego gimnazjum. Idealna na wykłady, prezentacje i spotkania formalne. Oferuje duży ekran projekcyjny, drewniane ławy i oryginalne zdobienia ścian, nadające jej wyjątkowy charakter.\r\n\r\n",
                            Image = "sala-lekcyjna4.jpg",
                            Location_id = 1,
                            Name = "Historyczna aula konferencyjna",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 5,
                            Capacity = 16,
                            Description = "Specjalistyczna sala przeznaczona dla osób zajmujących się nagrywaniem i obróbką dźwięku. Wyposażona w profesjonalny sprzęt nagraniowy, mikrofony, wygłuszone ściany oraz stanowiska montażowe. Idealna dla podcasterów, lektorów i realizatorów dźwięku.\r\n\r\n",
                            Image = "sala-lekcyjna5.jpg",
                            Location_id = 1,
                            Name = "Studio nagraniowe i montażowe",
                            Room_price = 25f,
                            Type_id = 2
                        },
                        new
                        {
                            Room_id = 6,
                            Capacity = 20,
                            Description = "Nowoczesna, otwarta sala dostosowana do pracy zespołowej i indywidualnej. Wyposażona w biurka, wygodne fotele oraz liczne punkty zasilania. Dostępna szybka sieć Wi-Fi, tablica magnetyczna oraz kącik relaksu z sofą i ekspresem do kawy.\r\n\r\n",
                            Image = "sala-lekcyjna6.jpg",
                            Location_id = 1,
                            Name = "Przestrzeń coworkingowa\r\n",
                            Room_price = 35f,
                            Type_id = 2
                        },
                        new
                        {
                            Room_id = 7,
                            Capacity = 48,
                            Description = "Jasne, przestronne pomieszczenie z dużymi oknami i stołami przystosowanymi do pracy twórczej. Sala idealna dla zajęć plastycznych, warsztatów rzemieślniczych i projektów artystycznych. Wyposażona w sztalugi, tablicę korkową i szafki na materiały.\r\n\r\n",
                            Image = "sala-lekcyjna7.jpg",
                            Location_id = 1,
                            Name = "Pracownia artystyczna",
                            Room_price = 100f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 8,
                            Capacity = 24,
                            Description = "Nowoczesna sala z układem amfiteatralnym, idealna do prowadzenia wykładów, prelekcji i prezentacji. Wyposażona w projektor, ekran oraz stanowiska komputerowe, które umożliwiają interaktywne zajęcia. Wysokie okna zapewniają doskonałe doświetlenie naturalnym światłem.\r\n\r\n",
                            Image = "sala-lekcyjna8.jpg",
                            Location_id = 1,
                            Name = "Sala wykładowa z komputerami\r\n",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 9,
                            Capacity = 24,
                            Description = "Kameralna sala, która doskonale sprawdza się w roli miejsca do przeprowadzania seminariów, spotkań dyskusyjnych i zajęć w mniejszych grupach. Wyposażona w projektor, ekran oraz komfortowe krzesła i stoły, które można dowolnie ustawiać w zależności od potrzeb.\r\n\r\n",
                            Image = "sala-lekcyjna9.jpg",
                            Location_id = 1,
                            Name = "Sala spotkań seminaryjnych",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 10,
                            Capacity = 10,
                            Description = "Sala specjalistyczna, przystosowana do zajęć laboratoryjnych z zakresu biologii. Wyposażona w stoły laboratoryjne, mikroskopy, szafy na odczynniki oraz system wentylacyjny. Idealna do przeprowadzania eksperymentów, badań i analiz.\r\n\r\n",
                            Image = "sala-lekcyjna10.jpg",
                            Location_id = 1,
                            Name = "Pracownia biologiczna",
                            Room_price = 15f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 11,
                            Capacity = 18,
                            Description = "Idealna do spotkań projektowych i burz mózgów. Sala wyposażona w nowoczesną tablicę interaktywną, rzutnik oraz stoliki do pracy grupowej. Przestronna, z dużą ilością światła dziennego, sprzyja kreatywnej pracy i efektywnej wymianie pomysłów.\r\n\r\n",
                            Image = "sala-lekcyjna11.jpg",
                            Location_id = 1,
                            Name = "Sala projektowa z tablicą interaktywną\r\n",
                            Room_price = 35f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 12,
                            Capacity = 18,
                            Description = "Dobrze wyposażona sala laboratoryjna, przeznaczona do zajęć chemicznych. Posiada specjalistyczne stoły z dostępem do wody, gazu i prądu, a także szafy na odczynniki chemiczne. Świetnie nadaje się do przeprowadzania eksperymentów i badań chemicznych.\r\n\r\n",
                            Image = "sala-lekcyjna12.jpg",
                            Location_id = 1,
                            Name = "Pracownia chemiczna",
                            Room_price = 35f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 13,
                            Capacity = 30,
                            Description = "Aula z ustawieniem w układzie kinowym, idealna na projekcje filmowe, wykłady lub szkolenia. Posiada duży ekran, projektor, system nagłośnienia i komfortowe fotele. Doskonałe miejsce do nauki z elementami multimedialnymi.\r\n\r\n",
                            Image = "sala-lekcyjna13.jpg",
                            Location_id = 1,
                            Name = "Sala dydaktyczna z układem kinowym\r\n",
                            Room_price = 65f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 14,
                            Capacity = 36,
                            Description = "W pełni wyposażona sala komputerowa z dostępem do internetu. Każde stanowisko ma zainstalowane oprogramowanie edukacyjne, co czyni ją idealnym miejscem do zajęć informatycznych, szkoleń i warsztatów praktycznych. Sala jest przestronna i dobrze doświetlona.\r\n\r\n",
                            Image = "sala-lekcyjna14.jpg",
                            Location_id = 1,
                            Name = "Sala komputerowa z dostępem do internetu",
                            Room_price = 80f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 15,
                            Capacity = 36,
                            Description = "Przestronna aula o klasycznym układzie, idealna na wykłady, seminaria i konferencje. Pomieszczenie wyposażone jest w projektor, duży ekran oraz nagłośnienie. Wysokie okna zapewniają dużo naturalnego światła, a zabytkowe drewniane ławki dodają wyjątkowego klimatu.\r\n\r\n",
                            Image = "sala-lekcyjna15.jpg",
                            Location_id = 1,
                            Name = "Klasyczna aula wykładowa",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 16,
                            Capacity = 18,
                            Description = "Średniej wielkości sala doskonała na warsztaty, spotkania i zajęcia w mniejszych grupach. Wyposażona w tablicę suchościeralną, rzutnik oraz ruchome stoły i krzesła, umożliwiające dowolną aranżację przestrzeni. Klimatyczna ceglana ściana przypomina o historii budynku.\r\n\r\n",
                            Image = "sala-lekcyjna16.jpg",
                            Location_id = 1,
                            Name = "Kameralna sala warsztatowa",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 17,
                            Capacity = 24,
                            Description = "Przystosowana do zajęć informatycznych sala z nowoczesnym sprzętem. Każde stanowisko wyposażone jest w komputer z szybkim dostępem do internetu. Dodatkowo sala oferuje tablicę interaktywną oraz ergonomiczne krzesła zapewniające komfort nawet podczas dłuższych zajęć.\r\n\r\n",
                            Image = "sala-lekcyjna17.png",
                            Location_id = 1,
                            Name = "Nowoczesna sala komputerowa",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 18,
                            Capacity = 24,
                            Description = "Nowoczesna sala przystosowana do spotkań projektowych i kreatywnych sesji. Posiada wygodne fotele, stoły konferencyjne oraz ściany pokryte farbą suchościeralną, umożliwiającą zapisywanie pomysłów. Dobre oświetlenie i industrialny charakter wnętrza sprzyjają twórczej pracy.",
                            Image = "sala-lekcyjna18.jpg",
                            Location_id = 1,
                            Name = "Przestrzeń kreatywna",
                            Room_price = 46f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 19,
                            Capacity = 28,
                            Description = "Elegancka, przestronna sala idealna na zebrania, prelekcje i spotkania biznesowe. Duże okna wychodzą na wewnętrzny dziedziniec, zapewniając piękny widok i dużo światła dziennego. Pomieszczenie wyposażone jest w ekran, projektor oraz system nagłośnienia.",
                            Image = "sala-lekcyjna19.jpg",
                            Location_id = 1,
                            Name = "Sala konferencyjna z widokiem na dziedziniec",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 20,
                            Capacity = 24,
                            Description = "Elegancka sala konferencyjna, wyposażona w duży telebim oraz system audio. Doskonała do przeprowadzania prezentacji, spotkań biznesowych i konferencji. Wysokiej jakości wykończenia wnętrz oraz wygodne fotele zapewniają komfort podczas długotrwałych spotkań.\r\n\r\n",
                            Image = "sala-lekcyjna20.jpg",
                            Location_id = 1,
                            Name = "Sala konferencyjna z telebimem",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 21,
                            Capacity = 12,
                            Description = "Przestronna sala z dużymi oknami, idealna dla osób zajmujących się sztuką. Wyposażona w sztalugi, stoły do malowania i drewno do rzeźbienia. Świetna do zajęć z zakresu malarstwa, rzeźby i innych dziedzin plastycznych.\r\n\r\n",
                            Image = "sala-lekcyjna21.jpg",
                            Location_id = 1,
                            Name = "Pracownia plastyczna z przestrzenią do malowania\r\n",
                            Room_price = 25f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 22,
                            Capacity = 12,
                            Description = "Elegancka sala wykładowa o przestronnym układzie, wyposażona w projektor, ekran, system audio i klimatyzację. Wysokie sufity oraz przestronność sprawiają, że jest to doskonałe miejsce na większe wykłady, seminaria i kursy.\r\n\r\n",
                            Image = "sala-lekcyjna22.jpg",
                            Location_id = 1,
                            Name = "Sala wykładowa z klimatyzacją",
                            Room_price = 25f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 23,
                            Capacity = 12,
                            Description = "Sala z odpowiednim wyposażeniem do przeprowadzania eksperymentów z zakresu fizyki. Posiada stoły do eksperymentów, pomoce dydaktyczne oraz szafy do przechowywania sprzętu i materiałów. Idealna do naukowych zajęć praktycznych.\r\n\r\n",
                            Image = "sala-lekcyjna23.jpg",
                            Location_id = 1,
                            Name = "Sala laboratoryjna fizyczna\r\n",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 24,
                            Capacity = 24,
                            Description = "Nowoczesna sala, idealna do zajęć matematycznych, posiadająca tablicę interaktywną, projektor oraz ergonomiczne krzesła i biurka. Świetna do prowadzenia wykładów, ćwiczeń i rozwiązywania zadań matematycznych w grupach.\r\n\r\n",
                            Image = "sala-lekcyjna24.jpg",
                            Location_id = 1,
                            Name = "Pracownia matematyczna",
                            Room_price = 50f,
                            Type_id = 1
                        });
                });

            modelBuilder.Entity("RejestracjaSal.Models.RoomTypes", b =>
                {
                    b.Property<int>("Type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Type_id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Type_id");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Type_id = 1,
                            Name = "Sala naukowa"
                        },
                        new
                        {
                            Type_id = 2,
                            Name = "Sala komercyjna"
                        });
                });

            modelBuilder.Entity("RejestracjaSal.Models.Users", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.HasKey("User_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_id = 1,
                            Email = "Admin@gmail.com",
                            Login = "Admin",
                            Name = "Admin",
                            Password = "Admin",
                            Phone = 698785383,
                            Role_id = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
