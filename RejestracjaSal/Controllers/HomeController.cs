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

                AppDbContext.Users.Add(newUser);
                AppDbContext.SaveChanges();
                return View("StronaGlowna");
            }

            ViewBag.message = "Has³a siê niezgadzaj¹";
            return View("Rejestracja");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StaticSites(string name, int pageNumber = 1, int pageSize = 12)
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
            int totalPages = (int)Math.Ceiling(totalRooms / (double)pageSize);

            var pagedRooms = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            if (name == "StronaGlowna")
            {
                ViewBag.Rooms = pagedRooms;
                ViewBag.CurrentPage = pageNumber;
                ViewBag.TotalPages = totalPages;
            }

            return View(name);
        }

    }
}
