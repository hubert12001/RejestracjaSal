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
    [Migration("20250331154832_nazwy-sal")]
    partial class nazwysal
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
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna1.png",
                            Location_id = 1,
                            Name = "Sala 31",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 2,
                            Capacity = 24,
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna2.png",
                            Location_id = 1,
                            Name = "Sala 32",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 3,
                            Capacity = 24,
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna3.png",
                            Location_id = 1,
                            Name = "Sala 33",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 4,
                            Capacity = 36,
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna4.png",
                            Location_id = 1,
                            Name = "Sala 34",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 5,
                            Capacity = 16,
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna5.png",
                            Location_id = 1,
                            Name = "Sala 35",
                            Room_price = 25f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 6,
                            Capacity = 20,
                            Description = "Trzecie pietro",
                            Image = "sala-lekcyjna6.png",
                            Location_id = 1,
                            Name = "Sala 36",
                            Room_price = 35f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 7,
                            Capacity = 48,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna7.png",
                            Location_id = 1,
                            Name = "Sala 21",
                            Room_price = 100f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 8,
                            Capacity = 24,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna8.png",
                            Location_id = 1,
                            Name = "Sala 22",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 9,
                            Capacity = 24,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna9.png",
                            Location_id = 1,
                            Name = "Sala 23",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 10,
                            Capacity = 10,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna10.png",
                            Location_id = 1,
                            Name = "Sala 24",
                            Room_price = 15f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 11,
                            Capacity = 18,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna11.png",
                            Location_id = 1,
                            Name = "Sala 25",
                            Room_price = 35f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 12,
                            Capacity = 18,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna12.png",
                            Location_id = 1,
                            Name = "Sala 26",
                            Room_price = 35f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 13,
                            Capacity = 30,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna13.png",
                            Location_id = 1,
                            Name = "Sala 27",
                            Room_price = 65f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 14,
                            Capacity = 36,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna14.png",
                            Location_id = 1,
                            Name = "Sala 28",
                            Room_price = 80f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 15,
                            Capacity = 36,
                            Description = "Przestronna aula o klasycznym układzie, idealna na wykłady, seminaria i konferencje. Pomieszczenie wyposażone jest w projektor, duży ekran oraz nagłośnienie. Wysokie okna zapewniają dużo naturalnego światła, a zabytkowe drewniane ławki dodają wyjątkowego klimatu.\r\n\r\n",
                            Image = "sala-lekcyjna15.png",
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
                            Image = "sala-lekcyjna16.png",
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
                            Image = "sala-lekcyjna18.png",
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
                            Image = "sala-lekcyjna19.png",
                            Location_id = 1,
                            Name = "Sala konferencyjna z widokiem na dziedziniec",
                            Room_price = 75f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 20,
                            Capacity = 24,
                            Description = "Pierwsze pietro",
                            Image = "sala-lekcyjna20.png",
                            Location_id = 1,
                            Name = "Sala 16",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 21,
                            Capacity = 12,
                            Description = "Pierwsze pietro",
                            Image = "sala-lekcyjna21.png",
                            Location_id = 1,
                            Name = "Sala 17",
                            Room_price = 25f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 22,
                            Capacity = 12,
                            Description = "Pierwsze pietro",
                            Image = "sala-lekcyjna22.png",
                            Location_id = 1,
                            Name = "Sala 18",
                            Room_price = 25f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 23,
                            Capacity = 12,
                            Description = "Pierwsze pietro",
                            Image = "sala-lekcyjna23.png",
                            Location_id = 1,
                            Name = "Sala 19",
                            Room_price = 50f,
                            Type_id = 1
                        },
                        new
                        {
                            Room_id = 24,
                            Capacity = 24,
                            Description = "Drugie pietro",
                            Image = "sala-lekcyjna24.png",
                            Location_id = 1,
                            Name = "Sala 20",
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
