using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Diagnostics;
using System.Drawing.Printing;
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
            string? cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                ViewBag.name = Request.Cookies["login"];
            }
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
            Console.WriteLine($"PAYPAYPAYPAYP {reservationId}.");
            AppDbContext.ReservationSetPaid(reservationId);
            return RedirectToAction("StaticSites", new { name = "Rezerwacje", pageNumber = 1, pageSize = 12 });
        }
        public IActionResult DeleteReservation(int reservationId)
        {
            Console.WriteLine($"DELELELDELDELDEDE {reservationId} not found.");
            AppDbContext.DeleteReservationById(reservationId);
            return RedirectToAction("StaticSites", new { name = "Rezerwacje", pageNumber = 1, pageSize = 12 });
        }
        public IActionResult StaticSites(string name, int pageNumber = 1, int pageSize = 12)
        {

            string? roleCookie = Request.Cookies["roleId"];
            string? cookie = Request.Cookies["login"];

            if (cookie != null)
            {
                ViewBag.name = Request.Cookies["login"];
            }

            if (roleCookie != null)
            {
                ViewBag.role = Request.Cookies["roleId"];
            }

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
                int userId = AppDbContext.GetUserIdByName(Request.Cookies["login"]);
                int reservationId = AppDbContext.GetReservationIdByUserId(userId); 
                if(reservationId != 0)
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
            if (name == "Administrator")
            {
                List<Users> users = AppDbContext.GetUsers();
                ViewBag.Users = users;
            }


            return View(name);
        }

        public IActionResult Reservation(int roomid, DateTime startDate, DateTime endDate)
        {
            Rooms room = AppDbContext.GetRoomById(roomid);

            string? cookie = Request.Cookies["login"];
            if (cookie != null && AppDbContext.IsRoomAvaible(room.Room_id, startDate, endDate)==true)
            {
                ViewBag.name = Request.Cookies["login"];


                int userId = AppDbContext.GetUserIdByName(Request.Cookies["login"]);
                AppDbContext.NewReservation(userId, room.Room_id, room.Room_price, startDate, endDate);
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


        public IActionResult Pokoj(int id)
        {

            string? cookie = Request.Cookies["login"];

            if (cookie != null)
            {
                ViewBag.name = Request.Cookies["login"];
            }


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
        public IActionResult BanUser(int id)
        {

            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == id);
            if (user != null)
            {
                user.Role_id = 1; // Ustawiamy rolê "Zbanowany" (Role_id = 1)
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("StaticSites", new { name = "Administrator" });
        }

        public IActionResult UnbanUser(int id)
        {
            var user = AppDbContext.Users.FirstOrDefault(u => u.User_id == id);
            if (user != null)
            {
                user.Role_id = 2; // Ustawiamy rolê "Zwyk³y u¿ytkownik" (Role_id = 2)
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("StaticSites", new { name = "Administrator" });
        }

    }
}