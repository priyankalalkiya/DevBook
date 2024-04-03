using Developer_book.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Developer_book.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            var model = new RegisterModel();

            // Populate the model with necessary data, including the username

            // Pass the model to the view
            return View(model);
            //return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterModel user)
        {
            if (ModelState.IsValid)
            {

                RegisterModel registermodel = new RegisterModel();
                registermodel.RegisterUser(user);

                // Redirect to the Signin action after successfully registering the user
                return RedirectToAction("Index", "Signin");
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("Index", user);
        }
    }
}
