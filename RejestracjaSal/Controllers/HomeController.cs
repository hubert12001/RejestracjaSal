using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Security.Claims;
using System.Xml.Linq;

namespace RejestracjaSal.Controllers
{
    public class HomeController : Controller
    {



        private CookieOptions options = new CookieOptions()
        {
            Domain = "localhost", // Set the domain for the cookie
            Path = "/", // Cookie is available within the entire application
            Expires = DateTime.Now.AddDays(1), // Set cookie expiration to 7 days from now
            Secure = false, // Ensure the cookie is only sent over HTTPS (set to false for local development)
            HttpOnly = false, // Prevent client-side scripts from accessing the cookie
            IsEssential = true // Indicates the cookie is essential for the application to function
        };


        private readonly ILogger<HomeController> _logger;

        AppDbContext AppDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            this.AppDbContext = appDbContext;
        }


        public IActionResult StronaGlowna()
        {
            List<string> types = AppDbContext.GetTypes();
            List<string> locations = AppDbContext.GetLocations();
            List<Users> users = AppDbContext.GetUsers();
            (object, int) pgroom = AppDbContext.FindRooms(12, 1);

            ViewBag.Rooms = pgroom.Item1;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalPages = pgroom.Item2;
            ViewBag.RoomTypes = types;
            ViewBag.Locations = locations;
            ViewBag.Users = users;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FindRoom(string find, int min, int max, string local, int capacity, string type, int pageNumber = 1, int pageSize = 12)
        {

            Console.WriteLine($"To jest lokal{local}");
            (object, int) pgroom = AppDbContext.FindRooms(pageSize, pageNumber, find, min, max, local, capacity, type);

            Dictionary<string, string> filerMap = new Dictionary<string, string>();
            filerMap.Add("find", find);
            filerMap.Add("cenaMin", min.ToString());
            filerMap.Add("cenaMax", max.ToString());
            filerMap.Add("local", local);
            filerMap.Add("capacity", capacity.ToString());
            filerMap.Add("type", type);

            ViewBag.Rooms = pgroom.Item1;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = pgroom.Item2;
            ViewBag.Filters = filerMap;

            List<string> types = AppDbContext.GetTypes();
            List<string> locations = AppDbContext.GetLocations();
            ViewBag.RoomTypes = types;
            ViewBag.Locations = locations;

            return View("StronaGlowna");
        }

        public IActionResult Pay(int reservationId)
        {
            AppDbContext.ReservationSetPaid(reservationId);
            return RedirectToAction("StaticSites", new { name = "Rezerwacje", pageNumber = 1, pageSize = 12 });
        }
        public IActionResult DeleteReservation(int reservationId)
        {
            AppDbContext.DeleteReservationById(reservationId);
            return RedirectToAction("StaticSites", new { name = "Rezerwacje", pageNumber = 1, pageSize = 12 });
        }
        public IActionResult StaticSites(string name, int pageNumber = 1, int pageSize = 12)
        {

            if (name == "StronaGlowna")
            {
                (object, int) pgroom = AppDbContext.FindRooms(pageSize, pageNumber);
                ViewBag.Rooms = pgroom.Item1;
                ViewBag.CurrentPage = pageNumber;
                ViewBag.TotalPages = pgroom.Item2;
                List<string> types = AppDbContext.GetTypes();
                List<string> locations = AppDbContext.GetLocations();

                ViewBag.RoomTypes = types;
                ViewBag.Locations = locations;

            }
            if (name == "Rezerwacje")
            {
                if (User.Identity.IsAuthenticated == true) {
                    int userId = AppDbContext.GetUserIdByName(User.FindFirst(ClaimTypes.Name)?.Value);
                    Console.WriteLine("TUATJATJAOTJWEAO JEWAOJTAWOGWEOW OEFBSI@!3128yr9efw7y9f" + userId.ToString());
                    int reservationId = AppDbContext.GetReservationIdByUserId(userId);
                    if (reservationId != 0)
                    {
                        (object, int, float) pgreservation = AppDbContext.GetReservationsById(reservationId, pageSize, pageNumber);
                        ViewBag.Reservation = pgreservation.Item1;
                        ViewBag.CurrentPage = pageNumber;
                        ViewBag.TotalPages = pgreservation.Item2;
                        ViewBag.TotalPrice = pgreservation.Item3;
                        ViewBag.ReservationId = reservationId;
                    }
                    else
                    {
                        ViewBag.Message = "Brak Rezerwacji";
                    }

                }
                else
                {
                    ViewBag.Message = "Musisz byc zalogowanym";
                }

            }
            if (name == "Admin_Uzytkownicy")
            {
                List<Users> users = AppDbContext.GetUsers();
                ViewBag.Users = users;
            }

            if (name == "Admin_Pokoje")
            {
                List<Rooms> room = AppDbContext.GetRooms();
                ViewBag.Rooms = room;
            }
            if (name == "Admin_Rezerwacje")
            {
                var reservations = (from rr in AppDbContext.ReservationsRooms
                                    join res in AppDbContext.Reservations on rr.Reservation_id equals res.Reservation_id
                                    join u in AppDbContext.Users on res.User_id equals u.User_id
                                    join r in AppDbContext.Rooms on rr.Room_id equals r.Room_id
                                    select new
                                    {
                                        ReservationId = rr.Reservation_id,
                                        UserName = u.Name,
                                        UserEmail = u.Email,
                                        RoomName = r.Name,
                                        StartDate = rr.Reservation_start_date,
                                        EndDate = rr.Reservation_end_date,
                                        Price = rr.Reservation_price
                                    }).ToList();

                ViewBag.AdminReservations = reservations;
            }




            return View(name);
        }

        public IActionResult Reservation(int roomid, DateTime startDate, DateTime endDate)
        {
            Rooms room = AppDbContext.GetRoomById(roomid);

            if (User.Identity.IsAuthenticated == true && AppDbContext.IsRoomAvaible(room.Room_id, startDate, endDate)==true)
            {
 


                int userId = AppDbContext.GetUserIdByName(User.FindFirst(ClaimTypes.Name)?.Value);
                AppDbContext.NewReservation(userId, room.Room_id, room.Room_price, startDate, endDate);

                ViewBag.message = "Rezerwacja zapisana";
            }
            else
            {
                ViewBag.message = "Sala zajêta";
            }
                var room1 = (from Rooms in AppDbContext.Rooms
                             join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                             join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                             where Rooms.Room_id == roomid
                             select new
                             {
                                 id = Rooms.Room_id,
                                 name = Rooms.Name,
                                 price = Rooms.Room_price,
                                 capacity = Rooms.Capacity,
                                 description = Rooms.Description,
                                 image = Rooms.Image,
                                 type = RoomTypes.Name,
                                 location = Locations.Name,
                             }).FirstOrDefault();

            ViewBag.Room = room1;
            return View("Pokoj");
        }
        [HttpGet]
        public IActionResult GetAll(int roomId)
        {
            var events = AppDbContext.ReservationsRooms
                .Where(r => r.Room_id == roomId)
                .Select(r => new {
                    title = "Zajête",              
                    start = r.Reservation_start_date.ToString("s"), // ISO-format
                    end = r.Reservation_end_date.ToString("s"),
                    display = "background"            
                })
                .ToList();

            return Json(events);
        }

        public IActionResult Pokoj(int id)
        {



            var room = (from Rooms in AppDbContext.Rooms
                        join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                        join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                        where Rooms.Room_id == id
                        select new
                        {
                            id = Rooms.Room_id,
                            name = Rooms.Name,
                            price = Rooms.Room_price,
                            capacity = Rooms.Capacity,
                            description = Rooms.Description,
                            image = Rooms.Image,
                            type = RoomTypes.Name,
                            location = Locations.Name,
                        }).FirstOrDefault();
          
            if (room == null)
            {
                return NotFound();
            }


            ViewBag.Room = room;
            return View("Pokoj");
        }

        public IActionResult EdycjaUzytkownicy(int id)
        {
            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == id);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.User = user;
            return View("Edycja_Uzytkownicy");
        }
        public IActionResult EdycjaPokoji(int id)
        {
            var room = AppDbContext.Rooms.FirstOrDefault(r => r.Room_id == id);

            if (room == null)
            {
                return NotFound();
            }

            ViewBag.Room = room;
            return View("Edycja_Pokoji");
        }
        public IActionResult EdycjaRezerwacji(int id)
        {
            var reservation = AppDbContext.Rooms.FirstOrDefault(r => r.Room_id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            ViewBag.Room = reservation;
            return View("Edycja_Pokoji");
        }

        [HttpPost]
        public IActionResult EdycjaUzytkownicyPost(int User_id, string Name, string Email, string Phone, int Role_id, string Login, string Password)
        {
            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == User_id);
            if (user != null)
            {
                user.Name = Name;
                user.Email = Email;
                user.Phone = Phone;
                user.Role_id = Role_id;
                user.Login = Login;
                user.Password = Password;
                AppDbContext.SaveChanges();
            }

            return RedirectToAction("StaticSites", new { name = "Admin_Uzytkownicy" });
        }
        [HttpPost]
        public IActionResult EdycjaPokojiPost(int Room_id, string Name, int Capacity, string Description, float Room_price)
        {
            var room = AppDbContext.Rooms.FirstOrDefault(r => r.Room_id == Room_id);
            if (room != null)
            {
                room.Name = Name;
                room.Capacity = Capacity;
                room.Description = Description;
                room.Room_price = Room_price;
                AppDbContext.SaveChanges();
            }

            return RedirectToAction("StaticSites", new { name = "Admin_Pokoje" });
        }

        public IActionResult BanUser(int id)
        {

            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == id);
            if (user != null)
            {
                user.Role_id = 1; // Ustawiamy rolê "Zbanowany" (Role_id = 1)
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("StaticSites", new { name = "Admin_Uzytkownicy" });
        }

        public IActionResult UnbanUser(int id)
        {
            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == id);
            if (user != null)
            {
                user.Role_id = 2; // Ustawiamy rolê "Zwyk³y u¿ytkownik" (Role_id = 2)
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("StaticSites", new { name = "Admin_Uzytkownicy" });
        }

        public IActionResult UsunPokoj(int id)
        {
            var room = AppDbContext.Rooms.FirstOrDefault(r => r.Room_id == id);
            if (room != null)
            {
                AppDbContext.Rooms.Remove(room);
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("StaticSites", new { name = "Admin_Pokoje" });
        }

        [HttpPost]
        public IActionResult DodajPokojPost(string Name, int Capacity, int Location_id, int Type_id, float Room_price, string Description, string Image)
        {
            var newRoom = new Rooms
            {
                Name = Name,
                Capacity = Capacity,
                Location_id = Location_id,
                Type_id = Type_id,
                Room_price = Room_price,
                Description = Description,
                Image = Image
            };

            AppDbContext.Rooms.Add(newRoom);
            AppDbContext.SaveChanges();

            return RedirectToAction("StaticSites", new { name = "Admin_Pokoje" });
        }

    }
}