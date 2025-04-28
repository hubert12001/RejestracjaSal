using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Drawing.Printing;
using System.Security.Claims;

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
        public async Task<IActionResult> Register(string login, string password, string repeatPassword,
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
                        Phone = Int32.Parse(phone),
                        Role_id = 2,
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
                        Role_id = 2,
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

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, newUser.Name),
                    new Claim(ClaimTypes.Role, newUser.Role_id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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
        public async Task<IActionResult> Login(string login, string password)
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

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, users.Name),
                    new Claim(ClaimTypes.Role, users.Role_id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                List<string> types = AppDbContext.GetTypes();
                List<string> locations = AppDbContext.GetLocations();
                ViewBag.RoomTypes = types;
                ViewBag.Locations = locations;
                return RedirectToAction("StaticSites", "Home", new { name = "StronaGlowna" });
            }
            else
            {
                ViewBag.message = "Konto o Podanym loginie i haśle nie istnieje";
                return RedirectToAction("StaticSites", "Home", new { name = "StronaGlowna" });
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

 

            return RedirectToAction("StaticSites", "Home", new { name = "Logowanie" });
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
