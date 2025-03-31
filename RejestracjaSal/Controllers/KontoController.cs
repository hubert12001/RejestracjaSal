using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;

namespace RejestracjaSal.Controllers
{
    public class KontoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CookieOptions options = new CookieOptions()
        {
            Domain = "localhost", // Set the domain for the cookie
            Path = "/", // Cookie is available within the entire application
            Expires = DateTime.Now.AddDays(7), // Set cookie expiration to 7 days from now
            Secure = false, // Ensure the cookie is only sent over HTTPS (set to false for local development)
            HttpOnly = false, // Prevent client-side scripts from accessing the cookie
            IsEssential = true // Indicates the cookie is essential for the application to function
        };

        AppDbContext AppDbContext;
        public KontoController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            this.AppDbContext = appDbContext;
        }



        [HttpPost]
        public IActionResult Register(string login, string password, string repeatPassword,
                                     string email, string username, string phone)
        {
            Users newUser;



            if (password == repeatPassword)
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
                else
                {
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
                return View("/Views/Home/StronaGlowna.cshtml");
            }

            ViewBag.message = "Hasła się niezgadzają";
            return View("/Views/Home/Rejestracja.cshtml");

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
                return View("/Views/Home/StronaGlowna.cshtml");
            }
            else
            {
                ViewBag.message = "Konto o Podanym loginie i haśle nie istnieje";
                return View("/Views/Home/Logowanie.cshtml");
            }
        }


        public IActionResult Logout()
        {
            Response.Cookies.Delete("login", options);
            return View("/Views/Home/Logowanie.cshtml");
        }

        public IActionResult StronaGlowna()
        {
            return View("/Views/Home/StronaGlowna.cshtml");
        }
    }
}
