using Microsoft.AspNetCore.Mvc;
using Developer_book.Models;

namespace Developer_book.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: /Experience/Index
        public IActionResult Index()
        {
            var model = new ExperienceModel();

            // Populate the model with necessary data, including the username

            // Pass the model to the view
            return View(model);
            //return View();
        }
       
        public IActionResult Dashboard()
        {
            return View();
        }
        // POST: /Experience/AddExperience
        [HttpPost]
        public IActionResult AddExperience(ExperienceModel exp)
        {
            if (ModelState.IsValid)
            {
                // Instantiate an object of ExperienceModel
                ExperienceModel experienceModel = new ExperienceModel();

                // Call the AddExperience method on the instantiated object
                experienceModel.AddExperience(exp);

                // Redirect to the Dashboard action after successfully adding the experience
                return RedirectToAction("Index", "Dashboard");
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("Index", exp);
        }
    }
}
