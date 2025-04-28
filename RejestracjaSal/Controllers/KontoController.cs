using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Drawing.Printing;

namespace RejestracjaSal.Controllers
{
    public class KontoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CookieOptions options = new CookieOptions()
        {
            Domain = "localhost", // Set the domain for the cookie
            Path = "/", // Cookie is available within the entire application
            Expires = DateTime.Now.AddDays(1), // Set cookie expiration to 7 days from now
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
                        Name = username,
                        Email = email,
                        Phone = phone,
                        Role_id = 1,
                        Login = login,
                        Password = password
                    };
                }
                else
                {
                    newUser = new Users
                    {
                        Name = username,
                        Email = email,
                        Role_id = 1,
                        Login = login,
                        Password = password
                    };
                }

                (object, int) pgroom = AppDbContext.FindRooms(12, 1);
                ViewBag.Rooms = pgroom.Item1;
                ViewBag.CurrentPage = 1;
                ViewBag.TotalPages = pgroom.Item2;
                AppDbContext.Users.Add(newUser);
                AppDbContext.SaveChanges();
                Response.Cookies.Append("login", newUser.Name, options);
                ViewBag.name = Request.Cookies["login"];

                List<string> types = AppDbContext.GetTypes();
                List<string> locations = AppDbContext.GetLocations();
                ViewBag.RoomTypes = types;
                ViewBag.Locations = locations;
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
                (object, int) pgroom = AppDbContext.FindRooms(12, 1);
                ViewBag.Rooms = pgroom.Item1;
                ViewBag.CurrentPage = 1;
                ViewBag.TotalPages = pgroom.Item2;

                Response.Cookies.Append("login", users.Name, options);
                Response.Cookies.Append("roleId", users.Role_id.ToString(), options);
                ViewBag.name = users.Name;
                ViewBag.role = users.Role_id.ToString();


                List<string> types = AppDbContext.GetTypes();
                List<string> locations = AppDbContext.GetLocations();
                ViewBag.RoomTypes = types;
                ViewBag.Locations = locations;
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
            Response.Cookies.Delete("roleId", options);
            return View("/Views/Home/Logowanie.cshtml");
        }

        public IActionResult StronaGlowna()
        {
            List<string> types = AppDbContext.GetTypes();
            List<string> locations = AppDbContext.GetLocations();
            ViewBag.RoomTypes = types;
            ViewBag.Locations = locations;
            return View("/Views/Home/StronaGlowna.cshtml");
        }
    }
}
