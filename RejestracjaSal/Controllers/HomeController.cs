using Microsoft.AspNetCore.Mvc;
using RejestracjaSal.Models;
using System.Diagnostics;

namespace RejestracjaSal.Controllers
{
    public class HomeController : Controller
    {
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
            if (myUsers.Any())
            {
                return View("StronaGlowna");
            }
            else
            {
                return View("Logowanie");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StaticSites(string name)
        {
            return View(name);
        }
    }
}
