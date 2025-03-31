using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace RejestracjaSal.Controllers
{
    public class HomeController : Controller
    {


        private 

        CookieOptions options = new CookieOptions()
        {
            Domain = "localhost", // Set the domain for the cookie
            Path = "/", // Cookie is available within the entire application
            Expires = DateTime.Now.AddDays(7), // Set cookie expiration to 7 days from now
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
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            IQueryable<Users> myUsers = from user in AppDbContext.Users
                                       where user.Login == login && user.Password == password
                                       select user;
            Users users = myUsers.FirstOrDefault();
            if (myUsers.Any())
            {
                var query = from Rooms in AppDbContext.Rooms
                            join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                            join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                            orderby Rooms.Name  // Dodano sortowanie
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
                            };
                int totalRooms = query.Count();
                int totalPages = (int)Math.Ceiling(totalRooms / (double)12);

                var pagedRooms = query
                    .Skip((1 - 1) * 12)
                    .Take(12)
                    .ToList();
                ViewBag.Rooms = pagedRooms;
                ViewBag.CurrentPage = 1;
                ViewBag.TotalPages = totalPages;   


            Response.Cookies.Append("login", users.Name, options);

                ViewBag.name = users.Name;
                return View("StronaGlowna");
            }
            else
            {
                ViewBag.message = "Konto o Podanym loginie i haœle nie istnieje";
                return View("Logowanie");
            }
        }
        [HttpPost]
        public IActionResult Register(string login, string password, string repeatPassword, 
                                      string email, string username, string phone)
        {
            Users newUser;



            if (password== repeatPassword)
            {
                if (phone != null)
                {
                    newUser = new Users
                    {
                        Name = "Admin",
                        Email = email,
                        Phone = Int32.Parse(phone),
                        Role_id = 1,
                        Login = login,
                        Password = password
                    };
                }
                else {
                    newUser = new Users
                    {
                        Name = "Admin",
                        Email = email,
                        Role_id = 1,
                        Login = login,
                        Password = password
                    };
                }

                var query = from Rooms in AppDbContext.Rooms
                            join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                            join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                            orderby Rooms.Name  // Dodano sortowanie
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
                            };
                int totalRooms = query.Count();
                int totalPages = (int)Math.Ceiling(totalRooms / (double)12);
                var pagedRooms = query
                    .Skip((1 - 1) * 12)
                    .Take(12)
                    .ToList();
                ViewBag.Rooms = pagedRooms;
                ViewBag.CurrentPage = 1;
                ViewBag.TotalPages = totalPages;
                AppDbContext.Users.Add(newUser);
                AppDbContext.SaveChanges();
                Response.Cookies.Append("login", newUser.Name, options);
                return View("StronaGlowna");
            }

            ViewBag.message = "Has³a siê niezgadzaj¹";
            return View("Rejestracja");
            
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("login", options);
            return View("Logowanie");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StaticSites(string name, int pageNumber = 1, int pageSize = 12)
        {

            string cookie = Request.Cookies["login"];
            if (cookie != null) {
                ViewBag.name = Request.Cookies["login"];
            }

            if (name == "StronaGlowna")
            {
                var query = from Rooms in AppDbContext.Rooms
                        join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                        join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                        orderby Rooms.Name  // Dodano sortowanie
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
                        };
            int totalRooms = query.Count();
            int totalPages = (int)Math.Ceiling(totalRooms / (double)pageSize);

            var pagedRooms = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                ViewBag.Rooms = pagedRooms;
                ViewBag.CurrentPage = pageNumber;
                ViewBag.TotalPages = totalPages;
            }

            return View(name);
        }

        public IActionResult Pokoj(int id)
        {
            var room = (from Rooms in AppDbContext.Rooms
                        join RoomTypes in AppDbContext.RoomTypes on Rooms.Type_id equals RoomTypes.Type_id
                        join Locations in AppDbContext.Locations on Rooms.Location_id equals Locations.Location_id
                        where Rooms.Room_id == id
                        select new
                        {
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

    }
}
