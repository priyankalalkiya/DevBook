using Developer_book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developer_book.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(ProfileModel profile)
        {
            if (ModelState.IsValid)
            {
                ProfileModel profileModel = new ProfileModel();
                profileModel.CreateProfile(profile);

                // Redirect to the Dashboard action after successfully adding the profile
                return RedirectToAction("Index", "Dashboard"); // Assuming you have an "Index" action in the "Dashboard" controller
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("Index", profile);
        }
    }
}
