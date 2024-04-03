using Developer_book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developer_book.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            RegisterModel registerModel = new RegisterModel();

            if (registerModel.UserExists(email, password))
            {
                // Get user name
                string userName = registerModel.GetUserName(email, password);

                if (!string.IsNullOrEmpty(userName))
                {
                    // Pass user name to the dashboard view
                    ViewBag.UserName = userName;

                    // Redirect to dashboard
                    return RedirectToAction("Index", "Home");
                }
            }

            // User doesn't exist or invalid login, handle accordingly
            ModelState.AddModelError("", "Invalid email or password");
            return View("Index");
        }
    }
}
