using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;

namespace RejestracjaSal.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<RoomTypes> RoomTypes { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Reservations_Rooms> ReservationsRooms { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public (object, int) FindRooms(int pageSize, int pageNumber, string find = "",
                                       int min = 0, int max = 0, string local = "",
                                       int capacity = 0, string type = "")
        {
            var query = from rooms in Rooms
                        join roomTypes in RoomTypes on rooms.Type_id equals roomTypes.Type_id
                        join locations in Locations on rooms.Location_id equals locations.Location_id
                        select new
                        {
                            id = rooms.Room_id,
                            name = rooms.Name,
                            price = rooms.Room_price,
                            capacity = rooms.Capacity,
                            description = rooms.Description,
                            image = rooms.Image,
                            type = roomTypes.Name,
                            location = locations.Name,
                        };
            if (!String.IsNullOrEmpty(find))
            {
                query = query.Where(r => r.name.Trim().ToLower().Contains(find.Trim().ToLower()));

            }
            if (min >= 0 && max > 0)
            {
                query = query.Where(r => r.price >= min && r.price <= max);
            }
            if (!String.IsNullOrEmpty(local))
            {
                query = query.Where(r => r.location.Trim().ToLower().Contains(local.Trim().ToLower()));
            }
            if (capacity >= 0)
            {
                query = query.Where(r => r.capacity >= capacity);
            }
            if (!String.IsNullOrEmpty(type))
            {
                query = query.Where(r => r.type.Trim().ToLower().Contains(type.Trim().ToLower()));
            }

            int totalRooms = query.Count();
            int totalPages = (int)Math.Ceiling(totalRooms / (double)pageSize);
            var pagedRooms = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            (object, int) result = (pagedRooms, totalPages);
            return result;
        }

        public List<string> GetTypes()
        {
            var query = from roomTypes in RoomTypes select roomTypes.Name;

            return query.ToList();
        }
        public List<Users> GetUsers()
        {
            var query = from users in Users select users;

            return query.ToList();
        }
        public List<string> GetLocations()
        {
            var query = from locations in Locations select locations.Name;
            List<string> l = new List<string>();

            return query.ToList();
        }
        public int GetUserIdByName(string name)
        {
            var query = Users
                .Where(u => u.Name == name)
                .FirstOrDefault();
            return query.User_id;
        }
        public Rooms GetRoomById(int roomId)
        {
            var query = Rooms
                .Where(r => r.Room_id == roomId)
                .SingleOrDefault();
            return query;
        }

        public bool IsRoomAvaible(int roomId, DateTime startDate, DateTime endDate)
        {
            var isOverlapping = ReservationsRooms
                .Any(r =>
                    r.Room_id == roomId &&
                    startDate < r.Reservation_end_date &&
                    endDate > r.Reservation_start_date
                );

            return !isOverlapping;
        }

        public void DeleteReservationById(int reservationId)
        {
            var reservation = ReservationsRooms.FirstOrDefault(r => r.ReservationRoom_Id == reservationId);

            if (reservation != null)
            {
                ReservationsRooms.Remove(reservation);
                SaveChanges();
                Console.WriteLine($"Reservation {reservationId} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Reservation with ID {reservationId} not found.");
            }
        }
        
        public int GetReservationIdByUserId(int userId)
        {
            var query = Reservations.Where(r => r.User_id == userId && r.Paid == false).FirstOrDefault();
            if(query != null)
            {
                return query.Reservation_id;

            }
            return 0;
        }
        public void ReservationSetTotal(int reservationId, float total)
        {
            var reservation = Reservations.FirstOrDefault(r => r.Reservation_id == reservationId);

            if (reservation != null)
            {
                reservation.Total_price = total;
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"Reservation with ID {reservationId} not found.");
            }
        }
        public void ReservationSetPaid(int reservationId)
        {
            var reservation = Reservations.FirstOrDefault(r => r.Reservation_id == reservationId);

            if (reservation != null)
            {
                reservation.Paid = true;
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"Reservation with ID {reservationId} not found.");
            }
        }
        public (object, int, float) GetReservationsById(int ReservationId, int pageSize, int pageNumber)
        {
            var query = from reservationRooms in ReservationsRooms
                        join rooms in Rooms on reservationRooms.Room_id equals rooms.Room_id
                        where reservationRooms.Reservation_id == ReservationId
                        select new
                        {
                            id = reservationRooms.ReservationRoom_Id,
                            roomId = reservationRooms.Room_id,
                            name = rooms.Name,
                            image = rooms.Image,
                            startDate = reservationRooms.Reservation_start_date,
                            endDate = reservationRooms.Reservation_end_date,
                            price = reservationRooms.Reservation_price
                        };
            
            int totalReservations = query.Count();
            int totalPages = (int)Math.Ceiling(totalReservations / (double)pageSize);

            var reservationList = query.ToList();
            float totalPrice = reservationList.Sum(x => x.price);

            ReservationSetTotal(ReservationId, totalPrice);
            return (reservationList.Skip((pageNumber - 1) * pageSize).Take(pageSize),totalPages, totalPrice);
        }
        public void NewReservation(int userId, int roomId, float roomPrice, DateTime startDate, DateTime endDate)
        {
            TimeSpan time = endDate - startDate;
            Console.WriteLine($"DLACZEGO {time.TotalHours}");
            if (time.TotalHours > 0)
            {
                var query = Reservations
                .Where(r => r.User_id == userId && r.Paid == false)
                .FirstOrDefault();

                if (query == null)
                {
                    var reservation = new Reservations
                    {
                        User_id = userId,
                        Total_price = 0,
                        Paid = false
                    };

                    Reservations.Add(reservation);
                    SaveChanges();

                    query = reservation;
                }



                var resRoom = new Reservations_Rooms
                {

                    Reservation_id = query.Reservation_id,
                    Room_id = roomId,
                    Reservation_start_date = startDate,
                    Reservation_end_date = endDate,
                    Reservation_price = roomPrice*(float)Math.Ceiling(time.TotalHours),
                };

                ReservationsRooms.Add(resRoom);
                SaveChanges();

            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Users> users = new List<Users>
            {
                new Users()
                {
                    User_id = 1,
                    Name = "Admin",
                    Email = "Admin@gmail.com",
                    Phone = 698785383,
                    Role_id = 2,
                    Login = "Admin",
                    Password = "Admin"

                }
            };
            List<Locations> locations = new List<Locations>
            {
                new Locations()
                {
                    Location_id = 1,
                    Name = "Gimnazjum",
                    Bulding_code = "B01",
                    City = "Bydgoszcz",
                    Street = "Kamienna 5",
                    Zip_code = "35-705",
                    Description = "Wejśćie tylnymi drzwiam"
                }
            };
            List<RoomTypes> roomTypes = new List<RoomTypes>
            {
                new RoomTypes()
                {
                    Type_id = 1,
                    Name = "Sala naukowa"
                },
                new RoomTypes()
                {
                    Type_id = 2,
                    Name = "Sala komercyjna"
                }
            };
            List<Rooms> rooms = new List<Rooms>
            {
                new Rooms()
                {
                    Room_id = 1,
                    Name = "Sala dyskusyjna",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Kameralna sala przeznaczona na seminaria, spotkania grupowe i zajęcia dydaktyczne. Układ stołów w podkowę sprzyja dyskusjom i interaktywnej pracy. Wyposażona w ekran projekcyjny, flipchart oraz system nagłośnienia.",
                    Image = "sala-lekcyjna1.jpg"

                },
                new Rooms()
                {
                    Room_id = 2,
                    Name = "Pracownia językowa",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Nowoczesna sala stworzona z myślą o nauce języków obcych. Każde stanowisko wyposażone jest w słuchawki i mikrofon, a centralny system audio umożliwia prowadzenie ćwiczeń z wymową i odsłuchami. Dodatkowo dostępna jest tablica interaktywna.\r\n\r\n",
                    Image = "sala-lekcyjna2.jpg"

                },
                new Rooms()
                {
                    Room_id = 3,
                    Name = "Multimedialne laboratorium",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Sala dostosowana do zajęć wymagających dostępu do nowoczesnych technologii. Wyposażona w komputery, tablety oraz zestawy VR, pozwala na prowadzenie interaktywnych zajęć i warsztatów. Przestrzeń modułowa umożliwia różne ustawienia stanowisk.\r\n\r\n",
                    Image = "sala-lekcyjna3.jpg"

                },
                new Rooms()
                {
                    Room_id = 4,
                    Name = "Historyczna aula konferencyjna",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Stylowa sala z wysokim sufitem i zachowanymi elementami architektonicznymi dawnego gimnazjum. Idealna na wykłady, prezentacje i spotkania formalne. Oferuje duży ekran projekcyjny, drewniane ławy i oryginalne zdobienia ścian, nadające jej wyjątkowy charakter.\r\n\r\n",
                    Image = "sala-lekcyjna4.jpg"

                },
                new Rooms()
                {
                    Room_id = 5,
                    Name = "Studio nagraniowe i montażowe",
                    Capacity = 16,
                    Location_id = 1,
                    Type_id = 2,
                    Room_price = 25,
                    Description = "Specjalistyczna sala przeznaczona dla osób zajmujących się nagrywaniem i obróbką dźwięku. Wyposażona w profesjonalny sprzęt nagraniowy, mikrofony, wygłuszone ściany oraz stanowiska montażowe. Idealna dla podcasterów, lektorów i realizatorów dźwięku.\r\n\r\n",
                    Image = "sala-lekcyjna5.jpg"

                },
                new Rooms()
                {
                    Room_id = 6,
                    Name = "Przestrzeń coworkingowa\r\n",
                    Capacity = 20,
                    Location_id = 1,
                    Type_id = 2,
                    Room_price = 35,
                    Description = "Nowoczesna, otwarta sala dostosowana do pracy zespołowej i indywidualnej. Wyposażona w biurka, wygodne fotele oraz liczne punkty zasilania. Dostępna szybka sieć Wi-Fi, tablica magnetyczna oraz kącik relaksu z sofą i ekspresem do kawy.\r\n\r\n",
                    Image = "sala-lekcyjna6.jpg"

                },
                new Rooms()
                {
                    Room_id = 7,
                    Name = "Pracownia artystyczna",
                    Capacity = 48,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 100,
                    Description = "Jasne, przestronne pomieszczenie z dużymi oknami i stołami przystosowanymi do pracy twórczej. Sala idealna dla zajęć plastycznych, warsztatów rzemieślniczych i projektów artystycznych. Wyposażona w sztalugi, tablicę korkową i szafki na materiały.\r\n\r\n",
                    Image = "sala-lekcyjna7.jpg"

                },
                new Rooms()
                {
                    Room_id = 8,
                    Name = "Sala wykładowa z komputerami\r\n",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Nowoczesna sala z układem amfiteatralnym, idealna do prowadzenia wykładów, prelekcji i prezentacji. Wyposażona w projektor, ekran oraz stanowiska komputerowe, które umożliwiają interaktywne zajęcia. Wysokie okna zapewniają doskonałe doświetlenie naturalnym światłem.\r\n\r\n",
                    Image = "sala-lekcyjna8.jpg"

                },
                new Rooms()
                {
                    Room_id = 9,
                    Name = "Sala spotkań seminaryjnych",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Kameralna sala, która doskonale sprawdza się w roli miejsca do przeprowadzania seminariów, spotkań dyskusyjnych i zajęć w mniejszych grupach. Wyposażona w projektor, ekran oraz komfortowe krzesła i stoły, które można dowolnie ustawiać w zależności od potrzeb.\r\n\r\n",
                    Image = "sala-lekcyjna9.jpg"

                },
                new Rooms()
                {
                    Room_id = 10,
                    Name = "Pracownia biologiczna",
                    Capacity = 10,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 15,
                    Description = "Sala specjalistyczna, przystosowana do zajęć laboratoryjnych z zakresu biologii. Wyposażona w stoły laboratoryjne, mikroskopy, szafy na odczynniki oraz system wentylacyjny. Idealna do przeprowadzania eksperymentów, badań i analiz.\r\n\r\n",
                    Image = "sala-lekcyjna10.jpg"

                },
                new Rooms()
                {
                    Room_id = 11,
                    Name = "Sala projektowa z tablicą interaktywną\r\n",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 35,
                    Description = "Idealna do spotkań projektowych i burz mózgów. Sala wyposażona w nowoczesną tablicę interaktywną, rzutnik oraz stoliki do pracy grupowej. Przestronna, z dużą ilością światła dziennego, sprzyja kreatywnej pracy i efektywnej wymianie pomysłów.\r\n\r\n",
                    Image = "sala-lekcyjna11.jpg"

                },
                new Rooms()
                {
                    Room_id = 12,
                    Name = "Pracownia chemiczna",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 35,
                    Description = "Dobrze wyposażona sala laboratoryjna, przeznaczona do zajęć chemicznych. Posiada specjalistyczne stoły z dostępem do wody, gazu i prądu, a także szafy na odczynniki chemiczne. Świetnie nadaje się do przeprowadzania eksperymentów i badań chemicznych.\r\n\r\n",
                    Image = "sala-lekcyjna12.jpg"

                },
                new Rooms()
                {
                    Room_id = 13,
                    Name = "Sala dydaktyczna z układem kinowym\r\n",
                    Capacity = 30,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 65,
                    Description = "Aula z ustawieniem w układzie kinowym, idealna na projekcje filmowe, wykłady lub szkolenia. Posiada duży ekran, projektor, system nagłośnienia i komfortowe fotele. Doskonałe miejsce do nauki z elementami multimedialnymi.\r\n\r\n",
                    Image = "sala-lekcyjna13.jpg"

                },
                new Rooms()
                {
                    Room_id = 14,
                    Name = "Sala komputerowa z dostępem do internetu",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 80,
                    Description = "W pełni wyposażona sala komputerowa z dostępem do internetu. Każde stanowisko ma zainstalowane oprogramowanie edukacyjne, co czyni ją idealnym miejscem do zajęć informatycznych, szkoleń i warsztatów praktycznych. Sala jest przestronna i dobrze doświetlona.\r\n\r\n",
                    Image = "sala-lekcyjna14.jpg"

                },
                new Rooms()
                {
                    Room_id = 15,
                    Name = "Klasyczna aula wykładowa",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Przestronna aula o klasycznym układzie, idealna na wykłady, seminaria i konferencje. Pomieszczenie wyposażone jest w projektor, duży ekran oraz nagłośnienie. Wysokie okna zapewniają dużo naturalnego światła, a zabytkowe drewniane ławki dodają wyjątkowego klimatu.\r\n\r\n",
                    Image = "sala-lekcyjna15.jpg"

                },
                new Rooms()
                {
                    Room_id = 16,
                    Name = "Kameralna sala warsztatowa",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Średniej wielkości sala doskonała na warsztaty, spotkania i zajęcia w mniejszych grupach. Wyposażona w tablicę suchościeralną, rzutnik oraz ruchome stoły i krzesła, umożliwiające dowolną aranżację przestrzeni. Klimatyczna ceglana ściana przypomina o historii budynku.\r\n\r\n",
                    Image = "sala-lekcyjna16.jpg"

                },
                new Rooms()
                {
                    Room_id = 17,
                    Name = "Nowoczesna sala komputerowa",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Przystosowana do zajęć informatycznych sala z nowoczesnym sprzętem. Każde stanowisko wyposażone jest w komputer z szybkim dostępem do internetu. Dodatkowo sala oferuje tablicę interaktywną oraz ergonomiczne krzesła zapewniające komfort nawet podczas dłuższych zajęć.\r\n\r\n",
                    Image = "sala-lekcyjna17.jpg"

                },
                new Rooms()
                {
                    Room_id = 18,
                    Name = "Przestrzeń kreatywna",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 46,
                    Description = "Nowoczesna sala przystosowana do spotkań projektowych i kreatywnych sesji. Posiada wygodne fotele, stoły konferencyjne oraz ściany pokryte farbą suchościeralną, umożliwiającą zapisywanie pomysłów. Dobre oświetlenie i industrialny charakter wnętrza sprzyjają twórczej pracy.",
                    Image = "sala-lekcyjna18.jpg"

                },
                new Rooms()
                {
                    Room_id = 19,
                    Name = "Sala konferencyjna z widokiem na dziedziniec",
                    Capacity = 28,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Elegancka, przestronna sala idealna na zebrania, prelekcje i spotkania biznesowe. Duże okna wychodzą na wewnętrzny dziedziniec, zapewniając piękny widok i dużo światła dziennego. Pomieszczenie wyposażone jest w ekran, projektor oraz system nagłośnienia.",
                    Image = "sala-lekcyjna19.jpg"

                },
                new Rooms()
                {
                    Room_id = 20,
                    Name = "Sala konferencyjna z telebimem",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Elegancka sala konferencyjna, wyposażona w duży telebim oraz system audio. Doskonała do przeprowadzania prezentacji, spotkań biznesowych i konferencji. Wysokiej jakości wykończenia wnętrz oraz wygodne fotele zapewniają komfort podczas długotrwałych spotkań.\r\n\r\n",
                    Image = "sala-lekcyjna20.jpg"

                },
                new Rooms()
                {
                    Room_id = 21,
                    Name = "Pracownia plastyczna z przestrzenią do malowania\r\n",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 25,
                    Description = "Przestronna sala z dużymi oknami, idealna dla osób zajmujących się sztuką. Wyposażona w sztalugi, stoły do malowania i drewno do rzeźbienia. Świetna do zajęć z zakresu malarstwa, rzeźby i innych dziedzin plastycznych.\r\n\r\n",
                    Image = "sala-lekcyjna21.jpg"

                },
                new Rooms()
                {
                    Room_id = 22,
                    Name = "Sala wykładowa z klimatyzacją",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 25,
                    Description = "Elegancka sala wykładowa o przestronnym układzie, wyposażona w projektor, ekran, system audio i klimatyzację. Wysokie sufity oraz przestronność sprawiają, że jest to doskonałe miejsce na większe wykłady, seminaria i kursy.\r\n\r\n",
                    Image = "sala-lekcyjna22.jpg"

                },
                new Rooms()
                {
                    Room_id = 23,
                    Name = "Sala laboratoryjna fizyczna\r\n",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Sala z odpowiednim wyposażeniem do przeprowadzania eksperymentów z zakresu fizyki. Posiada stoły do eksperymentów, pomoce dydaktyczne oraz szafy do przechowywania sprzętu i materiałów. Idealna do naukowych zajęć praktycznych.\r\n\r\n",
                    Image = "sala-lekcyjna23.jpg"

                },
                new Rooms()
                {
                    Room_id = 24,
                    Name = "Pracownia matematyczna",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Nowoczesna sala, idealna do zajęć matematycznych, posiadająca tablicę interaktywną, projektor oraz ergonomiczne krzesła i biurka. Świetna do prowadzenia wykładów, ćwiczeń i rozwiązywania zadań matematycznych w grupach.\r\n\r\n",
                    Image = "sala-lekcyjna24.jpg"

                }
            };

            modelBuilder.Entity<Users>().HasData(users);
            modelBuilder.Entity<Locations>().HasData(locations);
            modelBuilder.Entity<RoomTypes>().HasData(roomTypes);
            modelBuilder.Entity<Rooms>().HasData(rooms);
            modelBuilder.Entity<Reservations>();
            modelBuilder.Entity<Reservations_Rooms>();
        }
    }
}