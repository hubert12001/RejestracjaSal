using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace RejestracjaSal.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet <Users> Users { get; set; }
        public DbSet <Locations> Locations { get; set; }
        public DbSet <RoomTypes> RoomTypes { get; set; }
        public DbSet <Rooms> Rooms { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
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
                }
            };
            List<Rooms> rooms = new List<Rooms>
            {
                new Rooms()
                {
                    Room_id = 1,
                    Name = "Sala 31",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna1.png"

                },
                new Rooms()
                {
                    Room_id = 2,
                    Name = "Sala 32",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna2.png"

                },
                new Rooms()
                {
                    Room_id = 3,
                    Name = "Sala 33",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna3.png"

                },
                new Rooms()
                {
                    Room_id = 4,
                    Name = "Sala 34",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna4.png"

                },
                new Rooms()
                {
                    Room_id = 5,
                    Name = "Sala 35",
                    Capacity = 16,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 25,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna5.png"

                },
                new Rooms()
                {
                    Room_id = 6,
                    Name = "Sala 36",
                    Capacity = 20,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 35,
                    Description = "Trzecie pietro",
                    Image = "sala-lekcyjna6.png"

                },
                new Rooms()
                {
                    Room_id = 7,
                    Name = "Sala 21",
                    Capacity = 48,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 100,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna7.png"

                },
                new Rooms()
                {
                    Room_id = 8,
                    Name = "Sala 22",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna8.png"

                },
                new Rooms()
                {
                    Room_id = 9,
                    Name = "Sala 23",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna9.png"

                },
                new Rooms()
                {
                    Room_id = 10,
                    Name = "Sala 24",
                    Capacity = 10,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 15,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna10.png"

                },
                new Rooms()
                {
                    Room_id = 11,
                    Name = "Sala 25",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 35,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna11.png"

                },
                new Rooms()
                {
                    Room_id = 12,
                    Name = "Sala 26",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 35,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna12.png"

                },
                new Rooms()
                {
                    Room_id = 13,
                    Name = "Sala 27",
                    Capacity = 30,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 65,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna13.png"

                },
                new Rooms()
                {
                    Room_id = 14,
                    Name = "Sala 28",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 80,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna14.png"

                },
                new Rooms()
                {
                    Room_id = 15,
                    Name = "Sala 11",
                    Capacity = 36,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna15.png"

                },
                new Rooms()
                {
                    Room_id = 16,
                    Name = "Sala 12",
                    Capacity = 18,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna16.png"

                },
                new Rooms()
                {
                    Room_id = 17,
                    Name = "Sala 13",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna17.png"

                },
                new Rooms()
                {
                    Room_id = 18,
                    Name = "Sala 14",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 46,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna18.png"

                },
                new Rooms()
                {
                    Room_id = 19,
                    Name = "Sala 15",
                    Capacity = 28,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 75,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna19.png"

                },
                new Rooms()
                {
                    Room_id = 20,
                    Name = "Sala 16",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna20.png"

                },
                new Rooms()
                {
                    Room_id = 21,
                    Name = "Sala 17",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 25,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna21.png"

                },
                new Rooms()
                {
                    Room_id = 22,
                    Name = "Sala 18",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 25,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna22.png"

                },
                new Rooms()
                {
                    Room_id = 23,
                    Name = "Sala 19",
                    Capacity = 12,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Pierwsze pietro",
                    Image = "sala-lekcyjna23.png"

                },
                new Rooms()
                {
                    Room_id = 24,
                    Name = "Sala 20",
                    Capacity = 24,
                    Location_id = 1,
                    Type_id = 1,
                    Room_price = 50,
                    Description = "Drugie pietro",
                    Image = "sala-lekcyjna24.png"

                }
            };

            modelBuilder.Entity<Users>().HasData(users);
            modelBuilder.Entity<Locations>().HasData(locations);
            modelBuilder.Entity<RoomTypes>().HasData(roomTypes);
            modelBuilder.Entity<Rooms>().HasData(rooms);
        }
    }
}
