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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FindRoom(string find, int pageNumber = 1, int pageSize = 12)
        {
            string cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                ViewBag.name = Request.Cookies["login"];
            }

            (object, int) pgroom = AppDbContext.FindRooms(pageSize, pageNumber, find);
            ViewBag.Rooms = pgroom.Item1;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = pgroom.Item2;

            return View("StronaGlowna");
        }
        public IActionResult StaticSites(string name, int pageNumber = 1, int pageSize = 12)
        {

            string cookie = Request.Cookies["login"];
            if (cookie != null) {
                ViewBag.name = Request.Cookies["login"];
            }

            if (name == "StronaGlowna")
            {
                (object,int) pgroom = AppDbContext.GetRooms(pageSize, pageNumber);
                ViewBag.Rooms = pgroom.Item1;
                ViewBag.CurrentPage = pageNumber;
                ViewBag.TotalPages = pgroom.Item2;
            }

            return View(name);
        }

    }
}
