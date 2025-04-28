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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string login, string password, string repeatPassword,
                                     string email, string username, string phone)
        {
            Users newUser;



            if (password == repeatPassword)
            {
                if(!AppDbContext.FindLogin(login))
                {
                    if (!AppDbContext.FindEmail(email))
                    {
                        if (!AppDbContext.FindPhone(phone) && phone != null)
                        {
                            newUser = new Users
                            {
                                Name = username,
                                Email = email,
                                Phone = phone,
                                Role_id = 2,
                                Login = login,
                                Password = password
                            };


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
                            return RedirectToAction("StaticSites", "Home", new { name = "StronaGlowna" });
                        }
                        else if (phone == null)
                        {
                            newUser = new Users
                            {
                                Name = username,
                                Email = email,
                                Role_id = 2,
                                Login = login,
                                Password = password
                            };

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
                            return RedirectToAction("StaticSites", "Home", new { name = "StronaGlowna" });
                        }
                        TempData["message"] = "Podany telefon jest zajęty";
                        return RedirectToAction("StaticSites", "Home", new { name = "Rejestracja" });
                    }
                    TempData["message"] = "Podany email jest zajęty";
                    return RedirectToAction("StaticSites", "Home", new { name = "Rejestracja" });
                }
                TempData["message"] = "Podany login już istnieje";
                return RedirectToAction("StaticSites", "Home", new { name = "Rejestracja" });
            }
            TempData["message"] = "Hasła się niezgadzają";
            return RedirectToAction("StaticSites", "Home", new { name = "Rejestracja" });

        }
        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            IQueryable<Users> myUsers = from user in AppDbContext.Users
                                        where user.Login == login && user.Password == password
                                        select user;
            Users users = myUsers.FirstOrDefault();
            if (myUsers.Any() && users.Role_id!= 1)
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
            else if(users.Role_id == 1)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, users.Name),
                    new Claim(ClaimTypes.Role, users.Role_id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("StaticSites", "Home", new { name = "Banned" });
            }
            else if(myUsers.Any() == false)
            {
                TempData["message"] = "Konto o Podanym loginie i haśle nie istnieje";
                return RedirectToAction("StaticSites", "Home", new { name = "Logowanie" });
            }
            return RedirectToAction("StaticSites", "Home", new { name = "Logowanie" });
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
