using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Data;
using System.Linq;

namespace Assignment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserDbContext _dbContext;

        public HomeController(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            // Check if email is already registered
            var existingUser = _dbContext.User.FirstOrDefault(u => u.Email == email);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Email already registered.";
                return View("Index");
            }

            // Add new user to the "user" table
            var newUser = new User { Email = email, Password = password };
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            // Redirect to member page with welcome message
            return RedirectToAction("Member", new { email = email });
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Check if email and password match any existing user
            var user = _dbContext.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Index");
            }

            // Redirect to member page with welcome message
            return RedirectToAction("Member", new { email = email });
        }

        public IActionResult Member(string email)
        {
            ViewBag.Message = $"Welcome, {email}!";
            return View();
        }
    }
}
